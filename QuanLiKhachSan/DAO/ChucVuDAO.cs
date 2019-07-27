using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiKhachSan.DTO;
using System.Data;
namespace QuanLiKhachSan.DAO
{
    public class ChucVuDAO
    {
        private static ChucVuDAO instances;
        public ChucVuDAO() { }
        public static ChucVuDAO Instances
        {
            get
            {
                if (instances == null) instances = new ChucVuDAO(); return instances;
            }
            set => instances = value;
        }
        public bool ThemChucVu(EC_CHUCVU ec)
        {
            string query = " execute ThemChucVu @TenCV";
            DataProvider.Instance.ExecuteQuery(query, new object[] { ec.TenChucVu });
            return true;
        }
        public bool SuaChucVu(EC_CHUCVU ec)
        {
            string query = " execute SuaChucVu @MaCV , @TenCV";
            DataProvider.Instance.ExecuteQuery(query, new object[] {ec.MaChucVu, ec.TenChucVu });
            return true;
        }
        public bool XoaChucVu(EC_CHUCVU ec)
        {
            string query = " execute XoaChucvu_thinh @Macv";
            DataProvider.Instance.ExecuteQuery(query, new object[] { ec.MaChucVu });
            return true;
        }
        public DataTable Taobang(string dieukien)
        {
            string query = "select * from CHUCVU" + dieukien;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            return dt;
        }
    }
}
