using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiKhachSan.DTO;

namespace QuanLiKhachSan.DAO
{
    public class KhachHangDAO_huy
    {
        private static KhachHangDAO_huy instances;

        public static KhachHangDAO_huy Instances { get {
                if (instances == null) instances = new KhachHangDAO_huy();return instances;
            } set => instances = value; }
        public KhachHangDAO_huy() { }
        public bool ThemKhachHangVaoDanhSach(string tenKH, string gioiTinh, DateTime ngaySinh, string diaChi, int soDienThoai,string cmt)
        {
            string query = "execute ThemKhachHangVaoDanhSach @TENKH , @GIOITINH , @NGAYSINH , @DIACHI , @SODIENTHOAI , @CHUNGMINHTHU";
            DataProvider.Instance.ExecuteQuery(query,new object[] {  tenKH,  gioiTinh,  ngaySinh,  diaChi,  soDienThoai,cmt });
            return true;
        }
        public bool SuaKhachHangVaoDanhSach(string makh,string tenKH, string gioiTinh, DateTime ngaySinh, string diaChi, int soDienThoai, string cmt)
        {
            string query = "execute SuaKhachHang @makh , @TENKH , @GIOITINH , @NGAYSINH , @DIACHI , @SODIENTHOAI , @CHUNGMINHTHU";
            DataProvider.Instance.ExecuteQuery(query, new object[] {makh, tenKH, gioiTinh, ngaySinh, diaChi, soDienThoai, cmt });
            return true;
        }
        public KhachHang_huy TimKHTheoMAKH(string maKH)
        {
            string query = "execute TimKH @id";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { maKH });
            if (dataTable.Rows.Count == 0) return null;
            KhachHang_huy khachHang_Huy = new KhachHang_huy(dataTable.Rows[0]);
            return khachHang_Huy;
        }
        public KhachHang_huy TimKHTheoCMND(string CMNDKH)
        {
            string query = "execute TimKHTheoCMND @cmnd";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { CMNDKH });
            if (dataTable.Rows.Count == 0) return null;
            KhachHang_huy khachHang_Huy = new KhachHang_huy(dataTable.Rows[0]);
            return khachHang_Huy;
        }
    }
}
