namespace RetailSalesSystem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.grpSanPham = new System.Windows.Forms.GroupBox();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemGio = new System.Windows.Forms.Button();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.grpThongTin.SuspendLayout();
            this.grpSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblKhachHang);
            this.grpThongTin.Controls.Add(this.cboKhachHang);
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(760, 65);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "1. Thông tin chung";
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(16, 28);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(110, 17);
            this.lblKhachHang.TabIndex = 0;
            this.lblKhachHang.Text = "Chọn Khách hàng:";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(135, 25);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(320, 25);
            this.cboKhachHang.TabIndex = 1;
            // 
            // grpSanPham
            // 
            this.grpSanPham.Controls.Add(this.lblSanPham);
            this.grpSanPham.Controls.Add(this.cboSanPham);
            this.grpSanPham.Controls.Add(this.lblSoLuong);
            this.grpSanPham.Controls.Add(this.nudSoLuong);
            this.grpSanPham.Controls.Add(this.btnThemGio);
            this.grpSanPham.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSanPham.Location = new System.Drawing.Point(12, 85);
            this.grpSanPham.Name = "grpSanPham";
            this.grpSanPham.Size = new System.Drawing.Size(760, 75);
            this.grpSanPham.TabIndex = 1;
            this.grpSanPham.TabStop = false;
            this.grpSanPham.Text = "2. Chọn Hàng Hóa";
            // 
            // lblSanPham
            // 
            this.lblSanPham.AutoSize = true;
            this.lblSanPham.Location = new System.Drawing.Point(16, 32);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(99, 17);
            this.lblSanPham.TabIndex = 0;
            this.lblSanPham.Text = "Chọn Sản phẩm:";
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(135, 29);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(260, 25);
            this.cboSanPham.TabIndex = 1;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(415, 32);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(64, 17);
            this.lblSoLuong.TabIndex = 2;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(485, 29);
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(70, 25);
            this.nudSoLuong.TabIndex = 3;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThemGio
            // 
            this.btnThemGio.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThemGio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemGio.ForeColor = System.Drawing.Color.White;
            this.btnThemGio.Location = new System.Drawing.Point(585, 25);
            this.btnThemGio.Name = "btnThemGio";
            this.btnThemGio.Size = new System.Drawing.Size(145, 32);
            this.btnThemGio.TabIndex = 4;
            this.btnThemGio.Text = "+ Thêm Vào Giỏ";
            this.btnThemGio.UseVisualStyleBackColor = false;
            this.btnThemGio.Click += new System.EventHandler(this.btnThemGio_Click);
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioHang.Location = new System.Drawing.Point(12, 175);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.RowHeadersVisible = false;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(760, 240);
            this.dgvGioHang.TabIndex = 2;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTongTien.Location = new System.Drawing.Point(12, 435);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(183, 25);
            this.lblTongTien.TabIndex = 3;
            this.lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.ForestGreen;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(545, 428);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(227, 42);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "THANH TOÁN (ACID)";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.BackColor = System.Drawing.Color.DarkOrange;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.Location = new System.Drawing.Point(340, 428);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(185, 42);
            this.btnBaoCao.TabIndex = 5;
            this.btnBaoCao.Text = "Xem Doanh Thu / Top 5";
            this.btnBaoCao.UseVisualStyleBackColor = false;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 485);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.dgvGioHang);
            this.Controls.Add(this.grpSanPham);
            this.Controls.Add(this.grpThongTin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ BÁN HÀNG & SIÊU THỊ MINI (POS)";
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpSanPham.ResumeLayout(false);
            this.grpSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.GroupBox grpSanPham;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThemGio;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnBaoCao;
    }
}