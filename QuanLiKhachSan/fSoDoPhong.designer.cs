namespace QuanLiKhachSan
{
    partial class fSoDoPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listVThongTinPhong = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbChonLoaiPhongDeSua = new System.Windows.Forms.ComboBox();
            this.btnHienThiToanBoDanhSach = new System.Windows.Forms.Button();
            this.txtDonViTien = new System.Windows.Forms.TextBox();
            this.txtGiaPhong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbPhong = new System.Windows.Forms.ComboBox();
            this.cbbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.flpThongKe = new System.Windows.Forms.FlowLayoutPanel();
            this.flpDanhSachCacPhong = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 573);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.listVThongTinPhong);
            this.panel4.Location = new System.Drawing.Point(728, 238);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(426, 328);
            this.panel4.TabIndex = 1;
            // 
            // listVThongTinPhong
            // 
            this.listVThongTinPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listVThongTinPhong.BackColor = System.Drawing.SystemColors.Info;
            this.listVThongTinPhong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listVThongTinPhong.GridLines = true;
            this.listVThongTinPhong.Location = new System.Drawing.Point(3, 3);
            this.listVThongTinPhong.Name = "listVThongTinPhong";
            this.listVThongTinPhong.Size = new System.Drawing.Size(422, 315);
            this.listVThongTinPhong.TabIndex = 0;
            this.listVThongTinPhong.UseCompatibleStateImageBehavior = false;
            this.listVThongTinPhong.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Phòng";
            this.columnHeader1.Width = 66;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Phòng";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tình Trạng";
            this.columnHeader3.Width = 77;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Loại Phòng";
            this.columnHeader4.Width = 94;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Giá Phòng";
            this.columnHeader5.Width = 78;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Đơn Vị Tiền";
            this.columnHeader6.Width = 101;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.cbbChonLoaiPhongDeSua);
            this.panel3.Controls.Add(this.btnHienThiToanBoDanhSach);
            this.panel3.Controls.Add(this.txtDonViTien);
            this.panel3.Controls.Add(this.txtGiaPhong);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.btnRemove);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbbPhong);
            this.panel3.Controls.Add(this.cbbLoaiPhong);
            this.panel3.Location = new System.Drawing.Point(728, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(422, 232);
            this.panel3.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Sửa Loại Phòng";
            // 
            // cbbChonLoaiPhongDeSua
            // 
            this.cbbChonLoaiPhongDeSua.FormattingEnabled = true;
            this.cbbChonLoaiPhongDeSua.Location = new System.Drawing.Point(128, 164);
            this.cbbChonLoaiPhongDeSua.Name = "cbbChonLoaiPhongDeSua";
            this.cbbChonLoaiPhongDeSua.Size = new System.Drawing.Size(193, 21);
            this.cbbChonLoaiPhongDeSua.TabIndex = 12;
            this.cbbChonLoaiPhongDeSua.Text = "Bấm vào đây để chọn loại phòng";
            // 
            // btnHienThiToanBoDanhSach
            // 
            this.btnHienThiToanBoDanhSach.Location = new System.Drawing.Point(327, 41);
            this.btnHienThiToanBoDanhSach.Name = "btnHienThiToanBoDanhSach";
            this.btnHienThiToanBoDanhSach.Size = new System.Drawing.Size(90, 23);
            this.btnHienThiToanBoDanhSach.TabIndex = 11;
            this.btnHienThiToanBoDanhSach.Text = "Xem Toàn Bộ";
            this.btnHienThiToanBoDanhSach.UseVisualStyleBackColor = true;
            this.btnHienThiToanBoDanhSach.Click += new System.EventHandler(this.btnHienThiToanBoDanhSach_Click);
            // 
            // txtDonViTien
            // 
            this.txtDonViTien.Location = new System.Drawing.Point(128, 125);
            this.txtDonViTien.Name = "txtDonViTien";
            this.txtDonViTien.Size = new System.Drawing.Size(193, 20);
            this.txtDonViTien.TabIndex = 10;
            // 
            // txtGiaPhong
            // 
            this.txtGiaPhong.Location = new System.Drawing.Point(128, 85);
            this.txtGiaPhong.Name = "txtGiaPhong";
            this.txtGiaPhong.Size = new System.Drawing.Size(193, 20);
            this.txtGiaPhong.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đơn Vị Tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Giá Phòng";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(327, 204);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(246, 204);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(165, 204);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Phòng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loại Phòng";
            // 
            // cbbPhong
            // 
            this.cbbPhong.FormattingEnabled = true;
            this.cbbPhong.Location = new System.Drawing.Point(128, 41);
            this.cbbPhong.Name = "cbbPhong";
            this.cbbPhong.Size = new System.Drawing.Size(193, 21);
            this.cbbPhong.TabIndex = 1;
            this.cbbPhong.Text = "Bấm vào đây để chọn phòng";
            this.cbbPhong.SelectedIndexChanged += new System.EventHandler(this.cbbPhong_SelectedIndexChanged);
            // 
            // cbbLoaiPhong
            // 
            this.cbbLoaiPhong.FormattingEnabled = true;
            this.cbbLoaiPhong.Location = new System.Drawing.Point(128, 4);
            this.cbbLoaiPhong.Name = "cbbLoaiPhong";
            this.cbbLoaiPhong.Size = new System.Drawing.Size(193, 21);
            this.cbbLoaiPhong.TabIndex = 0;
            this.cbbLoaiPhong.Text = "Bấm vào đây để chọn loại phòng";
            this.cbbLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiPhong_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.flpThongKe);
            this.panel2.Controls.Add(this.flpDanhSachCacPhong);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(723, 563);
            this.panel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(550, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 79);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thống Kê Số Lượng Phòng Theo Tình Trạng Phòng";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpThongKe
            // 
            this.flpThongKe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpThongKe.Location = new System.Drawing.Point(554, 83);
            this.flpThongKe.Name = "flpThongKe";
            this.flpThongKe.Size = new System.Drawing.Size(169, 196);
            this.flpThongKe.TabIndex = 1;
            // 
            // flpDanhSachCacPhong
            // 
            this.flpDanhSachCacPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpDanhSachCacPhong.Location = new System.Drawing.Point(3, 2);
            this.flpDanhSachCacPhong.Name = "flpDanhSachCacPhong";
            this.flpDanhSachCacPhong.Size = new System.Drawing.Size(545, 532);
            this.flpDanhSachCacPhong.TabIndex = 0;
            // 
            // fSoDoPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 569);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fSoDoPhong";
            this.Text = "fSoDoPhong";
            this.Load += new System.EventHandler(this.fSoDoPhong_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbbLoaiPhong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpDanhSachCacPhong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flpThongKe;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDonViTien;
        private System.Windows.Forms.TextBox txtGiaPhong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbPhong;
        private System.Windows.Forms.Button btnHienThiToanBoDanhSach;
        private System.Windows.Forms.ListView listVThongTinPhong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbChonLoaiPhongDeSua;
    }
}