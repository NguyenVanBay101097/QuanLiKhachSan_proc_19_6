using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
   public class EC_CHUCVU
    {
        private string _MaChucVu;
        private string _TenChucVu;

        public string MaChucVu { get => _MaChucVu; set => _MaChucVu = value; }
        public string TenChucVu { get => _TenChucVu; set => _TenChucVu = value; }
    }
}
