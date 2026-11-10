CREATE DATABASE SieuthiDB;
GO
USE SieuthiDB;
GO

-- 1. Bảng NhanVien
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    TenNV NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15) UNIQUE,
    ChucVu NVARCHAR(50)
);

-- 2. Bảng KhachHang
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15) UNIQUE,
    DiemTichLuy INT DEFAULT 0
);

-- 3. Bảng SanPham
CREATE TABLE SanPham (
    MaSP VARCHAR(20) PRIMARY KEY,
    TenSP NVARCHAR(150) NOT NULL,
    GiaBan DECIMAL(18,2) CHECK (GiaBan > 0),
    SoLuongTon INT CHECK (SoLuongTon >= 0)
);

-- 4. Bảng HoaDon
CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME DEFAULT GETDATE(),
    MaNV INT FOREIGN KEY REFERENCES NhanVien(MaNV),
    MaKH INT NULL FOREIGN KEY REFERENCES KhachHang(MaKH),
    TongTien DECIMAL(18,2)
);

-- 5. Bảng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon (
    MaHD INT FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaSP VARCHAR(20) FOREIGN KEY REFERENCES SanPham(MaSP),
    SoLuong INT CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2),
    PRIMARY KEY (MaHD, MaSP)
);

-- Chèn dữ liệu mẫu thử nghiệm
INSERT INTO NhanVien VALUES (N'Nguyễn Văn Thu Ngân', '0901234567', N'Thu ngân');
INSERT INTO KhachHang VALUES (N'Khách vãng lai', '0000000000', 0), (N'Trần Thị Lan', '0912345678', 5);
INSERT INTO SanPham VALUES 
('SP01', N'Sữa tươi Vinamilk 1L', 32000, 50),
('SP02', N'Bánh mì Sandwich', 18000, 20),
('SP03', N'Nước ngọt Coca-Cola 330ml', 10000, 100),
('SP04', N'Mì Hảo Hảo Tôm Chua Cay', 4500, 200);