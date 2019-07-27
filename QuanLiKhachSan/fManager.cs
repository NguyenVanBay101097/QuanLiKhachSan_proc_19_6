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


namespace QuanLiKhachSan
{
    public partial class  fManager : Form
    {
       static Image closeImage, closeImageAct;
         

        public fManager()
        {
            InitializeComponent();
            AddTabPages(fDatPhong);
        }
       
        private static fManager instances;
       
       
        private void tabHienThitiep_DrawItem(object sender, DrawItemEventArgs e )
        {
            
            Rectangle rect = tabHienThi.GetTabRect(e.Index);
            Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width, rect.Top + (rect.Height - closeImage.Height) / 2,
                closeImage.Width, closeImage.Height);
            rect.Size = new Size(rect.Width + 24, 38);
            //chon tab
            Font f;
            Brush br = Brushes.Black;
            StringFormat strF = new StringFormat(StringFormat.GenericDefault);
            if (tabHienThi.SelectedTab == tabHienThi.TabPages[e.Index])
            {
                
                f = new Font("Arial", 10, FontStyle.Underline);
                
            }
            else
            {
                e.Graphics.DrawImage(closeImage, imageRec);
                f = new Font("Arial", 10, FontStyle.Regular);
                e.Graphics.DrawString(tabHienThi.TabPages[e.Index].Text, f, br, rect, strF);
            }
            
        }
        
        public void  AddTabPages(Form frm)
        {
            int t = KTFormTonTai(frm);
            if (t >= 0)
            {
                if (tabHienThi.SelectedTab == tabHienThi.TabPages[t])
                {
                    MessageBox.Show("form da duoc chon");
                }
                else {
                    tabHienThi.SelectedTab = tabHienThi.TabPages[t];
                   
                };
                
            }
            else //them tab moi
            {
                TabPage newTab = new TabPage(frm.Text.Trim());
                tabHienThi.TabPages.Add(newTab);
                frm.TopLevel = false;
                TabPage a = tabHienThi.SelectedTab;
                frm.Parent = newTab;
                tabHienThi.SelectedTab = tabHienThi.TabPages[tabHienThi.TabCount - 1];
                frm.Show();
                frm.Dock = DockStyle.Fill;
            }
        }
             private int KTFormTonTai(Form frm)
        {
            for(int i=0;i<tabHienThi.TabCount;i++)
            {
                if (tabHienThi.TabPages[i].Text == frm.Text.Trim())
                    return i;
               
            }
            return -1;
        }

        private static fDanhSachNhanVien fDanhSachNhanVien=new fDanhSachNhanVien();
        private void theeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPages(fDanhSachNhanVien);
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       

        private void tabHienThi_DrawItem(object sender, DrawItemEventArgs e=null)
        {
            Rectangle rect = tabHienThi.GetTabRect(e.Index);
            Rectangle imageRec = new Rectangle(rect.Right-closeImage.Width,rect.Top+(rect.Height-closeImage.Height)/2,
                closeImage.Width,closeImage.Height);
            rect.Size = new Size(rect.Width + 24, 38);
            //chon tab
            Font f;
            Brush br = Brushes.Black;
            StringFormat strF = new StringFormat(StringFormat.GenericDefault);
            if(tabHienThi.SelectedTab==tabHienThi.TabPages[e.Index])
            {
                e.Graphics.DrawImage(closeImageAct, imageRec);
                f = new Font("Arial", 10, FontStyle.Underline);
                e.Graphics.DrawString(tabHienThi.TabPages[e.Index].Text, f, br, rect,strF);
            }
            else
            {
                e.Graphics.DrawImage(closeImage, imageRec);
                f = new Font("Arial", 10, FontStyle.Regular);
                e.Graphics.DrawString(tabHienThi.TabPages[e.Index].Text, f, br, rect, strF);
            }
            
        }
       
        String macv;

        public static fManager Instances { get {
                if (instances == null) instances = new fManager(); return instances;
            } set => instances = value; }

        public object a { get; private set; }
       

        public void tao()
        {
            string query = "SELECT MACHUCVU FROM TAIKHOAN  WHERE TENTAIKHOAN='" + fLogin.TaiKhoan + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            macv = dt.Rows[0]["MACHUCVU"].ToString().Trim();
        }


