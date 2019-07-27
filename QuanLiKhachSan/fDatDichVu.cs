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
    public partial class fDatDichVu : Form
    {
        public fDatDichVu()
        {
            InitializeComponent();
           

        }

        private void Loaddulieuvaocbb()
        {
            List<DatPhong> danhsachdatphong = DatPhongDAO.Instances.HienThiDanhSachDatPhongChuaThanhToan();
            cbbMaDP.DataSource = danhsachdatphong;
            cbbMaDP.DisplayMember = "MaDatPhong";
            List<DichVu> danhsachdichvu = DichVuDAO.Instances.LoadDanhSachDichVu();
            cbbMaDV.DataSource = danhsachdichvu;
            cbbMaDV.DisplayMember = "TenDV";
        }

        private void LoadDanhSachDatDichVu()
        {
            if (cbbMaDP.SelectedItem == null) return;
            string madatphong = (cbbMaDP.SelectedItem as DatPhong).MaDatPhong;
            List<DatDichVu> danhsachdatdichvu = DichVuDAO.Instances.LoadDanhSachDatDichVu(madatphong);
            grVDatDichVu.DataSource = danhsachdatdichvu;

        }

        private void LoadDanhSachDatPhong()
        {
            List<DatPhong> danhsachdatphong = DatPhongDAO.Instances.HienThiDanhSachDatPhong();
            grVDatPhong.DataSource = danhsachdatphong;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbMaDP.SelectedItem == null)
            {
                MessageBox.Show("Chưa Có Ai Đặt Phòng");
                return;
            }
            List<DatPhong> danhsachdatphong = DatPhongDAO.Instances.HienThiDanhSachDatPhong();
            
            string madatphong = (cbbMaDP.SelectedItem as DatPhong).MaDatPhong;
            List<DatDichVu> danhsachdatdichvu = DichVuDAO.Instances.LoadDanhSachDatDichVu(madatphong);
            string madv = (cbbMaDV.SelectedItem as DichVu).MaDV;
            string tendv = (cbbMaDV.SelectedItem as DichVu).TenDV;
            DateTime ngayDung = dTPNgayDung.Value.Date;
            foreach (DatPhong item in danhsachdatphong)
            {
                if (madatphong == item.MaDatPhong)
                {
                    if (ngayDung < item.NgayO || ngayDung > item.NgayDi)
                    {
                        MessageBox.Show("Ngày Này Phòng Này Chưa Có Người Ở Hoặc Đã Đi Rồi");
                        return;
                    }
                }
            }
            int soLuong = (int)numericUpDown1.Value;
            if (soLuong <= 0)
            {
                MessageBox.Show("Số Lượng Phải Lớn Hơn 0");return;
            }
            foreach (DatDichVu item in danhsachdatdichvu)
            {
                if (item.MaDatPhong == madatphong && item.TenDV == tendv && item.NgayDung.Date == ngayDung.Date)
                {
                    DichVuDAO.Instances.ThemDatDichVuSoLuong(madatphong, madv, soLuong, ngayDung,(cbbMaDV.SelectedItem as DichVu).GiaDV);
                    LoadDanhSachDatPhong();
                    LoadDanhSachDatDichVu();
                    
                    return;
                }
            }
            DichVuDAO.Instances.ThemDatDichVu(madatphong, madv, soLuong, ngayDung,  (cbbMaDV.SelectedItem as DichVu).GiaDV);
            LoadDanhSachDatPhong();
            LoadDanhSachDatDichVu();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cbbMaDP.SelectedItem == null)
            {
                MessageBox.Show("Chưa Có Ai Đặt Phòng");
                return;
            }
            List<DatPhong> danhsachdatphong = DatPhongDAO.Instances.HienThiDanhSachDatPhong();
            
            string madatphong = (cbbMaDP.SelectedItem as DatPhong).MaDatPhong;
            string madv = (cbbMaDV.SelectedItem as DichVu).MaDV;
            string tendv = (cbbMaDV.SelectedItem as DichVu).TenDV;
            List<DatDichVu> danhsachdatdichvu = DichVuDAO.Instances.LoadDanhSachDatDichVu(madatphong);
            DateTime ngayDung = dTPNgayDung.Value.Date;
           
            int soLuong = (int)numericUpDown1.Value;
            if (soLuong <= 0)
            {
                MessageBox.Show("Số Lượng Phải Lớn Hơn 0"); return;
            }
            foreach (DatDichVu item in danhsachdatdichvu)
            {
                if (item.MaDatPhong == madatphong && item.TenDV == tendv && item.NgayDung.Date == ngayDung.Date)
                {
                    DichVuDAO.Instances.SuaDatDichVuSoLuong(madatphong, madv, soLuong, ngayDung,(cbbMaDV.SelectedItem as DichVu).GiaDV);
                    LoadDanhSachDatPhong();
                    LoadDanhSachDatDichVu();
                    
                    return;
                }
            }
            MessageBox.Show("Bạn Phải Chọn Đúng Mã Đặt, Mã Dịch Vụ, Và Ngày Dùng Để Sửa Số Lượng");
            return;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbbMaDP.SelectedItem == null)
            {
                MessageBox.Show("Chưa Có Ai Đặt Phòng");
                return;
            }
            List<DatPhong> danhsachdatphong = DatPhongDAO.Instances.HienThiDanhSachDatPhong();
            
            string madatphong = (cbbMaDP.SelectedItem as DatPhong).MaDatPhong;
            List<DatDichVu> danhsachdatdichvu = DichVuDAO.Instances.LoadDanhSachDatDichVu(madatphong);
            string madv = (cbbMaDV.SelectedItem as DichVu).MaDV;
            string tendv = (cbbMaDV.SelectedItem as DichVu).TenDV;
            DateTime ngayDung = dTPNgayDung.Value.Date;
           
            int soLuong = (int)numericUpDown1.Value;

            foreach (DatDichVu item in danhsachdatdichvu)
            {
                if (item.MaDatPhong == madatphong && item.TenDV == tendv && item.NgayDung.Date == ngayDung.Date)
                {
                    DichVuDAO.Instances.XoaDatDichVuSoLuong(madatphong, madv, soLuong, ngayDung);
                    LoadDanhSachDatPhong();
                    LoadDanhSachDatDichVu();
                    
                    return;
                }
            }
            MessageBox.Show("Bạn Phải Chọn Đúng Mã dp, madv, ngày dùng");
            return;
        }

        private void cbbMaDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNgayDi.Clear();
            txtNgayO.Clear();
            txtNgayO.Text = (cbbMaDP.SelectedItem as DatPhong).NgayO.Date.ToString("dd/MM/yyyy");
            txtNgayDi.Text = (cbbMaDP.SelectedItem as DatPhong).NgayDi.Value.Date.ToString("dd/MM/yyyy");
            LoadDanhSachDatDichVu();
        }

        private void grVDatDichVu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            cbbMaDP.DataBindings.Clear();
            cbbMaDP.DataBindings.Add("Text", grVDatDichVu.DataSource, "MaDatPhong");
            cbbMaDV.DataBindings.Clear();
            cbbMaDV.DataBindings.Add("Text", grVDatDichVu.DataSource, "TenDv");
            numericUpDown1.DataBindings.Clear();
            numericUpDown1.DataBindings.Add("Text", grVDatDichVu.DataSource, "SoLuong");
            dTPNgayDung.DataBindings.Clear();
            dTPNgayDung.DataBindings.Add("Text", grVDatDichVu.DataSource, "ngayDung");
        }

        public void fDatDichVu_Load(object sender, EventArgs e)
        {
            Loaddulieuvaocbb();
            LoadDanhSachDatPhong();
            LoadDanhSachDatDichVu();
        }
    }
}
