using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
   public class EC_TAIKHOAN
    {
        private string _TenTaiKhoan;
        private string _MatKhau;
        private string _MaChucVu;
        private string _MaNhanVien;

        public string TenTaiKhoan { get => _TenTaiKhoan; set => _TenTaiKhoan = value; }
        public string MatKhau { get => _MatKhau; set => _MatKhau = value; }
        public string MaChucVu { get => _MaChucVu; set => _MaChucVu = value; }
        public string MaNhanVien { get => _MaNhanVien; set => _MaNhanVien = value; }
    }
}
