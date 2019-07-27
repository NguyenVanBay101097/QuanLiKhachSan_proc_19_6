using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
   public class EC_LichLamViec
    {
        private string _MaLichLamViec;
        private DateTime _NgayLamViec;
        private string _Buoi;
        private string _MaNhanVien;

        public string MaLichLamViec { get => _MaLichLamViec; set => _MaLichLamViec = value; }
        public DateTime NgayLamViec { get => _NgayLamViec; set => _NgayLamViec = value; }
        public string Buoi { get => _Buoi; set => _Buoi = value; }
        public string MaNhanVien { get => _MaNhanVien; set => _MaNhanVien = value; }
    }
}
