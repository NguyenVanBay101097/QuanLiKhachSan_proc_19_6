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
using System.Data.Sql;
using System.Data.SqlClient;

namespace QuanLiKhachSan
{
    public partial class fLogin : Form
    {
        private static string laytenserver;
        public static fLogin instances;
        private static string taiKhoan;
        private static string matKhau;
        public static string tentk { get; set; }
        public fLogin Instances {
            get
            {
                if (instances == null) instances = new fLogin(); return instances;
            }
            set
            {
                instances = value;
            }
        }
       
        public static string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public static string MatKhau { get => matKhau; set => matKhau = value; }
        public static string Laytenserver { get => laytenserver; set => laytenserver = value; }

        public fLogin()
        {
            InitializeComponent();

           
           
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenSV.Text == "")
            {
                MessageBox.Show("Ban Chua Nhap SeverName");
                return;
            }
            Laytenserver = txtTenSV.Text;
            string a = txtDangNhap.Text;
            string b = txtMatKhau.Text;
            TaiKhoan = txtDangNhap.Text;
            MatKhau = txtMatKhau.Text;
            if (kiemtraketnoiok() == false)
            {
                MessageBox.Show("Bạn Đã Nhập Sai Tên Tài Khoản Hoặc Mật Khẩu Hoặc SeverName");
                return;
            }
            if (Login(a,b))
            {
                fManager phanmem = new fManager();               
                this.Hide();
                tentk = txtDangNhap.Text;
                phanmem.ShowDialog();                   
                this.Show();
              
            }
            else
            {
                MessageBox.Show("Bạn Đã Nhập Sai Tên Tài Khoản Hoặc Mật Khẩu");
            }
            
        }
        bool kiemtraketnoiok()
        {
            string sever = Laytenserver;
            string id = TaiKhoan;
            string matkhau = MatKhau;
            string ConnectSTR = @"Server=" + @sever + ";Database=QuanLiKhachSan;User Id=" + id + ";Password =" + matkhau;
            SqlConnection connection = new SqlConnection(ConnectSTR);
            try
            {
                connection.Open();
            }
            catch
            {
                
                connection.Close();
                return false;
            }
            return true;
        }
        bool Login(string tentaikhoan,string matkhau)
        {

            return TaiKhoanDAO.Instance.Login(tentaikhoan, matkhau);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;    
            }
        }
      
    }
}
