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
    public partial class fCongNoTraPhong : Form
    {
        public fCongNoTraPhong()
        {
            InitializeComponent();
            LoadCongNo();
        }

        public void LoadCongNo()
        {
            string query = "execute CongNo";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            grvCongNo.DataSource = dataTable;
        }

        private void txtTimKiemCongNo_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemCongNo.Text == "")
            {
                LoadCongNo();
                return;
            }
                string query = "execute TimCongNo @cmt";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query,new object[] {txtTimKiemCongNo.Text });
            grvCongNo.DataSource = dataTable;
        }
    }
}
