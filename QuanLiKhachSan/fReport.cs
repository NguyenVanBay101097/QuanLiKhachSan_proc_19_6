using QuanLiKhachSan.DAO;
using QuanLiKhachSan.DTO;
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
    public partial class fReport : Form
    {
        public fReport()
        {
            InitializeComponent();


        }
        private string maHD;


        public string MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        private string maKH;


        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private string maPhong;
        public string MaPhong
        {
            get { return maPhong; }
            set { maPhong = value; }
        }
        private string maDatPhong;
        public string MaDatPhong
        {
            get { return maDatPhong; }
            set { maDatPhong = value; }
        }
        private string ngayTT;
        public string NgayTT
        {
            get { return ngayTT; }
            set { ngayTT = value; }
        }
        private string traTruoc;
        public string TraTruoc
        {
            get { return traTruoc; }
            set { traTruoc = value; }
        }
        public static DataTable dttbTP { get; set; }
        public static DataTable dttbTDV { get; set; }
        public static KHACHHANG kh;
        private void fReport_Load(object sender, EventArgs e)
        {
          
            grvTienPhong.DataSource = dttbTP;
            grvTTDV.DataSource = dttbTDV;
            kh = CTHD.TimKH(MaKH);
            LoadTTKH(kh);
            LoadTTTien();
            lblNgaytt.Text = NgayTT;
            lblMahd.Text = MaHD;
            lblMadp.Text = "madap";

            this.reportViewer1.RefreshReport();

           // groupBox3.Height = (grvTienPhong.RowCount) * grvTienPhong.RowTemplate.Height * 2;
           // groupBox4.Height = (grvTTDV.RowCount) * grvTTDV.RowTemplate.Height * 2;

        }
        private void LoadTTKH(KHACHHANG kh)
        {


            lblMaKH.Text = kh.MAKH;
            lblHoTen.Text = kh.TENKH;
            lblGioiTinh.Text = kh.GIOITINH.ToString();
            lblNgaySinh.Text = kh.NGAYSINH.ToString("dd/MM/yyyy");
            lblCMND.Text = kh.CMND;
            lblDiaChi.Text = kh.DIACHI;
        }
        private void LoadTTTien()
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

            int tienphong = 0;
            int tiendv = 0;
            foreach (DataGridViewRow item in grvTienPhong.Rows)
            {
                tienphong += Convert.ToInt32(item.Cells[5].Value);
            }
            foreach (DataGridViewRow item in grvTTDV.Rows)
            {
                tiendv += Convert.ToInt32(item.Cells[4].Value);
            }
            lblTienthuephong.Text = tienphong.ToString("#,###", cul.NumberFormat) + "(VNĐ)";
            if (tiendv != 0) lblTiendichvu.Text = tiendv.ToString("#,###", cul.NumberFormat) + "(VNĐ)"; else lblTiendichvu.Text = "0.000(VNĐ)";
            lblTongtien.Text = (tienphong + tiendv).ToString("#,###", cul.NumberFormat) + "(VNĐ)";
            lblTratruoc.Text = int.Parse(traTruoc).ToString("#,###", cul.NumberFormat) + "VNĐ";
            lblConlai.Text = ((tienphong + tiendv) - int.Parse(traTruoc)).ToString("#,###", cul.NumberFormat) + "(VNĐ)";
        }



    }
}
   