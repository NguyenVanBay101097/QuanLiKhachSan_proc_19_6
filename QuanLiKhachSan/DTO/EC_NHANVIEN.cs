using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DAO
{
    public  class EC_NHANVIEN
    {
        private string _MaNhanVien;
        private string _TenNhanVien;
        private string _GioiTinh;
        private string _MaChucVu;
        private string _SDT;
        private DateTime _NgaySinh;
        private string _DiaChi;       

        public string MaNhanVien { get => _MaNhanVien; set => _MaNhanVien = value; }
        public string TenNhanVien { get => _TenNhanVien; set => _TenNhanVien = value; }
        public string GioiTinh { get => _GioiTinh; set => _GioiTinh = value; }
        public string MaChucVu { get => _MaChucVu; set => _MaChucVu = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public DateTime NgaySinh { get => _NgaySinh; set => _NgaySinh = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
    }
}