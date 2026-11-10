using System;

namespace RetailSalesSystem.DTO
{
    public class SanPhamDTO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
    }

    public class KhachHangDTO
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DienThoai { get; set; }
        public int DiemTichLuy { get; set; }
    }

    public class NhanVienDTO
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
    }

    public class ChiTietHoaDonDTO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiaBan
        {
            get => DonGia;
            set => DonGia = value;
        }

        public decimal ThanhTien => SoLuong * DonGia;
    }

    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaNV { get; set; }
        public int? MaKH { get; set; }
        public decimal TongTien { get; set; }
    }
}