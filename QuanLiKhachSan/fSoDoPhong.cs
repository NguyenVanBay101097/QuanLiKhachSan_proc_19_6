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
    public partial class fSoDoPhong : Form
    {
        public fSoDoPhong()
        {
            InitializeComponent();
            
            }
     
        private void LoadTenPhongTheoLoaiPhong(string maLoaiPhong)
        {
            List<Phong> danhsachphongtheoma = PhongDAO.Instances.LoadDanhSachTheoMaLoaiPhong(maLoaiPhong);
            cbbPhong.DataSource = danhsachphongtheoma;
           txtGiaPhong.Text = (cbbPhong.SelectedItem as Phong).GiaPhong.ToString();
            txtDonViTien.Text = (cbbPhong.SelectedItem as Phong).DonViTienTe;
            cbbPhong.DisplayMember = "MA";

        }

        private void LoadLoaiPhongVaocbb()
        {
            List<LoaiPhong> danhsachloaiphong = LoaiPhongDAO.Instances.DanhSachLoaiPhong();
            cbbLoaiPhong.DataSource = danhsachloaiphong;
            cbbLoaiPhong.DisplayMember = "TENLOAIPHONG";
            cbbChonLoaiPhongDeSua.DataSource = danhsachloaiphong;
            cbbChonLoaiPhongDeSua.DisplayMember = "TENLOAIPHONG";
        }
     

        private void LoadLoaiPhongVaocbbLoaiPhong(int a)
        {
            List<LoaiPhong> danhsachloaiphong = LoaiPhongDAO.Instances.DanhSachLoaiPhong();
            
            cbbLoaiPhong.DataSource = danhsachloaiphong;
            cbbLoaiPhong.SelectedIndex = a;
            cbbLoaiPhong.DisplayMember = "TENLOAIPHONG";
        }
        private void LoadDanhSachThongKeTinhTrangPhong()
        {
            flpThongKe.Controls.Clear();
            
            List<TableHienThiThongKeTinhTrangPhong> DanhSachThongKe = PhongDAO.Instances.LoadDanhSachThongKePhong();
            foreach (var item in DanhSachThongKe)
            {
                Button hienthithongke = new Button() { Height=70,Width=90};
                flpThongKe.Controls.Add(hienthithongke);
                if (item.TinhTrangPhong == 1)
                {
                    hienthithongke.Text = "Phòng Trống" + " Số Lượng "+item.SoLuong.ToString();
                    hienthithongke.BackColor = Color.White;
                }
                if (item.TinhTrangPhong == 2)
                {
                    hienthithongke.Text = "Phòng được đặt ở tương lai \n Số Lượng:" + item.SoLuong.ToString();

                    hienthithongke.BackColor = Color.Red;
                }
                if (item.TinhTrangPhong == 3)
                {
                    hienthithongke.Text = "Phòng Có Người Đặt \n Hoặc Đang Ở Số Lượng:" + item.SoLuong.ToString();

                    hienthithongke.BackColor = Color.LightSlateGray;
                }
            }
        }

        private void LoadDanhSach()
        {
            
            flpDanhSachCacPhong.Controls.Clear();
            List<Phong> danhsachPhong = PhongDAO.Instances.LoadDanhSach();
            foreach (var item in danhsachPhong)
            {
                Button nut = new Button() { Width = 100, Height = 100 };
                
                flpDanhSachCacPhong.AutoScroll = true;
                flpDanhSachCacPhong.Controls.Add(nut);
                nut.Tag = item;
                nut.Click += btnclick;
              
                nut.Text = item.MA + "\n" + item.TenPhong;
                if (item.TinhTrangPhong == 1)
                {
                    nut.BackColor = Color.White;
                }
                if (item.TinhTrangPhong == 2)
                {
                    nut.BackColor = Color.Red;
                }
                if (item.TinhTrangPhong == 3)
                {
                    nut.BackColor = Color.LightSlateGray;
                    nut.MouseDown += Nut_MouseDown;
                }
            }
        }

        private void Nut_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks==2)
            {
                fBaoCaoHoaDon fm = new fBaoCaoHoaDon();
                fm.MaPH = ((sender as Button).Tag as Phong).MA;

                fm.ShowDialog();
                LoadDanhSach();
            }
           

        }

        string maphong, maloaiphong;
        private void btnclick(object sender, EventArgs e)
        {

            maphong = ((sender as Button).Tag  as Phong).MA;
            maloaiphong = ((sender as Button).Tag as Phong).MaLoaiPhong;
            LoadThongTinPhong(maphong);
            listVThongTinPhong.Tag = (sender as Button).Tag;
            int a = TimKiemLoaiPhongVuaChon(maphong, maloaiphong);
            int b = TimKiemPhongVuaChon(maphong, maloaiphong);
            
            LoadLoaiPhongVaocbbLoaiPhong(a);
            LoadPhongVaocbbPhong(b, maloaiphong);
        }

      
        private void LoadPhongVaocbbPhong(int b,string maloaiphong)
        { 
            
            List<Phong> danhsachphongtheoloaiphong = PhongDAO.Instances.LoadDanhSachTheoMaLoaiPhong(maloaiphong);
            List<Phong> danhsachphongtheomaphong = PhongDAO.Instances.LoadDanhSachTheoMaPhong(maphong);
            txtGiaPhong.Text = danhsachphongtheomaphong[0].GiaPhong.ToString();
            txtDonViTien.Text = danhsachphongtheomaphong[0].DonViTienTe;
            cbbPhong.DataSource = danhsachphongtheoloaiphong;
            cbbPhong.SelectedIndex = b;
            cbbPhong.DisplayMember = "MA";

        }

        private int TimKiemLoaiPhongVuaChon(string maphong,string maloaiphong)
        {
            int dem = 0;
            List<LoaiPhong> danhsachloaiphong = LoaiPhongDAO.Instances.DanhSachLoaiPhong();
            List<Phong> phong = PhongDAO.Instances.LoadDanhSachTheoMaPhong(maphong);
            for (int i = 0; i < danhsachloaiphong.Count; i++)
            {
                if (danhsachloaiphong[i].MA == phong[0].MaLoaiPhong)
                {
                    dem = i;
                }
            }
            return dem;
        }
        private int TimKiemPhongVuaChon(string maphong, string maloaiphong)
        {
            int dem = 0;
            List<Phong> danhsachphong = PhongDAO.Instances.LoadDanhSachTheoMaLoaiPhong(maloaiphong);
            List<Phong> phong = PhongDAO.Instances.LoadDanhSachTheoMaPhong(maphong);
            
            for (int i = 0; i < danhsachphong.Count; i++)
            {
                if (danhsachphong[i].MA == phong[0].MA)
                {
                    dem = i;
                }
            }
            return dem;
        }
        private void LoadThongTinPhong(string ma)
        {
            listVThongTinPhong.Items.Clear();
            List<Phong> hienthithongtinphong = PhongDAO.Instances.LoadDanhSachTheoMaPhong(ma);
            foreach (var item in hienthithongtinphong)
            {
                ListViewItem listView = new  ListViewItem(item.MA);
                listView.SubItems.Add(item.TenPhong);
                listView.SubItems.Add(item.TinhTrangPhong.ToString());
                listView.SubItems.Add(item.MaLoaiPhong);
                listView.SubItems.Add(item.GiaPhong.ToString());
                listView.SubItems.Add(item.DonViTienTe);
                listVThongTinPhong.Items.Add(listView);
            }
        }
        private void LoadThongTinPhong()
        {
            listVThongTinPhong.Items.Clear();
            List<Phong> hienthithongtinphong = PhongDAO.Instances.LoadDanhSach();
            foreach (var item in hienthithongtinphong)
            {
                ListViewItem listView = new ListViewItem(item.MA);
                listView.SubItems.Add(item.TenPhong);
                listView.SubItems.Add(item.TinhTrangPhong.ToString());
                listView.SubItems.Add(item.MaLoaiPhong);
                listView.SubItems.Add(item.GiaPhong.ToString());
                listView.SubItems.Add(item.DonViTienTe);
                listVThongTinPhong.Items.Add(listView);
            }
        }

        private void cbbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maLoaiPhong;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;
            LoaiPhong loaiPhong = cb.SelectedItem as LoaiPhong;
            maLoaiPhong = loaiPhong.MA;
            LoadTenPhongTheoLoaiPhong(maLoaiPhong);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Phong table = listVThongTinPhong.Tag as Phong;
            string tenPhong = (cbbPhong.SelectedItem as Phong).TenPhong;
            string maLoaiPhong = (cbbLoaiPhong.SelectedItem as LoaiPhong).MA;
            string donViTienTe = txtDonViTien.Text;
            float a;
            var thugiaphong = float.TryParse(txtGiaPhong.Text, out a);
            if (thugiaphong)
            {
                float giaPhong = float.Parse(txtGiaPhong.Text);
                PhongDAO.Instances.insertPhong(tenPhong, maLoaiPhong, giaPhong, donViTienTe);
                LoadDanhSach();
                LoadDanhSachThongKeTinhTrangPhong();
                MessageBox.Show("Thành Công");
            }
            else MessageBox.Show("Bạn Phải Nhập Giá Phòng Kiểu Số");
            
        }

        private void cbbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ma = (cbbPhong.SelectedItem as Phong).MA;
            txtGiaPhong.Clear();
            txtGiaPhong.Text = (cbbPhong.SelectedItem as Phong).GiaPhong.ToString();
            txtDonViTien.Clear();
            txtDonViTien.Text = (cbbPhong.SelectedItem as Phong).DonViTienTe.ToString();
            LoadThongTinPhong(ma);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Phong table = listVThongTinPhong.Tag as Phong;
            string maPhong = (cbbPhong.SelectedItem as Phong).MA;
            string tenPhong = (cbbPhong.SelectedItem as Phong).TenPhong;
            string maLoaiPhong = (cbbChonLoaiPhongDeSua.SelectedItem as LoaiPhong).MA;
            string donViTienTe = txtDonViTien.Text;
            float a;
            var thugiaphong = float.TryParse(txtGiaPhong.Text, out a);
            if (thugiaphong)
            {
                float giaPhong = float.Parse(txtGiaPhong.Text);
                PhongDAO.Instances.UpdatePhong(maPhong,tenPhong, maLoaiPhong, giaPhong, donViTienTe);
                LoadDanhSach();
                LoadThongTinPhong(maPhong);
                LoadDanhSachThongKeTinhTrangPhong();
                
                MessageBox.Show("Thành Công");
            }
            else MessageBox.Show("Bạn Phải Nhập Giá Phòng Kiểu Số");
        }

        private void btnHienThiToanBoDanhSach_Click(object sender, EventArgs e)
        {
            LoadThongTinPhong();
        }

        public void fSoDoPhong_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            LoadLoaiPhongVaocbb();
            LoadDanhSachThongKeTinhTrangPhong();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string maPhong = (cbbPhong.SelectedItem as Phong).MA;
            string loaiPhong = (cbbPhong.SelectedItem as Phong).MaLoaiPhong;

            bool kiemtradexoa = DatPhongDAO.Instances.KiemTraPhongCoTonTaiTrongMaDP(maPhong);
            if (kiemtradexoa) DatPhongDAO.Instances.removeDatPhongTheoMaPhong(maPhong);
            if (maPhong != maphong)
            {
                MessageBox.Show("Ban da xoa Phong " + maPhong);
                PhongDAO.Instances.RemovePhong(maPhong);
            }

            else
            {
                MessageBox.Show("Ban da xoa Phong " + maphong);
                PhongDAO.Instances.RemovePhong(maPhong);
            }
                

            
            LoadTenPhongTheoLoaiPhong(loaiPhong);
            LoadDanhSach();
            LoadThongTinPhong(maPhong);
            LoadDanhSachThongKeTinhTrangPhong();

        }
    }
}
