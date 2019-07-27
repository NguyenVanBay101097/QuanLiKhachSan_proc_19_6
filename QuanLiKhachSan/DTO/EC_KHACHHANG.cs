using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
   public class EC_KHACHHANG
    {
        private string _MaKH;
        private string _TenKH;
        private DateTime _Ngaysinh;
        private string _GioiTinh;
        private string _DiaChi;
        private string _SDT;
        private string _SOCMT;
        public string MaKH { get => _MaKH; set => _MaKH = value; }
        public string TenKH { get => _TenKH; set => _TenKH = value; }
        public DateTime Ngaysinh { get => _Ngaysinh; set => _Ngaysinh = value; }
        public string GioiTinh { get => _GioiTinh; set => _GioiTinh = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public string SOCMT { get => _SOCMT; set => _SOCMT = value; }
    }
}
