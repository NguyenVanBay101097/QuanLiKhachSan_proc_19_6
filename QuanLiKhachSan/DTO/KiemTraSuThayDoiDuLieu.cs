using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
    public class KiemTraSuThayDoiDuLieu
    {
        private int chucVu;
        private int datDichVu;
        private int datPhong;
        private int dichVu;
        private int hoaDon;
        private int khachHang;
        private int lichLamViec;
        private int loaiPhong;
        private int nhanVien;
        private int phong;
        private int taiKhoan;
        private int chiTietHoaDon;

        public int ChucVu { get => chucVu; set => chucVu = value; }
        public int DatDichVu { get => datDichVu; set => datDichVu = value; }
        public int DatPhong { get => datPhong; set => datPhong = value; }
        public int DichVu { get => dichVu; set => dichVu = value; }
        public int HoaDon { get => hoaDon; set => hoaDon = value; }
        public int KhachHang { get => khachHang; set => khachHang = value; }
        public int LichLamViec { get => lichLamViec; set => lichLamViec = value; }
        public int LoaiPhong { get => loaiPhong; set => loaiPhong = value; }
        public int NhanVien { get => nhanVien; set => nhanVien = value; }
        public int Phong { get => phong; set => phong = value; }
        public int TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public int ChiTietHoaDon { get => chiTietHoaDon; set => chiTietHoaDon = value; }

        public KiemTraSuThayDoiDuLieu(DataRow row)
        {
            ChiTietHoaDon = int.Parse(row["CHITIETHOADON"].ToString());
            ChucVu = int.Parse(row["CHUCVU"].ToString());
            DatDichVu = int.Parse(row["DatDichVu"].ToString());
            DatPhong = int.Parse(row["DatPhong"].ToString());
            DichVu = int.Parse(row["DichVu"].ToString());
            HoaDon = int.Parse(row["HOADON"].ToString());
            KhachHang = int.Parse(row["KHACHHANG"].ToString());
            LichLamViec = int.Parse(row["LICHLAMVIEC"].ToString());
            LoaiPhong = int.Parse(row["LOAIPHONG"].ToString());
            NhanVien = int.Parse(row["NHANVIEN"].ToString());
            Phong = int.Parse(row["PHONG"].ToString());
            TaiKhoan = int.Parse(row["TAIKHOAN"].ToString());
        }
    }
}
