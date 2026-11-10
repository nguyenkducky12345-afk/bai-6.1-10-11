using System;
using System.Collections.Generic;
using System.Data;
using RetailSalesSystem.DAL;
using RetailSalesSystem.DTO;

namespace RetailSalesSystem.BUS
{
    public class SalesBUS
    {
        private SalesDAL dal = new SalesDAL();

        public List<SanPhamDTO> LayDanhSachSanPham() => dal.GetDanhSachSanPham();
        public List<KhachHangDTO> LayDanhSachKhachHang() => dal.GetDanhSachKhachHang();
        public decimal LayTongDoanhThu() => dal.GetTongDoanhThu();
        public DataTable LayTop5BanChay() => dal.GetTop5SanPham();

        public bool ThanhToan(HoaDonDTO hd, List<ChiTietHoaDonDTO> chiTiet, out string msg)
        {
            if (chiTiet == null || chiTiet.Count == 0)
            {
                msg = "Giỏ hàng hiện đang trống!";
                return false;
            }
            return dal.ThanhToanHoaDon(hd, chiTiet, out msg);
        }
    }
}