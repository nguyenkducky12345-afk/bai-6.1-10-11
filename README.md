# BÁO CÁO BÀI TẬP / ĐỒ ÁN

## THÔNG TIN SINH VIÊN
- **Họ và tên:** Nguyễn Khánh Đức
- **Mã số sinh viên:** 24810320072
- **Lớp:** D19QTANM1
- **Tên môn học:** Lập trình C# / Windows Forms
- **Tên bài tập:** Bài 6.1: HỆ THỐNG QUẢN LÝ BÁN HÀNG & SIÊU THỊ MINI (RETAIL
SALES SYSTEM)

---

## KẾT QUẢ THỰC HÀNH

- Giao diện chính
<img width="1165" height="748" alt="Screenshot 2026-11-10 181631" src="https://github.com/user-attachments/assets/9c1b2601-1727-4097-b4f2-99a706965c94" />

- Giao diện thêm hàng vào giỏ hàng
<img width="1146" height="727" alt="Screenshot 2026-11-10 181655" src="https://github.com/user-attachments/assets/4180a31b-9336-4985-a5ce-a50724082048" />

- Giao diện xác nhận thanh toán thành công + lưu dữ liệu vào database
<img width="1145" height="739" alt="Screenshot 2026-11-10 181709" src="https://github.com/user-attachments/assets/9f092422-fc9d-49cb-9b8d-2e1349c7f14f" />

- Hiển thị giao diện top 5 mặt hàng doanh thu
<img width="1144" height="734" alt="Screenshot 2026-11-10 181728" src="https://github.com/user-attachments/assets/0f738516-6505-496d-94ec-430e29a4580a" />


## HƯỚNG DẪN CÀI ĐẶT VÀ CHẠY DỰ ÁN:
1. **Khởi tạo CSDL**:
   - Mở file `Database.sql` có sẵn trong thư mục dự án bằng SQL Server Management Studio (SSMS) hoặc Visual Studio.
   - Chạy toàn bộ script (Execute) để tự động tạo CSDL `SieuthiDB` cùng các bảng và dữ liệu mẫu.

2. **Cấu hình chuỗi kết nối**:
   - Mở file `Dbhelper.cs`.
   - Kiểm tra và đổi lại `Data Source` cho khớp với tên SQL Server trên máy chấm (Mặc định đang để kết nối tới `(localdb)\MSSQLLocalDB`).

3. **Chạy chương trình**:
   - Nhấn **F5** (hoặc nút Start) trên Visual Studio để chạy hệ thống.
