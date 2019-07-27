using QuanLiKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DAO
{
    public class LoaiPhongDAO
    {
        private static LoaiPhongDAO instances;

        internal static LoaiPhongDAO Instances { get {
                if (instances == null)
                    instances = new LoaiPhongDAO();
                        return instances;
                    } private set => instances = value; }
        private LoaiPhongDAO() { }
        public List<LoaiPhong> DanhSachLoaiPhong()
        {
            string query = "select * from LoaiPhong";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<LoaiPhong> danhsachloaiphong = new List<LoaiPhong>();
            foreach (DataRow item in data.Rows)
            {
                LoaiPhong loaiPhong = new LoaiPhong(item);
                danhsachloaiphong.Add(loaiPhong);
            }
            return danhsachloaiphong;
        }
    }
}
