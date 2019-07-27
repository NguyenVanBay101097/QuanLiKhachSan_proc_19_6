using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
    class HOADONDTO
    {
          public string MAHD	           {get;set;}
      public  DateTime NGAYTHANHTOAN	           {get;set;}
      public string MAKH	           {get;set;}
      public string  MANHANVIEN	           {get;set;}
      public float TIENPHONG { get; set; }
      public float TIENDV { get; set; }
   
       public HOADONDTO(DataRow row)
       {
           this.MAHD = row["MAHD"].ToString();
           this.NGAYTHANHTOAN =(DateTime) row["NGAYTHANHTOAN"];
           this.MAKH = row["MAKH"].ToString();
           this.MANHANVIEN = row["MANHANVIEN"].ToString();
           this.TIENPHONG = (float)row["TIENPHONG"];
           this.TIENPHONG = (float)row["TIENDV"];
       }
    }
}