        private void fManager_Load(object sender, EventArgs e)
        {
            tao();
            if (macv != "CV0002")
            {
                adminToolStripMenuItem.Visible = false;
            }
            Size mysize = new System.Drawing.Size(10, 17);
            Bitmap bt = new Bitmap(Properties.Resources.close);
            Bitmap btm = new Bitmap(bt, mysize);
            closeImageAct = btm;
            //
            Bitmap bt2 = new Bitmap(Properties.Resources.closeBlack);
            Bitmap btm2 = new Bitmap(bt2, mysize);
            closeImage = btm2;
            tabHienThi.Padding = new Point(30);
           
        }


        private static fThongTinTaiKhoan fThongTinTaiKhoan = new fThongTinTaiKhoan();
        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPages(fThongTinTaiKhoan);
        }
        private static fSoDoPhong fSoDoPhong = new fSoDoPhong();
        private static fDatPhong fDatPhong=new fDatPhong();
        private void btnSoDoPhong_Click(object sender, EventArgs e)
        {
            AddTabPages(fSoDoPhong);
        }
        private static fCongNoTraPhong fCongNoTraPhong = new fCongNoTraPhong();

        private void btnCongNo_Click(object sender, EventArgs e)
        {
            AddTabPages(fCongNoTraPhong);
        }
        private static fHoaDonDichVu fHoaDonDichVu = new fHoaDonDichVu();

        private void btnHoaDonDichVu_Click(object sender, EventArgs e)
        {
            AddTabPages(fHoaDonDichVu);
        }
        private static fThongTinKhach fThongTinKhach = new fThongTinKhach();
        private void btnThôngTinKhach_Click(object sender, EventArgs e)
        {
            AddTabPages(fThongTinKhach);
        }
        private static fBaoCaoHoaDon fBaoCaoHoaDon = new fBaoCaoHoaDon();
        private void btnBaoCaoHoaDon_Click(object sender, EventArgs e)
        {
            
            AddTabPages(fBaoCaoHoaDon);
           
        }
        private fLichLamViec fLichLamViec = new fLichLamViec();
        private void btnLichLamViec_Click(object sender, EventArgs e)
        {
            AddTabPages(fLichLamViec);
        }

        private void lichLamViêcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPages(fPhanCongLichLamViec);
        }

        private void thoatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private static fPhanChucVu fPhanChucVu = new fPhanChucVu();
        private void phânChưcVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPages(fPhanChucVu);
        }
        private static fPhanCongLichLamViec fPhanCongLichLamViec = new fPhanCongLichLamViec();
        private void phânLichLamViêcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPages(fPhanCongLichLamViec);
            
        }

        private void tabHienThi_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabHienThi.TabCount; i++)
            {
                Rectangle rect = tabHienThi.GetTabRect(i);
                Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width, rect.Top + (rect.Height - closeImage.Height) / 2,
                    closeImage.Width, closeImage.Height);
                if (imageRec.Contains(e.Location))
                    tabHienThi.TabPages.Remove(tabHienThi.SelectedTab);
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void tabHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            fSoDoPhong.fSoDoPhong_Load(fSoDoPhong, e);
            fDatPhong.fDatPhong_Load(fDatPhong, e);
            fCongNoTraPhong.LoadCongNo();
            fDatDichVu.fDatDichVu_Load(fDatDichVu, e);
            fHoaDonDichVu.fHoaDonDichVu_Load(fHoaDonDichVu, e);
            fLichLamViec.hienthi();
            fDanhSachNhanVien.fDanhSachNhanVien_Load(fDanhSachNhanVien,e);
            fPhanCongLichLamViec.fPhanCongLichLamViec_Load(fPhanCongLichLamViec, e);
            fThongTinKhach.fThongTinKhach_Load(fThongTinKhach, e);
        }
        private static fDatDichVu fDatDichVu = new fDatDichVu();
        private void btnDatDichVu_Click(object sender, EventArgs e)
        {
            AddTabPages(fDatDichVu);
           
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            AddTabPages(fDatPhong);
            
        }
    }
}
