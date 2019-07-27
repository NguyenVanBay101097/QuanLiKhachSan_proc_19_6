using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLiKhachSan.DTO;
namespace QuanLiKhachSan.DAO
{
   public class CTHD
    {
       
      
        public static DataTable TimMDP(string maDP)
        {
            return DAO.DataProvider.Instance.ExecuteQuery("exec dbo.TimMDP_madp @madp='"+maDP+"'");
        }
        public static DataTable TimMDP_tuMAPH(string maPH)
        {
            return DAO.DataProvider.Instance.ExecuteQuery("exec dbo.TimMDP_tuMAPH @maPH='"+maPH+"'");
        }
          public static DataTable TimMDP_tuMAPH_tuonglai(string maPH)
        {
            return DAO.DataProvider.Instance.ExecuteQuery("select * from DatPhong where MAPHONG='"+maPH+"' and TrangThaiThanhToan=0 and NGAYO>GETDATE()");
        }
        public static DataTable TimCTHD_tuMAHD(string maHD)
        {
            return DAO.DataProvider.Instance.ExecuteQuery("exec dbo.TimCTHD_tuMAHD @maHD='"+maHD+"'");
        }
      
        public static DataTable DSCTHD_FromMHD(string maHD)
        {
            return DAO.DataProvider.Instance.ExecuteQuery("exec dbo.DSCTHD_FromMHD @maHD='"+maHD+"'");
        }
       
       public static string TimMDP_tuMAHD(string mahd)
       {
           DataTable dt = DataProvider.Instance.ExecuteQuery("exec dbo.TimMDP_tuMAHD @mahd='"+mahd+"'");
           return dt.Rows[0]["MADATPHONG"].ToString();
       }
       
       public static int UpdatePhong(string maphong)
       {
           return DAO.DataProvider.Instance.ExecuteNonQuery("exec dbo.UpdatePhong_bay @maph='"+maphong+"'");
       }
        //thông tin phòng và tiền phòng
        public static DataTable ttTienPhong_tuMADP(string maDP)
        {
            return DAO.DataProvider.Instance.ExecuteQuery("exec dbo.ttTienPhong_tuMADP @madp='"+maDP+"'");
        }
        public static DataTable ttTienPhong(string maPH)
       {
           return DAO.DataProvider.Instance.ExecuteQuery("exec dbo.ttTienPhong @maph='"+maPH+"'");
       }
      
      
       //thông tin dịch vụ và tiền dịch vụ
       public static DataTable ttTienDV(string maPH)
       {
           return DAO.DataProvider.Instance.ExecuteQuery("select TENDV [Dịch Vụ],SoLuong [Số Lượng],ngayDung [Ngày Sử Dụng], giadichvuhientai [Giá], (giadichvuhientai*SoLuong) [Thành Tiền] from DatDichVu ddv join DICHVU dv on dv.MADV = ddv.madv join DatPhong dp on dp.MADATPHONG = ddv.madp where MAPHONG = '"+maPH+"' and TrangThaiThanhToan = 0");
       }
        public static DataTable ttTienDV_tuMADP(string maDP)
        {
            return DAO.DataProvider.Instance.ExecuteQuery("select TENDV [Dịch Vụ],SoLuong [Số Lượng],ngayDung [Ngày Sử Dụng], giadichvuhientai [Giá], (giadichvuhientai*SoLuong) [Thành Tiền] from DatDichVu ddv join DICHVU dv on dv.MADV = ddv.madv  where madp='"+maDP+"'");
        }

       
      
        public  static  KHACHHANG TimKH(string makh)//tìm khách khàng
        {


            DataTable dt = DataProvider.Instance.ExecuteQuery("exec dbo.TimKH @id='"+makh+"'");

            KHACHHANG kh = new KHACHHANG(dt.Rows[0]);
            return kh;
        }
        public static KHACHHANG TimKH_tuMAHD(string maHD)//tìm khách khàng
        {


            DataTable dt = DataProvider.Instance.ExecuteQuery("exec dbo.TimKH_tuMAHD @mahd='"+maHD+"'");

            KHACHHANG kh = new KHACHHANG(dt.Rows[0]);
            return kh;
        }
        public static KHACHHANG TimKH_tuMAPHONG(string maPhong)//tìm khách khàng từ mã phòng
        {


            DataTable dt = DataProvider.Instance.ExecuteQuery("exec dbo.TimKH_tuMAPHONG @maph='"+maPhong+"'");

            KHACHHANG kh = new KHACHHANG(dt.Rows[0]);
            return kh;
        }

      
       public static NHANVIEN TimNV()//tìm nhân viên
       {
           DataTable dt = DataProvider.Instance.ExecuteQuery("select * from TAIKHOAN where TENTAIKHOAN='"+fLogin.tentk+"'");
           NHANVIEN nv = new NHANVIEN(dt.Rows[0]);
           return nv;
       }
      
       public static int ThemCTHD(string mahd,string madp,string ghichu)
       {
           return DAO.DataProvider.Instance.ExecuteNonQuery("exec dbo.ThemCTHD @mahd='"+mahd+"',@madp='"+madp+"',@ghichu='"+ghichu+"'");
       }
      
       //update trang thai thanh toan của dat phong và ngày đi
       public static int UpdateDP(string madp)
       {
           return DataProvider.Instance.ExecuteNonQuery("exec dbo.UpdateDP @madp='"+madp+"'");
       }
      //xóa chitiethoadon
       public static int DeleteCTHD(string mahd)
       {
           return DataProvider.Instance.ExecuteNonQuery("exec dbo.DeleteCTHD @mahd='"+mahd+"'");
       }
       //xoa datphong
       public static int DeleteDatPhong(string madatphong)
       {
           return DataProvider.Instance.ExecuteNonQuery("exec dbo.DeleteDatPhong @madp='"+madatphong+"'");
       }
        public static int DeleteDatDV(string maDP)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec dbo.DeleteDatDV @madp='"+maDP+"'");
        }
    }
}
