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
using QuanLiKhachSan.DAO;
using QuanLiKhachSan.DTO;

namespace QuanLiKhachSan
{
    public partial class fPhanCongLichLamViec : Form
    {
        List<string> listManv = new List<string>();
        EC_LichLamViec ec = new EC_LichLamViec();
        public fPhanCongLichLamViec()
        {
            InitializeComponent();
        }

        public void hienthi(string dieukien)
        {
            daLichlamviec.DataSource = LichLamViecDAO.Instances.Taobang(dieukien);
        }
        public void setnull()
        {
            txtMalichlamviec.Text = "";
            cbMaNV.Text = "";
            cbBuoi.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMalichlamviec.Text = "";
            List<EC_LichLamViec> list = new List<EC_LichLamViec>();
            string query = "SELECT NGAYLAMVIEC, BUOI FROM LICHLAMVIEC WHERE MANHANVIEN = '"+cbMaNV.Text+"'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                ec.NgayLamViec = Convert.ToDateTime(dt.Rows[j]["NGAYLAMVIEC"].ToString().Trim());
                ec.Buoi = dt.Rows[j]["BUOI"].ToString().Trim();
                list.Add(ec);
            }
            EC_LichLamViec[] lamViec;
            lamViec = list.ToArray();
            if (cbMaNV.Text == "" || cbBuoi.Text ==""||dtNgaylamviec.Text=="")
            {
                MessageBox.Show("Nhập đầy đủ thông tin!!!");
                return;
            }
            else
            {
                foreach (EC_LichLamViec item in lamViec)
                {
                    if (item.NgayLamViec == dtNgaylamviec.Value && item.Buoi == cbBuoi.Text)
                    {
                        MessageBox.Show("Ngày này đã có buổi tương ứng!");
                        return;
                    }
                }
                try
                {
                    ec.MaNhanVien = cbMaNV.Text;
                    ec.Buoi = cbBuoi.Text;
                    ec.NgayLamViec = dtNgaylamviec.Value;
                    LichLamViecDAO.Instances.ThemLichLamViec(ec);
                    MessageBox.Show("thực hiện thành công!!!");
                }
                catch
                {
                    MessageBox.Show("lỗi!!!");
                    return;
                }
                setnull();
                hienthi("");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            List<EC_LichLamViec> list = new List<EC_LichLamViec>();
            string query = "SELECT NGAYLAMVIEC, BUOI FROM LICHLAMVIEC WHERE MANHANVIEN = '" + cbMaNV.Text + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                ec.NgayLamViec = Convert.ToDateTime(dt.Rows[j]["NGAYLAMVIEC"].ToString().Trim());
                ec.Buoi = dt.Rows[j]["BUOI"].ToString().Trim();
                list.Add(ec);
            }
            EC_LichLamViec[] lamViec2;
            lamViec2 = list.ToArray();
            if (cbMaNV.Text == "")
            {
                MessageBox.Show("Chọn mã nhân viên!!!");
                return;
            }
            else
            {
                try
                {
                    foreach (EC_LichLamViec item in lamViec2)
                    {
                        if (item.NgayLamViec == dtNgaylamviec.Value && item.Buoi == cbBuoi.Text)
                        {
                            MessageBox.Show("Ngày này đã có buổi tương ứng!");
                            return;
                        }
                    }
                    ec.MaLichLamViec = txtMalichlamviec.Text;
                    ec.MaNhanVien = cbMaNV.Text;
                    ec.Buoi = cbBuoi.Text;
                    ec.NgayLamViec = dtNgaylamviec.Value;
                    LichLamViecDAO.Instances.SuaLichLamViec(ec);
                    MessageBox.Show("thực hiện thành công!!!");
                }
                catch
                {
                    MessageBox.Show("lỗi!!!");
                    return;
                }
                setnull();
                hienthi("");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtMalichlamviec.Text == "")
            {
                MessageBox.Show("Nhập hoặc chọn mã nhân viên!!!");
                return;
            }
            else
            {
                try
                {
                    ec.MaLichLamViec = txtMalichlamviec.Text;
                    LichLamViecDAO.Instances.XoaLichLamViec(ec);
                    MessageBox.Show("Thực hiện thành công!!!");
                }
                catch
                {
                    MessageBox.Show("Lỗi!!!");
                    return;
                }
                setnull();
                hienthi("");
            }
        }

        private void daLichlamviec_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMalichlamviec.Text = daLichlamviec.SelectedRows[0].Cells[2].Value.ToString();
            //string s= daLichlamviec.SelectedRows[0].Cells[3].Value.ToString();
            cbBuoi.Text = daLichlamviec.SelectedRows[0].Cells[1].Value.ToString();
            dtNgaylamviec.Text = daLichlamviec.SelectedRows[0].Cells[0].Value.ToString();
            string query = "select MANHANVIEN FROM LICHLAMVIEC WHERE MALICHLAMVIEC='" + daLichlamviec.SelectedRows[0].Cells[2].Value.ToString() + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            txtMalichlamviec.Enabled = false;
            cbMaNV.Text = dt.Rows[0]["MANHANVIEN"].ToString().Trim();
        }

        public void fPhanCongLichLamViec_Load(object sender, EventArgs e)
        {
            hienthi("");
            txtMalichlamviec.Enabled = false;
            string query = "SELECT MANHANVIEN FROM  NHANVIEN";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                cbMaNV.Items.Add(dt.Rows[i]["MANHANVIEN"].ToString().Trim());
            }

        }

        private void cbMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtBuoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
