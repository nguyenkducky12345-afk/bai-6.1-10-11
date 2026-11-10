using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RetailSalesSystem.BUS;
using RetailSalesSystem.DTO;

namespace RetailSalesSystem
{
    public partial class Form1 : Form
    {
        private SalesBUS bus = new SalesBUS();
        private List<ChiTietHoaDonDTO> gioHang = new List<ChiTietHoaDonDTO>();
        private List<SanPhamDTO> dsSanPham = new List<SanPhamDTO>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void LoadDuLieu()
        {
            // Load Sản phẩm
            dsSanPham = bus.LayDanhSachSanPham();
            cboSanPham.DataSource = dsSanPham;
            cboSanPham.DisplayMember = "TenSP";
            cboSanPham.ValueMember = "MaSP";

            // Load Khách hàng
            var dsKH = bus.LayDanhSachKhachHang();
            cboKhachHang.DataSource = dsKH;
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";

            CapNhatBangGioHang();
        }

        private void btnThemGio_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedItem == null) return;

            SanPhamDTO spChon = (SanPhamDTO)cboSanPham.SelectedItem;
            int soLuong = (int)nudSoLuong.Value;

            // Kiểm tra trùng trong giỏ
            var itemExist = gioHang.FirstOrDefault(x => x.MaSP == spChon.MaSP);
            if (itemExist != null)
            {
                itemExist.SoLuong += soLuong;
            }
            else
            {
                gioHang.Add(new ChiTietHoaDonDTO
                {
                    MaSP = spChon.MaSP,
                    TenSP = spChon.TenSP,
                    GiaBan = spChon.GiaBan,
                    SoLuong = soLuong
                });
            }

            CapNhatBangGioHang();
        }

        private void CapNhatBangGioHang()
        {
            dgvGioHang.DataSource = null;
            dgvGioHang.DataSource = gioHang.ToList(); // Refresh GridView

            decimal tongTien = gioHang.Sum(x => x.ThanhTien);
            lblTongTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            HoaDonDTO hd = new HoaDonDTO
            {
                NgayLap = DateTime.Now,
                MaNV = 1, // Giả sử nhân viên mã số 1 đang đăng nhập
                MaKH = Convert.ToInt32(cboKhachHang.SelectedValue),
                TongTien = gioHang.Sum(x => x.ThanhTien)
            };

            string error = "";
            bool result = bus.ThanhToan(hd, gioHang, out error);

            if (result)
            {
                MessageBox.Show("Thanh toán thành công! Dữ liệu đã được lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gioHang.Clear();
                CapNhatBangGioHang();
                LoadDuLieu(); // Load lại để cập nhật tồn kho mới
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại! Đã Rollback giao dịch.\nLỗi: " + error, "Lỗi Giao Dịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            decimal tongDoanhThu = bus.LayTongDoanhThu();
            var dtTop5 = bus.LayTop5BanChay();

            string top5Info = "TOP 5 SẢN PHẨM BÁN CHẠY:\n";
            foreach (System.Data.DataRow row in dtTop5.Rows)
            {
                top5Info += $"- {row["TenSP"]}: Đã bán {row["DaBan"]}\n";
            }

            MessageBox.Show($"TỔNG DOANH THU: {tongDoanhThu:N0} VNĐ\n\n{top5Info}", "Báo Cáo Nhanh");
        }
    }
}