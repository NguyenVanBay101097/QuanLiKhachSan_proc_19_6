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
    public partial class fDatPhong : Form
    {
        public fDatPhong()
        {
            InitializeComponent();
         
        }

        private void LoadDanhSachDatPhongVaocbb()
        {
            List<DatPhong> danhsachdatphong = DatPhongDAO.Instances.HienThiDanhSachDatPhongVaocbb();
            cbbMaDatPhong.DataSource = danhsachdatphong;
            cbbMaDatPhong.DisplayMember = "MaDatPhong";
        }

       
        private void LoadTenPhongTheoLoaiPhong(string maLoaiPhong)
        {
            List<Phong> danhsachphongtheoma = PhongDAO.Instances.LoadDanhSachTheoMavaTinhTrang(maLoaiPhong);
            cbbChonPhong.DataSource = danhsachphongtheoma;
            txtGiaPhong.Text = (cbbChonPhong.SelectedItem as Phong).GiaPhong.ToString();

            cbbChonPhong.DisplayMember = "MA";

        }
        private void LoadLoaiPhongVaocbb()
        {
            List<LoaiPhong> danhsachloaiphong = LoaiPhongDAO.Instances.DanhSachLoaiPhong();
            cbbLoaiPhong.DataSource = danhsachloaiphong;
            cbbLoaiPhong.DisplayMember = "TenLoaiPhong";



        }

        private void LoadDanhSachThongKeTinhTrangPhong()
        {
            flpThongKe.Controls.Clear();

            List<TableHienThiThongKeTinhTrangPhong> DanhSachThongKe = PhongDAO.Instances.LoadDanhSachThongKePhong();
            foreach (var item in DanhSachThongKe)
            {
                Button hienthithongke = new Button() { Height = 70, Width = 90 };
                flpThongKe.Controls.Add(hienthithongke);
                flpThongKe.AutoScroll = true;
                int a = 10;

                if (item.TinhTrangPhong == 1)
                {
                    hienthithongke.Text = "Phòng Trống" + " Số Lượng " + item.SoLuong.ToString();
                    hienthithongke.BackColor = Color.White;
                }
                if (item.TinhTrangPhong == 2)
                {
                    hienthithongke.Text = "Phòng được đặt ở tương lai \n Số Lượng:" + item.SoLuong.ToString();

                    hienthithongke.BackColor = Color.Red;
                }
                if (item.TinhTrangPhong == 3)
                {
                    hienthithongke.Text = "Phòng Có Người Đặt \n Hoặc Đang Ở \n Số Lượng:" + item.SoLuong.ToString();

                    hienthithongke.BackColor = Color.LightSlateGray;
                }
            }
        }

        private void LoadDanhSachPhong()
        {
            List<Phong> danhSachPhongs = PhongDAO.Instances.LoadDanhSach();
            grVDanhSachPhong.DataSource = danhSachPhongs;

        }

        private void LoadDanhSachDatPhong()
        {


            List<DatPhong> danhsachdatphong = DatPhongDAO.Instances.HienThiDanhSachDatPhong();
            grVDatPhong.DataSource = danhsachdatphong;

        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenKh = txtTenKhachHang.Text;
            string gioiTinh = "";
            string cmt = txtCMT.Text;
            KhachHang_huy khachHang = KhachHangDAO_huy.Instances.TimKHTheoCMND(txtCMT.Text);
            if (khachHang != null)
            {
                MessageBox.Show("Đã Tồn Tại CMT " + txtCMT.Text + " Trong Hệ Thống");
                return;
            }
            if (chkBNam.Checked)
            {
                gioiTinh = "Nam";
            }
            if (chkNu.Checked)
            {
                gioiTinh = "Nu";
            }
            DateTime ngaySinh = dateTimePicker1.Value;
            string diaChi = txtDiaChi.Text;
            int a = 10;
            int soDienThoai = 0;
            if (int.TryParse(txtSoDienThoai.Text, out a))
            {
                soDienThoai = int.Parse(txtSoDienThoai.Text);


            }
            else
            {

                MessageBox.Show("bạn phải nhập số điện thoại đúng dạng số");
                return;
            }
            if (KhachHangDAO_huy.Instances.ThemKhachHangVaoDanhSach(tenKh, gioiTinh, ngaySinh, diaChi, soDienThoai, cmt))
            {
                MessageBox.Show("Lưu Khách Hàng " + tenKh + " thành công");
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

        private void cbbChonPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGiaPhong.Clear();
            txtGiaPhong.Text = (cbbChonPhong.SelectedItem as Phong).GiaPhong.ToString();

        }

       
        private string maphong;
        private void LoadPhongVaocbbPhong(int b, string maloaiphong)
        {

            List<Phong> danhsachphongtheoloaiphong = PhongDAO.Instances.LoadDanhSachTheoMaLoaiPhong(maloaiphong);
            List<Phong> danhsachphongtheomaphong = PhongDAO.Instances.LoadDanhSachTheoMaPhong(maphong);
            txtGiaPhong.Text = danhsachphongtheomaphong[0].GiaPhong.ToString();
            cbbChonPhong.DataSource = danhsachphongtheoloaiphong;
            cbbChonPhong.SelectedIndex = b;
            cbbChonPhong.DisplayMember = "MA";

        }
        private void LoadLoaiPhongVaocbbLoaiPhong(int a)
        {
            List<LoaiPhong> danhsachloaiphong = LoaiPhongDAO.Instances.DanhSachLoaiPhong();

            cbbLoaiPhong.DataSource = danhsachloaiphong;
            cbbLoaiPhong.SelectedIndex = a;
            cbbLoaiPhong.DisplayMember = "TENLOAIPHONG";
        }
        private int TimKiemLoaiPhongVuaChon(string maphong, string maloaiphong)
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

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            KhachHang_huy khachHang = KhachHangDAO_huy.Instances.TimKHTheoCMND(txtBChungMinhThu.Text);
            if (khachHang == null)
            {
                MessageBox.Show("Bạn chưa lưu thông tin khách hàng có số chứng minh " + txtBChungMinhThu.Text);
                return;
            }
            string maKH = khachHang.MaKH;
            string maPhong = (cbbChonPhong.SelectedItem as Phong).MA;
            float a = 100;
            float traTruoc;
            
            
            DateTime ngayDi;
            DateTime ngayO = dtpNgayO.Value.Date;
            ngayO.Date.ToString("MM/dd/yyyy");
            if (dtpNgayDi.Value == dtpNgayDi.MaxDate)
            {
                ngayDi = dtpNgayDi.MaxDate;
                ngayDi.Date.ToString("");
            }
            else
            {
                ngayDi = dtpNgayDi.Value.Date;
                ngayDi.Date.ToString("MM/dd/yyyy");
            }
            if (DateTime.Compare(ngayO, ngayDi) > 0)
            {
                MessageBox.Show("Ngày Đi Không Được Phép Nhỏ Hơn Ngày Ở");
                return;
            }
            if (DateTime.Compare(ngayO.Date, DateTime.Now.Date) < 0)
            {
                MessageBox.Show("Bạn không thể đặt phòng tại 1 thời điểm ở quá khứ");
                return;
            }
            if (float.TryParse(txtTraTruoc.Text, out a) == false)
            {
                MessageBox.Show("Bạn Phải Chọn Ngày Đi Ít Nhất 1 Lần");
                return;
            }
            traTruoc = float.Parse(txtTraTruoc.Text);

            List<DatPhong> danhsachcacphongdangduocgiu = DatPhongDAO.Instances.HienThiDanhSachDatPhongCoCacPhongDuocGiu();
            foreach (var item in danhsachcacphongdangduocgiu)
            {
                if (item.MaPhong == (cbbChonPhong.SelectedItem as Phong).MA)
                {
                    if (dtpNgayO.Value.Date >= item.NgayO.Date && dtpNgayO.Value.Date <= item.NgayDi.Value.Date
                        || dtpNgayDi.Value.Date >= item.NgayO.Date && dtpNgayDi.Value.Date <= item.NgayDi.Value.Date
                        )
                    {
                        MessageBox.Show("Phòng đã bị sử dụng vào thời gian " + item.NgayO.Date + " Tới " + item.NgayDi.Value.Date);
                        return;
                    }
                }
            }

            if (dtpNgayO.Value.Date == DateTime.Now.Date && dtpNgayDi.Value.Date == dtpNgayDi.MaxDate.Date)
            {
                DatPhongDAO.Instances.ThemDatPhongOLien(maPhong, maKH, traTruoc, ngayO, ngayDi);
                MessageBox.Show("Đã Đăng Kí, Ở Luôn Và Chưa Biết Ngày Đi");
                LoadDanhSachDatPhong();
                LoadDanhSachPhong();
                LoadTenPhongTheoLoaiPhong((cbbLoaiPhong.SelectedItem as LoaiPhong).MA);
                LoadDanhSachDatPhongVaocbb();
                return;
            }
            
            if (dtpNgayO.Value.Date >= DateTime.Now.Date)
            {
                if (dtpNgayO.Value.Date != DateTime.Now.Date && dtpNgayDi.Value.Date == dtpNgayDi.MaxDate)
                {
                    MessageBox.Show("Bạn Không Thể Giữ Phòng Khi Không Xác Định Ngày Đi");
                    return;
                }
                DatPhongDAO.Instances.ThemDatPhongVaGiuPhong(maPhong, maKH, traTruoc, ngayO, ngayDi);
                MessageBox.Show("Đã đăng kí và Giữ Phòng");
                LoadDanhSachDatPhong();
                LoadDanhSachPhong();
                LoadTenPhongTheoLoaiPhong((cbbLoaiPhong.SelectedItem as LoaiPhong).MA);
                LoadDanhSachDatPhongVaocbb();
                return;
            }
        }

        private void dtpNgayDi_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan tinhngay;
            float a;
            if (dtpNgayDi.Value.Date == dtpNgayDi.MaxDate)
            {
                a = (cbbChonPhong.SelectedItem as Phong).GiaPhong * 30 / 100*5;
                txtTraTruoc.Clear();
                txtTraTruoc.Text = a.ToString();
                return;
            }
            if (dtpNgayDi.Value.Date == dtpNgayO.Value.Date)
            {
                a = (cbbChonPhong.SelectedItem as Phong).GiaPhong*30/100;
                txtTraTruoc.Clear();
                txtTraTruoc.Text = a.ToString();
                    return;
            }
            if (dtpNgayDi.Value.Date > dtpNgayO.Value.Date)
            {
                tinhngay = dtpNgayDi.Value.Date - dtpNgayO.Value.Date;
                a = ((cbbChonPhong.SelectedItem as Phong).GiaPhong * tinhngay.Days) * 30 / 100;
                txtTraTruoc.Clear();
                txtTraTruoc.Text = a.ToString();
            }
        }
        private bool KiemTraPhaiKhachHangVoiMaDPTuongUng(string maKH,string maDP)
        {
            List<DatPhong> datPhongs = DatPhongDAO.Instances.HienThiDanhSachDatPhong(maDP);
            foreach (var item in datPhongs)
            {
                if (item.MaKH == maKH)
                {
                    return true;
                }
            }
            return false;
        }

        private bool KiemTraTrungPhong(string MaPhong, string maDP,string maDV,DateTime NgayO,DateTime NgayDi)
        {
            List<DatPhong> datPhongs = DatPhongDAO.Instances.HienThiDanhSachDatPhong(maDP);
            foreach (var item in datPhongs)
            {
                if (item.MaPhong == MaPhong)
                {
                    return true;
                }
            }
            return false;
        }
        private bool KiemTraDungNgayO(DateTime ngayO, string maDP)
        {
            List<DatPhong> datPhongs = DatPhongDAO.Instances.HienThiDanhSachDatPhong(maDP);
            foreach (var item in datPhongs)
            {
                if (item.NgayO.Date == ngayO.Date)
                {
                    return true;
                }
            }
            return false;
        }
       
       

        private void btnXoaDatPhong_Click(object sender, EventArgs e)
        {
            if (cbbMaDatPhong.Items.Count == 0)
            {
                MessageBox.Show("Chưa Có Mã Đặt Phòng Nào Được Tạo");
                return;
            }
            MessageBox.Show("Bạn Đã Xóa Đặt Phòng Có Mã " + (cbbMaDatPhong.SelectedItem as DatPhong).MaDatPhong);
            DatPhongDAO.Instances.XoaToanBoDatPhongTheoMaDatPhong((cbbMaDatPhong.SelectedItem as DatPhong).MaDatPhong);
            LoadDanhSachDatPhong();
            LoadDanhSachPhong();
            LoadDanhSachDatPhongVaocbb();
        }

        private void grVDatPhong_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<DatPhong> danhsachdatphong = DatPhongDAO.Instances.HienThiDanhSachDatPhong();
            int i = 0;
            foreach (var item in danhsachdatphong)
            {
                grVDatPhong.Rows[i].Tag = item;
                i++;
            }

            foreach (DataGridViewRow item in grVDatPhong.Rows)
            {
                DatPhong datPhong = item.Tag as DatPhong;
                if (item.Selected)
                {
                    foreach (var item1 in cbbMaDatPhong.Items)
                    {
                        if (datPhong.MaDatPhong == (item1 as DatPhong).MaDatPhong)
                        {
                            cbbMaDatPhong.SelectedItem = item1;
                        }
                    }
                    if (datPhong.NgayDi.ToString() == "")
                        dtpNgayDi.Value = dtpNgayDi.MaxDate;
                    else
                    {
                        dtpNgayDi.Value = (DateTime)datPhong.NgayDi;
                    }
                    dtpNgayO.Value = datPhong.NgayO;
                    maphong = datPhong.MaPhong;
                    Phong phong = PhongDAO.Instances.LoadPhongTheoMaPhong(datPhong.MaPhong);
                    int IndexLoaiPhong = TimKiemLoaiPhongVuaChon(phong.MA, phong.MaLoaiPhong);
                    int IndexPhong = TimKiemPhongVuaChon(phong.MA, phong.MaLoaiPhong);
                    LoadLoaiPhongVaocbbLoaiPhong(IndexLoaiPhong);
                    LoadPhongVaocbbPhong(IndexPhong, phong.MaLoaiPhong);
                    txtTraTruoc.Text = datPhong.TraTruoc.ToString();

                    //for (int b = 0; b < cbbDichVu.Items.Count; b++)
                    //{
                    //    DichVu dichVu = cbbDichVu.Items[b] as DichVu;
                    //    if (dichVu.MaDV == datPhong.MaDV)
                    //        cbbDichVu.SelectedIndex = b;
                    //}
                    //txtSoPhan.Text = datPhong.SoLuong.ToString();
                    KhachHang_huy khachHang_Huy = KhachHangDAO_huy.Instances.TimKHTheoMAKH(datPhong.MaKH);
                    txtBChungMinhThu.Text = khachHang_Huy.ChungMinhThu;
                }
            }
        }

        public void fDatPhong_Load(object sender, EventArgs e)
        {
            LoadDanhSachDatPhong();
            LoadDanhSachPhong();
            LoadDanhSachThongKeTinhTrangPhong();
            LoadLoaiPhongVaocbb();

            LoadDanhSachDatPhongVaocbb();
        }
    }
}
