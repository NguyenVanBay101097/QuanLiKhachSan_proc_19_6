using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiKhachSan.DTO;
using System.Data;
namespace QuanLiKhachSan.DAO
{

    public class LichLamViecDAO
    {
        private static LichLamViecDAO instances;
        public LichLamViecDAO() { }
        public static LichLamViecDAO Instances
        {
            get
            {
                if (instances == null) instances = new LichLamViecDAO(); return instances;
            }
            set => instances = value;
        }
        public bool ThemLichLamViec(EC_LichLamViec EC)
        {
            string query = " execute Them_LichlamViec @NGAYLAMVIEC , @BUOI , @MANHANVIEN";
            DataProvider.Instance.ExecuteQuery(query, new object[] { EC.NgayLamViec,EC.Buoi,EC.MaNhanVien });
            return true;
        }
        public bool SuaLichLamViec(EC_LichLamViec EC)
        {
            string query = " execute Sua_LichlamViec @MaLLV , @NGAYLAMVIEC , @BUOI , @MANHANVIEN";
            DataProvider.Instance.ExecuteQuery(query, new object[] {EC.MaLichLamViec ,EC.NgayLamViec, EC.Buoi, EC.MaNhanVien });
            return true;
        }
        public bool XoaLichLamViec(EC_LichLamViec EC)
        {
            string query = " execute Xoa_LichlamViec @ma";
            DataProvider.Instance.ExecuteQuery(query, new object[] { EC.MaLichLamViec });
            return true;
        }
        public DataTable Taobang2(string dieukien)
        { 
            string query = " SELECT  LICHLAMVIEC.NGAYLAMVIEC, LICHLAMVIEC.BUOI, NHANVIEN.TENNHANVIEN FROM NHANVIEN INNER JOIN TAIKHOAN ON NHANVIEN.MANHANVIEN = TAIKHOAN.MANHANVIEN INNER JOIN  LICHLAMVIEC ON NHANVIEN.MANHANVIEN = LICHLAMVIEC.MANHANVIEN WHERE TAIKHOAN.TENTAIKHOAN='" + dieukien + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            return dt;
        }
        public DataTable Taobang(string dieukien)
        {
            string query = " SELECT LICHLAMVIEC.NGAYLAMVIEC, LICHLAMVIEC.BUOI, LICHLAMVIEC.MALICHLAMVIEC , NHANVIEN.TENNHANVIEN FROM  LICHLAMVIEC INNER JOIN NHANVIEN ON LICHLAMVIEC.MANHANVIEN = NHANVIEN.MANHANVIEN" + dieukien ;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            return dt;
        }

    }
}
