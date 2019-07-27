using QuanLiKhachSan.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiKhachSan
{
    public partial class fHoaDonDichVu : Form
    {
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        public fHoaDonDichVu()
        {
            
            InitializeComponent();
         
        }

        private void LoadHD()
        {
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            foreach (DataRow item in HOADON.dSMAHD().Rows)
            {
                acsc.Add(item["MAHD"].ToString());
            }
            txtTK.AutoCompleteCustomSource = acsc;
            dataGridView2.DataSource = HOADON.getHD();

            LoadDoanhThu();
        }


        private int LoadDoanhThu()
        {

            int doanhthu = 0;

            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                doanhthu += Convert.ToInt32(item.Cells[6].Value);
            }
            if (doanhthu == 0)
                lblDoanhThu.Text = "0 (VNĐ)";
            else lblDoanhThu.Text = doanhthu.ToString("#,###", cul.NumberFormat) + "(VNĐ)";
            return doanhthu;
        }

        public void fHoaDonDichVu_Load(object sender, EventArgs e)
        {
            dateTimePicker3.Value = DateTime.Today;
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            foreach (DataRow item in HOADON.dSMAHD().Rows)
            {
                acsc.Add(item["MAHD"].ToString());
            }
            txtTK.AutoCompleteCustomSource = acsc;
            LoadHD();
            if (dataGridView2.Rows.Count > 0)
                dateTimePicker1.Value = DateTime.Parse(HOADON.NgayThanhToanMoiNhat());
            dataGridView2.Columns["chon"].Width = 30;
            dataGridView2.ReadOnly = false;
            dataGridView2.Columns[1].ReadOnly = true;
            dataGridView2.Columns[2].ReadOnly = true;
            dataGridView2.Columns[3].ReadOnly = true;
            dataGridView2.Columns[4].ReadOnly = true;
            dataGridView2.Columns[5].ReadOnly = true;
            dataGridView2.Columns[6].ReadOnly = true;

            if (CTHD.TimNV().machucvu != "CV0002")
            {
                btnXoa.Visible = false;
                dataGridView2.Columns["chon"].Visible = false;
            }
            //vcl cai loi nay ma t tim sang gio 8 tieng hoi , xóa delege xem sao, ben t binh thuong m de yen t doc cai loi
            // loi lien quan toi truy xuat du lieu

            txtTK.Text = "nhập mã mã hóa đơn...!";
            Changebackgroundcolor_rowodd();
        }



        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtTK.Text == "nhập mã mã hóa đơn...!")
            {
                txtTK.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtTK.Text == "")
            {
                txtTK.Text = "nhập mã mã hóa đơn...!";
                txtTK.ForeColor = Color.Gray;
            }
        }



        private void btnXem_Click(object sender, EventArgs e)
        {

            dataGridView2.DataSource = HOADON.getHD(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker3.Value.ToString("yyyy-MM-dd"));
            LoadDoanhThu();
            Changebackgroundcolor_rowodd();
        }


        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }

            string maHD = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            fBaoCaoHoaDon fm = new fBaoCaoHoaDon();
            fm.funData = maHD;
            
            fm.ShowDialog();
            
          
            
        }


        private void btnTK_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = HOADON.TimHD(txtTK.Text.Trim());
            LoadDoanhThu();
            txtTK.Text = null;
        }

        private void dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnXem_Click(this, new EventArgs());
            }

        }

        private void txtTK_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btnTK_Click(this, new EventArgs());
            }
        }



        private void btnInhoadon_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count==0)
            {
                return;
            }
            string maHD = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[1].Value.ToString();
            fBaoCaoHoaDon fm = new fBaoCaoHoaDon();
            if(dataGridView2.SelectedRows.Count==1) 
            fm.funData = maHD;
            else
            {
                List<string> lst = new List<string>();
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    if (item.Selected) lst.Add(item.Cells[1].Value.ToString());
                }
                fm.LISTMAHD = lst;
            }
            fm.ShowDialog();
            fm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            fm.EnableInhoadon(true);


        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Changebackgroundcolor_rowodd();
        }

        private void Changebackgroundcolor_rowodd()
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHD();
            Changebackgroundcolor_rowodd();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                if (Convert.ToBoolean(item.Cells["chon"].Value) == true)
                {
                    foreach (DataRow r in CTHD.DSCTHD_FromMHD(item.Cells[1].Value.ToString()).Rows)
                    {
                        CTHD.DeleteDatDV(r["Mã đặt phòng"].ToString());
                        CTHD.DeleteDatPhong(r["Mã đặt phòng"].ToString());
                    }
                    CTHD.DeleteCTHD(item.Cells[1].Value.ToString());
                    HOADON.DeleteHD(item.Cells[1].Value.ToString());


                }
            }
            LoadHD();
            Changebackgroundcolor_rowodd();

        }






    }
}
