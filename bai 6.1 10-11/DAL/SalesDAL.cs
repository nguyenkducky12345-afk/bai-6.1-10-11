using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RetailSalesSystem.DTO;

namespace RetailSalesSystem.DAL
{
    public class SalesDAL
    {
        // 1. Lấy danh sách sản phẩm
        public List<SanPhamDTO> GetDanhSachSanPham()
        {
            List<SanPhamDTO> list = new List<SanPhamDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT MaSP, TenSP, GiaBan, SoLuongTon FROM SanPham";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new SanPhamDTO
                    {
                        MaSP = reader["MaSP"].ToString(),
                        TenSP = reader["TenSP"].ToString(),
                        GiaBan = Convert.ToDecimal(reader["GiaBan"]),
                        SoLuongTon = Convert.ToInt32(reader["SoLuongTon"])
                    });
                }
            }
            return list;
        }

        // 2. Lấy danh sách khách hàng
        public List<KhachHangDTO> GetDanhSachKhachHang()
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT MaKH, TenKH, DienThoai, DiemTichLuy FROM KhachHang";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new KhachHangDTO
                    {
                        MaKH = Convert.ToInt32(reader["MaKH"]),
                        TenKH = reader["TenKH"].ToString(),
                        DienThoai = reader["DienThoai"].ToString(),
                        DiemTichLuy = Convert.ToInt32(reader["DiemTichLuy"])
                    });
                }
            }
            return list;
        }

        // 3. XỬ LÝ THANH TOÁN SỬ DỤNG SqlTransaction
        public bool ThanhToanHoaDon(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> dsChiTiet, out string errorMessage)
        {
            errorMessage = "";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // BẮT ĐẦU TRANSACTION
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // Bước A: Kiểm tra và trừ tồn kho
                    foreach (var item in dsChiTiet)
                    {
                        // Kiểm tra số lượng tồn (dùng parameterized)
                        string sqlCheck = "SELECT SoLuongTon FROM SanPham WITH (UPDLOCK) WHERE MaSP = @MaSP";
                        SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn, trans);
                        cmdCheck.Parameters.AddWithValue("@MaSP", item.MaSP);

                        object result = cmdCheck.ExecuteScalar();
                        if (result == null)
                        {
                            throw new Exception($"Sản phẩm '{item.MaSP}' không tồn tại!");
                        }

                        int tonKhoHienTai = Convert.ToInt32(result);
                        if (tonKhoHienTai < item.SoLuong)
                        {
                            throw new Exception($"Sản phẩm '{item.TenSP}' không đủ hàng tồn kho (Còn: {tonKhoHienTai})!");
                        }

                        // Trừ tồn kho
                        string sqlUpdateStock = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSP = @MaSP";
                        SqlCommand cmdUpdate = new SqlCommand(sqlUpdateStock, conn, trans);
                        cmdUpdate.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                        cmdUpdate.Parameters.AddWithValue("@MaSP", item.MaSP);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // Bước B: Tạo hóa đơn (Lấy MaHD vừa tạo bằng SCOPE_IDENTITY)
                    string sqlInsertHD = @"INSERT INTO HoaDon (NgayLap, MaNV, MaKH, TongTien) 
                                           VALUES (@NgayLap, @MaNV, @MaKH, @TongTien);
                                           SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdHD = new SqlCommand(sqlInsertHD, conn, trans);
                    cmdHD.Parameters.AddWithValue("@NgayLap", hoaDon.NgayLap);
                    cmdHD.Parameters.AddWithValue("@MaNV", hoaDon.MaNV);
                    cmdHD.Parameters.AddWithValue("@MaKH", (object)hoaDon.MaKH ?? DBNull.Value);
                    cmdHD.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);

                    int maHDMoi = Convert.ToInt32(cmdHD.ExecuteScalar());

                    // Bước C: Chèn chi tiết hóa đơn
                    foreach (var item in dsChiTiet)
                    {
                        string sqlInsertCT = @"INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) 
                                               VALUES (@MaHD, @MaSP, @SoLuong, @DonGia)";
                        SqlCommand cmdCT = new SqlCommand(sqlInsertCT, conn, trans);
                        cmdCT.Parameters.AddWithValue("@MaHD", maHDMoi);
                        cmdCT.Parameters.AddWithValue("@MaSP", item.MaSP);
                        cmdCT.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                        cmdCT.Parameters.AddWithValue("@DonGia", item.DonGia);
                        cmdCT.ExecuteNonQuery();
                    }

                    // Bước D: Cộng điểm tích lũy cho khách hàng (Nếu có khách hàng)
                    if (hoaDon.MaKH.HasValue && hoaDon.MaKH.Value > 0)
                    {
                        int diemCong = (int)(hoaDon.TongTien / 100000);
                        if (diemCong > 0)
                        {
                            string sqlUpdateDiem = "UPDATE KhachHang SET DiemTichLuy = DiemTichLuy + @Diem WHERE MaKH = @MaKH";
                            SqlCommand cmdDiem = new SqlCommand(sqlUpdateDiem, conn, trans);
                            cmdDiem.Parameters.AddWithValue("@Diem", diemCong);
                            cmdDiem.Parameters.AddWithValue("@MaKH", hoaDon.MaKH.Value);
                            cmdDiem.ExecuteNonQuery();
                        }
                    }

                    // HOÀN TẤT GIAO DỊCH
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // NẾU CÓ BẤT KỲ LỖI NÀO -> ROLLBACK TOÀN BỘ
                    trans.Rollback();
                    errorMessage = ex.Message;
                    return false;
                }
            }
        }

        // 4. Báo cáo: Tổng doanh thu (Dùng ExecuteScalar)
        public decimal GetTongDoanhThu()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        // 5. Báo cáo: Top 5 sản phẩm bán chạy (Dùng SqlDataReader)
        public DataTable GetTop5SanPham()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT TOP 5 sp.TenSP, SUM(ct.SoLuong) AS DaBan
                               FROM ChiTietHoaDon ct
                               JOIN SanPham sp ON ct.MaSP = sp.MaSP
                               GROUP BY sp.TenSP
                               ORDER BY DaBan DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            return dt;
        }
    }
}