using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance {
            get
            {
                if (instance == null) instance = new TaiKhoanDAO(); return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private TaiKhoanDAO() { }
        public bool Login(string tentaikhoan,string matkhau)
        {
            //'OR 1=1 --D
            string query = "EXECUTE DBO.USP_LOGIN @TENTAIKHOAN , @MATKHAU";
          
           DataTable  check = DataProvider.Instance.ExecuteQuery(query,new object[]{tentaikhoan , matkhau });
            return check.Rows.Count>0;
        }
    }
}
