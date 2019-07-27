using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
  public  class KHACHHANG
    {
      public string MAKH	           {get;set;}
      public  string TENKH	           {get;set;}
      public string GIOITINH	           {get;set;}
      public DateTime  NGAYSINH	       {get;set;}
      public string  DIACHI	           {get;set;}
      public string SODIENTHOAI { get; set; }
      public string CMND { get; set; }
    //public KHACHHANG(string makh,string tenkh, bool gioitinh, DateTime ngaysinh, string diachi, string sodienthoai)
    //  {
    //      this.MAKH = makh;
    //      this.TENKH = tenkh;
    //      this.GIOITINH = gioitinh;
    //      this.NGAYSINH = ngaysinh;
    //      this.DIACHI = diachi;
    //      this.SODIENTHOAI = sodienthoai;
    //  }
       public KHACHHANG(DataRow row)
       {
           this.MAKH = row["MAKH"].ToString();
           this.TENKH = row["TENKH"].ToString();
           this.GIOITINH =row["GIOITINH"].ToString();
           this.NGAYSINH = (DateTime)row["NGAYSINH"];
           this.DIACHI = row["DIACHI"].ToString();
           this.SODIENTHOAI = row["SODIENTHOAI"].ToString();
           this.CMND = row["CHUNGMINHTHU"].ToString();
       }
    }
   
}
