using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiKhachSan.DAO;
using QuanLiKhachSan.DTO;

namespace QuanLiKhachSan
{
    public partial class fDanhSachNhanVien : Form
    {
        public fDanhSachNhanVien()
        {
            InitializeComponent();          
        }
        EC_NHANVIEN ec = new EC_NHANVIEN();
        EC_TAIKHOAN tk = new EC_TAIKHOAN();

        
        
        public void Hienthi(string where)
        {
            grvDanhSachNhanVien.DataSource = NhanVienDAO.Instances.Taobang(where);
        }
        
        void setnull()
        {
            txtManv.Text = "";
            txtTennv.Text = "";
            cbGioitinh.Text = "Nam";
            cbMaChucvu.Text = "";
            txtDaichi.Text = "";
            txtSDT.Text = "";
            txtTK.Text = "";
            txtMK.Text = "";

        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtManv.Text = "";
            txtTK.Text = "";

            if (txtTennv.Text == "" || cbMaChucvu.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!!!");
                return;
            }
            else
            {
                try
                {
                    ec.MaNhanVien = txtManv.Text;
                    ec.TenNhanVien = txtTennv.Text;
                    ec.NgaySinh = dtNgaysinh.Value;
                    ec.SDT = txtSDT.Text;
                    ec.GioiTinh = cbGioitinh.Text;
                    ec.MaChucVu = cbMaChucvu.Text;
                    ec.DiaChi = txtDaichi.Text;
                    tk.MatKhau = txtMK.Text;
                    tk.MaChucVu = cbMaChucvu.Text;
                    NhanVienDAO.Instances.ThemNhanVien(ec);
                    string query = " execute LayMANV_max";
                    DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
                    string ma = dt.Rows[0][0].ToString().Trim();
                    tk.MaNhanVien = ma;
                    NhanVienDAO.Instances.ThemTK(tk);
                    //chạy dât chưa AF CHWAdk m
                    MessageBox.Show("Thực hiện thành công!!!");
                }
                catch
                {
                    MessageBox.Show("Lỗi!!!");
                    return;
                }
            }
            setnull();
            Hienthi("");
        }
   

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtManv.Text == "")
            {
                MessageBox.Show("Nhập hoặc chọn mã nhân viên cần xóa!!!");
                return;
            }
            else
            
            {
                try
                {
                    ec.MaNhanVien = txtManv.Text;
                    NhanVienDAO.Instances.XoaNhanVien(ec);
                    MessageBox.Show("Xóa thành công!!!");
                }
                catch
                {
                    MessageBox.Show("Lỗi!!!");
                    return;
                }
            }
            setnull();
            Hienthi("");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtManv.Text == "")
            {
                MessageBox.Show("Hãy chọn hàng cần sửa!!!");
                return;
            }
            else
            {
                try
                {
                    ec.MaNhanVien = txtManv.Text;
                    ec.TenNhanVien = txtTennv.Text;
                    ec.NgaySinh = dtNgaysinh.Value;
                    ec.SDT = txtSDT.Text;
                    ec.GioiTinh = cbGioitinh.Text;
                    ec.MaChucVu = cbMaChucvu.Text;
                    ec.DiaChi = txtDaichi.Text;
                    tk.MaNhanVien = txtManv.Text;
                    tk.TenTaiKhoan = txtTK.Text;
                    tk.MatKhau = txtMK.Text;
                    NhanVienDAO.Instances.SuaTK(tk);
                    NhanVienDAO.Instances.SuaNhanVien(ec);
                    MessageBox.Show("Thực hiện thành công!!!");
                 }

                catch
                {
                MessageBox.Show("Lỗi!!!");
                return;
                }
            }
            setnull();
            Hienthi("");
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void grvDanhSachNhanVien_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtManv.Text = grvDanhSachNhanVien.SelectedRows[0].Cells[0].Value.ToString();
            txtTennv.Text = grvDanhSachNhanVien.SelectedRows[0].Cells[2].Value.ToString();
            cbGioitinh.Text = grvDanhSachNhanVien.SelectedRows[0].Cells[3].Value.ToString();
            dtNgaysinh.Text = grvDanhSachNhanVien.SelectedRows[0].Cells[4].Value.ToString();
            txtDaichi.Text = grvDanhSachNhanVien.SelectedRows[0].Cells[5].Value.ToString();
            string Tenchucvu = grvDanhSachNhanVien.SelectedRows[0].Cells[8].Value.ToString();
            if (Tenchucvu == "NHANVIEN")
            {
                cbMaChucvu.Text = "CV0001";
            }
            else cbMaChucvu.Text = "CV0002";
            txtSDT.Text = grvDanhSachNhanVien.SelectedRows[0].Cells[1].Value.ToString();
            txtTK.Text = grvDanhSachNhanVien.SelectedRows[0].Cells[6].Value.ToString();
            txtMK.Text = grvDanhSachNhanVien.SelectedRows[0].Cells[7].Value.ToString();
        }

        public void fDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            Hienthi("");
            setnull();
            txtManv.Enabled = false;
            txtTK.Enabled = false;
            string query = " SELECT MACHUCVU FROM  CHUCVU";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbMaChucvu.Items.Add(dt.Rows[i]["MACHUCVU"].ToString().Trim());
            }
        }

        private void txtTennv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtDaichi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);

        }

        private void cbGioitinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtMK_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
