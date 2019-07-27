using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiKhachSan.DTO;
using System.Data.SqlClient;

namespace QuanLiKhachSan.DAO
{
    public class KhachHangDAO_thinh
    {
        private static KhachHangDAO_thinh instances;

        public static KhachHangDAO_thinh Instances { get {
                if (instances == null) instances = new KhachHangDAO_thinh();return instances;
            } set => instances = value; }
        public KhachHangDAO_thinh() { }
        public bool ThemKhachHangVaoDanhSach(EC_KHACHHANG ec, string insert)
        {
            string query = insert;
            DataProvider.Instance.ExecuteQuery(query,new object[] {  ec.TenKH,ec.GioiTinh,ec.Ngaysinh,ec.DiaChi,ec.SDT,ec.SOCMT });
            return true;
        }
        public DataTable Taobang(string Dieukien)
        {

            string query = Dieukien;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            return dt;
        }
        public bool XoaKhachHang(EC_KHACHHANG ec)
        {
            string query = "execute XoaKhachHang @Makh";
            DataProvider.Instance.ExecuteQuery(query, new object[] { ec.MaKH });
            return true;
        }
        public bool SuaKhachHangVaoDanhSach(EC_KHACHHANG ec)
        {
            string query = " execute SuaKhachHang @makh , @TENKH , @GIOITINH , @NGAYSINH , @DIACHI , @SODIENTHOAI , @CHUNGMINHTHU ";
            DataProvider.Instance.ExecuteQuery(query, new object[] {ec.MaKH,ec.TenKH,ec.GioiTinh,ec.Ngaysinh,ec.DiaChi,ec.SDT,ec.SOCMT });
            return true;
        }
    }
}
