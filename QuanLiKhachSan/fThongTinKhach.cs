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
    public partial class fThongTinKhach : Form
    {
        EC_KHACHHANG ec = new EC_KHACHHANG();
        public fThongTinKhach()
        {
            InitializeComponent();
        }
        string insert = "execute ThemKhachHangVaoDanhSach @TENKH , @GIOITINH , @NGAYSINH , @DIACHI , @SODIENTHOAI , @CHUNGMINHTHU";
        string select = "select * from KHACHHANG";
        public void hienthi()
        {
            try
            {
                daKH.DataSource = KhachHangDAO_thinh.Instances.Taobang(select);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void setnull()
        {
            txtMaKH.Text = "";
            txtTenkh.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
            cbGioitinh.Text = "";
            txtCMT.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            List<string> MyList = new List<string>();
            int rows = daKH.Rows.Count;
            for(int i =0 ; i < daKH.Rows.Count-1; i++)
            {              
                        MyList.Add(daKH.Rows[i].Cells[6].Value.ToString());              
            }
            if (MyList.Any(item => item == txtCMT.Text)==true)
            {
                MessageBox.Show("Số chứng minh thư đã tồn tại, mời nhập lại!!!");
                return;
            }
            else
            if (txtTenkh.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin!!!");
                return;
            }
            else
            {
                try
                {
                    ec.Ngaysinh = dtNgaysinh.Value.Date;
                    ec.SDT = txtSDT.Text;
                    ec.TenKH = txtTenkh.Text;
                    ec.GioiTinh = cbGioitinh.Text;
                    ec.DiaChi = txtDiachi.Text;
                    ec.SOCMT = txtCMT.Text;
                    KhachHangDAO_thinh.Instances.ThemKhachHangVaoDanhSach(ec,insert);//??                   
                    MessageBox.Show("Thực hiện thành công!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            setnull();
            hienthi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }

        private void Xoa()
        {
           
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Chọn mã nhân viên!!!");
                return;
            }
            else
            {
                try
                {
                    if(rbtnMatdlcn.Checked==true)
                    {
                        ec.MaKH = txtMaKH.Text;
                        KhachHangDAO_thinh.Instances.XoaKhachHang(ec);
                        MessageBox.Show("Thực hiện thành công!!!");
                    }
                    if (rbtnFixMatdl.Checked==true) { 
                    if (DAO.KhachHangDAO_huy.Instances.TimKHTheoMAKH(txtMaKH.Text) == null)
                    {
                        MessageBox.Show("khách hàng này đã được xóa bởi user khác!");
                    }


                    else
                    {
                        ec.MaKH = txtMaKH.Text;
                        KhachHangDAO_thinh.Instances.XoaKhachHang(ec);
                        MessageBox.Show("Thực hiện thành công!!!");
                    }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            setnull();
            hienthi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtMaKH.Text == "")
            {
                MessageBox.Show("Chọn hàng cần sửa!!!");
                return;
            }
            else
            {
                try
                {
                    ec.Ngaysinh = dtNgaysinh.Value.Date;
                    ec.MaKH = txtMaKH.Text;
                    ec.SDT = txtSDT.Text;
                    ec.TenKH = txtTenkh.Text;
                    ec.GioiTinh = cbGioitinh.Text;
                    ec.DiaChi = txtDiachi.Text;
                    ec.SOCMT = txtCMT.Text;
                    KhachHangDAO_thinh.Instances.SuaKhachHangVaoDanhSach(ec);
                    MessageBox.Show("Thực hiện thành công!!!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,"Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
            }
            hienthi();
            setnull();
        }


        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void daKH_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMaKH.Text = daKH.SelectedRows[0].Cells[0].Value.ToString();
            txtTenkh.Text = daKH.SelectedRows[0].Cells[1].Value.ToString();
            dtNgaysinh.Text = daKH.SelectedRows[0].Cells[3].Value.ToString();
            cbGioitinh.Text = daKH.SelectedRows[0].Cells[2].Value.ToString();
            txtSDT.Text = daKH.SelectedRows[0].Cells[5].Value.ToString();
            txtDiachi.Text = daKH.SelectedRows[0].Cells[4].Value.ToString();
            txtCMT.Text = daKH.SelectedRows[0].Cells[6].Value.ToString();
        }

        public void fThongTinKhach_Load(object sender, EventArgs e)
        {
            hienthi();
            txtMaKH.Enabled = false;
        }

        private void txtTenkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void cbGioitinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtDiachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void daKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = daKH.SelectedRows[0].Cells[0].Value.ToString();
            txtTenkh.Text = daKH.SelectedRows[0].Cells[1].Value.ToString();
            dtNgaysinh.Text = daKH.SelectedRows[0].Cells[3].Value.ToString();
            cbGioitinh.Text = daKH.SelectedRows[0].Cells[2].Value.ToString();
            txtSDT.Text = daKH.SelectedRows[0].Cells[5].Value.ToString();
            txtDiachi.Text = daKH.SelectedRows[0].Cells[4].Value.ToString();
            txtCMT.Text = daKH.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void rbDocDuLieuRac_CheckedChanged(object sender, EventArgs e)
        {
            insert = "execute ThemKhachHang_thinh @TENKH , @GIOITINH , @NGAYSINH , @DIACHI , @SODIENTHOAI , @CHUNGMINHTHU";
            select = "set tran isolation level read uncommitted select * from KHACHHANG";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            select = "set tran isolation level read committed select * from KHACHHANG";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
                hienthi();

        }

        private void rbFix_Repeatable_CheckedChanged(object sender, EventArgs e)
        {
            select = "execute hienthikhachhang_Fix_Repeatable";
        }

        private void rbRepeatable_read_CheckedChanged(object sender, EventArgs e)
        {
            select = "execute hienthikhachhang_Repeatable";
        }

        private void rb_Bong_ma_CheckedChanged(object sender, EventArgs e)
        {
            insert = "execute ThemKhachHangVaoDanhSach @TENKH , @GIOITINH , @NGAYSINH , @DIACHI , @SODIENTHOAI , @CHUNGMINHTHU"; 
            select = "execute hienthikhachhang_bongma";
        }

        private void rFix_bong_ma_CheckedChanged(object sender, EventArgs e)
        {
            insert = "execute ThemKhachHangVaoDanhSach @TENKH , @GIOITINH , @NGAYSINH , @DIACHI , @SODIENTHOAI , @CHUNGMINHTHU";
            select = "execute hienthikhachhang_fix_bongma";
        }
    }
}
