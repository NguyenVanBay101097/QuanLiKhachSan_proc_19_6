using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLiKhachSan.DAO
{
   public class HOADON
    {
        //public string MAHD { get; set; }
        //public DateTime NGAYTHANHTOAN { get; set; }
        //public string MAKH { get; set; }
        //public string MANHANVIEN { get; set; }
       public static DataTable dSMAHD()
       {
           return DAO.DataProvider.Instance.ExecuteQuery("exec dbo.dsMAHD_bay");
       }
       public static DataTable getHD()
       {
           return DAO.DataProvider.Instance.ExecuteQuery("exec dbo.getHD");
       }
        public static DataTable getHD(string date1, string date2)
        {
            return DAO.DataProvider.Instance.ExecuteQuery("exec dbo.getHD_date1_date2 @date1='"+date1+"', @date2='"+date2+"'");
        }
        public static DataTable TimHD(string mahd)
        {
            string query = "exec [dbo].[TimHD] @mahd";
           return DataProvider.Instance.ExecuteQuery(query, new object[] { mahd});
        }
        
        public static int ThemHD(string date,string makh, string manv,string tienphong,string tiendv)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery("exec dbo.themHD_bay @date='"+date+"',@makh='"+makh+"',@manv='"+manv+"',@tienphong="+tienphong+",@tiendv="+tiendv+"");
        }
        public static string TimMAHDVuaTao()
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("exec dbo.TimMAHDVuaTao_bay");
            return dt.Rows[0]["MAHD"].ToString();
        }
      public static string NgayThanhToanMoiNhat()
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("exec dbo.NgayThanhToanMoiNhat_bay");
            return dt.Rows[0]["NGAYTHANHTOAN"].ToString();
        }
       //xoa hoadon
       public static int DeleteHD(string mahd)
      {
          return DataProvider.Instance.ExecuteNonQuery("exec dbo.DeleteHD_mahd_bay @mahd='"+mahd+"'");
      }
    }
}
