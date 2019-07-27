using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLiKhachSan.DTO;
using QuanLiKhachSan.DAO;

namespace QuanLiKhachSan
{
    public partial class fThongTinTaiKhoan : Form
    {
        EC_NHANVIEN ec = new EC_NHANVIEN();
        EC_TAIKHOAN ectk = new EC_TAIKHOAN();
       
        public fThongTinTaiKhoan()
        {
            this.Controls.Clear();
            InitializeComponent();

        }


        private void txtReNewPassWord_TextChanged(object sender, EventArgs e)
        {

        }
        public void setnull()
        {
            txtpass.Text = "";
            txtNewPassWord.Text = "";
            txtReNewPassWord.Text = "";
        }
        public void hienthi()
        {
            string query = "SELECT  NHANVIEN.MACHUCVU,NHANVIEN.MANHANVIEN,NHANVIEN.TENNHANVIEN, NHANVIEN.GIOITINH, NHANVIEN.NGAYSINH, NHANVIEN.DIACHI, TAIKHOAN.TENTAIKHOAN, TAIKHOAN.PASS, NHANVIEN.SODIENTHOAI FROM  NHANVIEN INNER JOIN TAIKHOAN ON NHANVIEN.MANHANVIEN = TAIKHOAN.MANHANVIEN WHERE TAIKHOAN.TENTAIKHOAN='" + fLogin.TaiKhoan + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            MACV = dt.Rows[0]["MACHUCVU"].ToString().Trim();
            MANV = dt.Rows[0]["MANHANVIEN"].ToString().Trim();
            txtTaiKhoan.Text = dt.Rows[0]["TENTAIKHOAN"].ToString().Trim();
            txtTenNV.Text = dt.Rows[0]["TENNHANVIEN"].ToString().Trim();
            txtDiachi.Text = dt.Rows[0]["DIACHI"].ToString().Trim();
            cbGioitinh.Text = dt.Rows[0]["GIOITINH"].ToString().Trim();
            dtNgaysinh.Text = dt.Rows[0]["NGAYSINH"].ToString().Trim();
            txtSDT.Text = dt.Rows[0]["SODIENTHOAI"].ToString().Trim();
        }
        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            if (txtpass.Text != fLogin.MatKhau || txtNewPassWord.Text != txtReNewPassWord.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu!!!");
                return;
            }
            else
            {
                try
                {
                    ec.MaChucVu = MACV;
                    ec.TenNhanVien = txtTenNV.Text;
                    ec.DiaChi = txtTenNV.Text;
                    ec.NgaySinh = dtNgaysinh.Value;
                    ec.GioiTinh = cbGioitinh.Text;
                    ec.SDT = txtSDT.Text;
                    ec.MaNhanVien = MANV;
                    ectk.MaNhanVien = MANV;
                    ectk.TenTaiKhoan = txtTaiKhoan.Text;
                    ectk.MatKhau = txtNewPassWord.Text;
                    fLogin.MatKhau = txtNewPassWord.Text;
                    NhanVienDAO.Instances.SuaTK(ectk);
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
            hienthi();
        }
        String MANV;
        String MACV;

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDiachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);

        }

        private void cbGioitinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtNewPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtReNewPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void fThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            hienthi();
            setnull();
        }
    }
}
