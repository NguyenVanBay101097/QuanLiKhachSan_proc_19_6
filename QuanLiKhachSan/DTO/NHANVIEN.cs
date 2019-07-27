using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
  public  class NHANVIEN
    {
        public string manv { get; set; }
        public string machucvu { get; set; }
      public NHANVIEN(DataRow row)
      {
          this.manv=row["MANHANVIEN"].ToString();
          this.machucvu = row["MACHUCVU"].ToString();
      }
    }
}
