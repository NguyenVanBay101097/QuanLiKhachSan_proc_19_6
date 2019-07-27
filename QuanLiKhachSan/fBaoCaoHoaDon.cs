using QuanLiKhachSan.DAO;
using QuanLiKhachSan.DTO;
using QuanLiKhachSan.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLiKhachSan
{
    public partial class fBaoCaoHoaDon : Form
    {


        public static fBaoCaoHoaDon instances;
        private int a = 0;
        private int tienphong;
        private int tiendv;

        private string maHD;
        private string maPH;
        private List<string> lISTMAHD;
        public string funData //mã hóa đơn được truyền
        {
            get { return maHD; }
            set { maHD = value; }
        }

        public static fBaoCaoHoaDon Instances
        {
            get
            {
                if (instances == null) instances = new fBaoCaoHoaDon(); return instances;
            }
            set => instances = value;
        }

        public string MaPH { get => maPH; set => maPH = value; }
        public List<string> LISTMAHD { get => lISTMAHD; set => lISTMAHD = value; }

        public void EnableInhoadon(bool a) // enable theo hóa đơn
        {

            btnThanhToan.Enabled = !a;

            btnInhoadon.Enabled = a;


        }
        public fBaoCaoHoaDon()
        {
            InitializeComponent();

            dtpkNgayThanhToan.Value = DateTime.Now;
            EnableInhoadon(false);

        }

        private void fBaoCaoHoaDon_Load(object sender, EventArgs e)
        {
            KHACHHANG kh = null;
            if (LISTMAHD != null)
            {
                kh = CTHD.TimKH_tuMAHD(LISTMAHD[0]);
                DataTable tp = new DataTable();
                DataTable tdv = new DataTable();
                
               
                foreach (var item in LISTMAHD)
                {
                    MaPH = CTHD.TimMDP(CTHD.TimCTHD_tuMAHD(item).Rows[0]["MADATPHONG"].ToString()).Rows[0]["MAPHONG"].ToString();
                    tp.Merge( CTHD.ttTienPhong_tuMADP(CTHD.TimMDP_tuMAHD(item)));
                    tdv.Merge(CTHD.ttTienDV_tuMADP(CTHD.TimMDP_tuMAHD(item)));
                    a += int.Parse(CTHD.TimMDP(CTHD.TimCTHD_tuMAHD(item).Rows[0]["MADATPHONG"].ToString()).Rows[0]["TRATRUOC"].ToString());
                }
                grvTienPhong.DataSource = tp;
                grvTTDV.DataSource = tdv;
                EnableInhoadon(true);
            }
            if (funData != null)

            {
                lblMahd.Text = funData;

                kh = CTHD.TimKH_tuMAHD(funData);
                MaPH = CTHD.TimMDP(CTHD.TimCTHD_tuMAHD(funData).Rows[0]["MADATPHONG"].ToString()).Rows[0]["MAPHONG"].ToString();
                grvTienPhong.DataSource = CTHD.ttTienPhong_tuMADP(CTHD.TimMDP_tuMAHD(funData));
                grvTTDV.DataSource = CTHD.ttTienDV_tuMADP(CTHD.TimMDP_tuMAHD(funData));
                a = int.Parse(CTHD.TimMDP(CTHD.TimCTHD_tuMAHD(funData).Rows[0]["MADATPHONG"].ToString()).Rows[0]["TRATRUOC"].ToString());
                EnableInhoadon(true);
            }
            if(funData==null&& LISTMAHD==null)
            {
                kh = CTHD.TimKH_tuMAPHONG(MaPH);
                grvTienPhong.DataSource = CTHD.ttTienPhong(MaPH);
                grvTTDV.DataSource = CTHD.ttTienDV(MaPH);
                a = int.Parse((CTHD.TimMDP_tuMAPH(MaPH).Rows[0]["TRATRUOC"].ToString()));
            }
            
            LoadTTKH(kh);

            LoadTTTien();







        }
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        private void LoadTTTien()// load thông tin tiền
        {


            tiendv = 0;

            tienphong = 0;
            foreach (DataGridViewRow item in grvTienPhong.Rows)
            {
                tienphong += Convert.ToInt32(item.Cells[5].Value);
            }
            foreach (DataGridViewRow item in grvTTDV.Rows)
            {
                tiendv += Convert.ToInt32(item.Cells[4].Value);
            }

            lblTienPhong.Text = tienphong.ToString("#,###", cul.NumberFormat) + "(VNĐ)";
            if (tiendv != 0) lblTienDV.Text = tiendv.ToString("#,###", cul.NumberFormat) + "(VNĐ)"; else lblTienDV.Text = "0.000(VNĐ)";
            lblTongTien.Text = (tienphong + tiendv).ToString("#,###", cul.NumberFormat) + "(VNĐ)";

            if (a != 0) lblTratruoc.Text = a.ToString("#,###", cul.NumberFormat) + "(VNĐ)"; else lblTratruoc.Text = "0.000(VNĐ)";
            lblConlai.Text = ((tienphong + tiendv) - a).ToString("#,###", cul.NumberFormat) + "(VNĐ)";
        }

        private void LoadTTKH(KHACHHANG kh)//load thông tin khách hàng
        {


            lblMaKH.Text = kh.MAKH;
            lblHoTen.Text = kh.TENKH;
            lblGioiTinh.Text = kh.GIOITINH.ToString();
            lblNgaySinh.Text = kh.NGAYSINH.ToString("dd/MM/yyyy");
            lblCMND.Text = kh.CMND;
            lblDiaChi.Text = kh.DIACHI;
            lblSDT.Text = kh.SODIENTHOAI;
        }

        private void btnThanhToan_Click(object sender, EventArgs e) // event thanh toán
        {

            HOADON.ThemHD(dtpkNgayThanhToan.Value.ToString("yyyy-MM-dd"), lblMaKH.Text, CTHD.TimNV().manv, tienphong.ToString(), tiendv.ToString());

            CTHD.ThemCTHD(HOADON.TimMAHDVuaTao(), CTHD.TimMDP_tuMAPH(MaPH).Rows[0]["MADATPHONG"].ToString(), " ko có gì");

        //    CTHD.UpdateDP(CTHD.TimMDP_tuMAPH(MaPH).Rows[0]["MADATPHONG"].ToString());
         //   CTHD.UpdatePhong(MaPH);
            lblMahd.Text = HOADON.TimMAHDVuaTao();
            InHoaDon();
            MessageBox.Show("đã thanh toán thành công");

            this.Close();

        }

        private void InHoaDon() //hàm in hóa đơn
        {
            printPreviewDialog1.Document = printDocument1;
            //            printPreviewDialog1.PrintPreviewControl.AutoZoom = false;
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();
            this.Close();
        }




        private void btnInhoadon_Click(object sender, EventArgs e) //event in hóa đơn
        {
            InHoaDon();
            // this.Close();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image img = Resources.hoadon;
            e.Graphics.DrawImage(img, 260, 0, img.Width, img.Height);
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToShortDateString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(20, img.Height - 30));
            e.Graphics.DrawString("Khách Hàng: " + lblHoTen.Text, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(20, img.Height + 10));
            e.Graphics.DrawString("Hóa Đơn: " + lblMahd.Text, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(650, img.Height + 10));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------"
               , new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(20, img.Height + 40));
            e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN", new Font("Arial", 15, FontStyle.Bold), Brushes.OrangeRed, new Point(280, img.Height + 60));
            //vẽ thông tin phòng
            e.Graphics.DrawString("STT", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20, img.Height + 100));
            e.Graphics.DrawString("Phòng", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(90, img.Height + 100));
            e.Graphics.DrawString("Giá(VNĐ)", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(190, img.Height + 100));
            e.Graphics.DrawString("Ngày Ở", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(300, img.Height + 100));
            e.Graphics.DrawString("Ngày Đi", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(420, img.Height + 100));
            e.Graphics.DrawString("Số Ngày Ở", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(537, img.Height + 100));
            e.Graphics.DrawString("Thành Tiền(VNĐ)", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(690, img.Height + 100));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------"
              , new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(20, img.Height + 120));

            int y = img.Height + 150;
            for (int i = 0; i < grvTienPhong.Rows.Count; i++)
            {
                e.Graphics.DrawString((i + 1).ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(20, y));

                e.Graphics.DrawString(grvTienPhong.Rows[i].Cells[0].Value.ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(90, y));
                e.Graphics.DrawString((int.Parse(grvTienPhong.Rows[i].Cells[1].Value.ToString())).ToString("#,###", cul.NumberFormat), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(190, y));
                e.Graphics.DrawString(DateTime.Parse(grvTienPhong.Rows[i].Cells[2].Value.ToString()).ToShortDateString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(300, y));
                e.Graphics.DrawString(DateTime.Parse(grvTienPhong.Rows[i].Cells[3].Value.ToString()).ToShortDateString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(420, y));
                e.Graphics.DrawString(grvTienPhong.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(540, y));
                e.Graphics.DrawString(int.Parse(grvTienPhong.Rows[i].Cells[5].Value.ToString()).ToString("#,###", cul.NumberFormat), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(690, y));
                y += 30;

            }
            y += 40;
            //vẽ thông tin dịch vụ
            e.Graphics.DrawString("STT", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20, y));
            e.Graphics.DrawString("Dịch Vụ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(120, y));
            e.Graphics.DrawString("Số Lượng", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(290, y));
            e.Graphics.DrawString("Ngày sử dụng", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(410, y));
            e.Graphics.DrawString("giá(VNĐ)", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(542, y));
            e.Graphics.DrawString("Thành Tiền(VNĐ)", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(690, y));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------"
                  , new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(20, y += 20));//y=y+20  set
            y += 30;
            for (int i = 0; i < grvTTDV.Rows.Count; i++)
            {
                e.Graphics.DrawString((i + 1).ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(20, y));

                e.Graphics.DrawString(grvTTDV.Rows[i].Cells[0].Value.ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(120, y));
                e.Graphics.DrawString(grvTTDV.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(300, y));
                e.Graphics.DrawString(DateTime.Parse(grvTTDV.Rows[i].Cells[2].Value.ToString()).ToShortDateString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(415, y));
                e.Graphics.DrawString((int.Parse(grvTTDV.Rows[i].Cells[3].Value.ToString())).ToString("#,###", cul.NumberFormat), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(545, y));
                e.Graphics.DrawString(int.Parse(grvTTDV.Rows[i].Cells[4].Value.ToString()).ToString("#,###", cul.NumberFormat), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(690, y));
                y += 30;

            }
            e.Graphics.DrawString("--------------------------------------------------------------------------------"
                  , new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(400, y += 20));//y=y+20  set
            //vẽ thông tin tiền
            e.Graphics.DrawString("Tiền Phòng: " + lblTienPhong.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(400, y += 40));
            e.Graphics.DrawString("Tiền Dịch Vụ: " + lblTienDV.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(400, y += 40));
            e.Graphics.DrawString("Tổng Tiền: " + lblTongTien.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(400, y += 40));
            e.Graphics.DrawString("Trả Trước: " + lblTratruoc.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(400, y += 40));
            e.Graphics.DrawString("Còn Lại: " + lblConlai.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(400, y += 40));
            e.Graphics.DrawString("Cảm ơn và hẹn gặp lại!!!", new Font("Arial", 14, FontStyle.Regular), Brushes.Orange, new Point(400, y += 35));






        }
    }
}
