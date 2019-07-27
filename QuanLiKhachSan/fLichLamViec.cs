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


namespace QuanLiKhachSan
{
    public partial class fLichLamViec : Form
    {

        public fLichLamViec()
        {
            InitializeComponent();
        }
        public void hienthi()
        {
            daLichlamviec.DataSource = LichLamViecDAO.Instances.Taobang2(fLogin.TaiKhoan);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            hienthi();
        }
    }
}
