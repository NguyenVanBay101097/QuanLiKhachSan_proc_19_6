using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiKhachSan.DAO;
using QuanLiKhachSan.DTO;

namespace QuanLiKhachSan
{
    public partial class fPhanChucVu : Form
    {
        EC_CHUCVU ec = new EC_CHUCVU();
        public fPhanChucVu()
        {
            InitializeComponent();
        }
        void setnull()
        {
            txtMacv.Text = "";
            txtTencv.Text = "";
        }
        private void hienthi(string dk)
        {
            dgChucvu.DataSource = ChucVuDAO.Instances.Taobang(dk);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMacv.Text = "";
            if (txtTencv.Text == "")
            {
                MessageBox.Show("Nhập đày đủ thông tin!!!");
                return;
            }
            else
            {
                try
                {
                    ec.TenChucVu = txtTencv.Text;
                    ChucVuDAO.Instances.ThemChucVu(ec);
                    MessageBox.Show("Thực hiện thành công!!!");
                }
                catch
                {
                    MessageBox.Show("Lỗi!!!");
                    return;
                }
            }
            setnull();
            hienthi("");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTencv.Text == "")
            {
                MessageBox.Show("Chọn hàng cần sửa!!!");
                return;
            }
            else
            {
                try
                {
                    ec.MaChucVu = txtMacv.Text;
                    ec.TenChucVu = txtTencv.Text;
                    ChucVuDAO.Instances.SuaChucVu(ec);
                    MessageBox.Show("Thực hiện thành công!!!");
                }
                catch
                {
                    MessageBox.Show("Lỗi!!!");
                    return;
                }
            }
            setnull();
            hienthi("");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMacv.Text == "")
            {
                MessageBox.Show("Chọn hàng cần xóa!!!");
                return;
            }
            else
            {
                try
                {
                    ec.MaChucVu = txtMacv.Text;
                    ChucVuDAO.Instances.XoaChucVu(ec);
                    MessageBox.Show("Thực hiện thành công!!!");

                }
                catch
                {
                    MessageBox.Show("Lỗi!!!");
                    return;
                }
            }
            setnull();
            hienthi("");
        }

        private void dgChucvu_MouseClick(object sender, MouseEventArgs e)
        {
            txtMacv.Text = dgChucvu.SelectedRows[0].Cells[0].Value.ToString();
            txtTencv.Text = dgChucvu.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void fPhanChucVu_Load(object sender, EventArgs e)
        {
            setnull();
            hienthi("");
            txtMacv.Enabled = false;
        }

        private void txtTencv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
