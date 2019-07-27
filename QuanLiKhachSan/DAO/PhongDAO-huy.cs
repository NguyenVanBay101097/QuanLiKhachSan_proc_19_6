using QuanLiKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DAO
{
    public class PhongDAO
    {
        private static PhongDAO instances;
        public static PhongDAO Instances
        {
            get
            {
                if (instances == null) instances = new PhongDAO();return instances;
            }
            set
            {
                instances = value;
            }
        }
        private PhongDAO()
        {
        
        }
        public List<TableHienThiThongKeTinhTrangPhong> LoadDanhSachThongKePhong()
        {
            string query1 = "execute ThongKePhong";
            List<TableHienThiThongKeTinhTrangPhong> danhsachthongke = new List<TableHienThiThongKeTinhTrangPhong>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query1);
            foreach (DataRow item in data.Rows)
            {
                TableHienThiThongKeTinhTrangPhong table = new TableHienThiThongKeTinhTrangPhong(item);
                danhsachthongke.Add(table);
            }
            return danhsachthongke;
        }
        public List<Phong> LoadDanhSach()
        {
            string query = "execute DanhSachPhong";
            List<Phong> danhsachphong = new List<Phong>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Phong table = new Phong(item);
                danhsachphong.Add(table);
            }
            return danhsachphong;
        }
        public List<Phong> LoadDanhSachTheoMaLoaiPhong(string ma) {
            string query = "EXECUTE LayPhongTheoMaLoaiPhong @id";
            List<Phong> danhsachphong1 = new List<Phong>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { ma});
            foreach (DataRow item in data.Rows)
            {
                Phong table1 = new Phong(item);
                danhsachphong1.Add(table1);
            }
            
            return danhsachphong1;
        }
        public List<Phong> LoadDanhSachTheoMavaTinhTrang(string ma)
        {
            string query = "EXECUTE LAYDANHSACHPHONGTHEOLOAIPHONGVATINHTRANG @id";
            List<Phong> danhsachphong1 = new List<Phong>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { ma });
            foreach (DataRow item in data.Rows)
            {
                Phong table1 = new Phong(item);
                danhsachphong1.Add(table1);
            }

            return danhsachphong1;
        }
       
        public List<Phong> LoadDanhSachTheoMaPhong(string ma)
        {
            string query = "EXECUTE DANHSACHPHONGTHEOMA @id";
            List<Phong> danhsachphong1 = new List<Phong>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { ma });
            foreach (DataRow item in data.Rows)
            {
                Phong table1 = new Phong(item);
                danhsachphong1.Add(table1);
            }

            return danhsachphong1;
        }
        public Phong LoadPhongTheoMaPhong(string ma)
        {
            string query = "EXECUTE DANHSACHPHONGTHEOMA @id";
            List<Phong> danhsachphong1 = new List<Phong>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { ma });
            Phong phong = new Phong(data.Rows[0]);
            return phong;
        }
        public string KiemTraLoadDanhSach(String MA)
        {
            string query = "EXECUTE DANHSACHPHONGTHEOMA @ID";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] {MA });
            if (data.Rows.Count > 0)
            {
                Phong phong = new Phong(data.Rows[0]);
                return phong.MA;
            }
            return "ko co";
        }
        public void insertPhong(string tenPhong,string maLoaiPhong,float giaPhong, string donViTienTe)
        {
            string query = "execute THEMPHONG @TENPHONG , @MALOAIPHONG , @GIAPHONG , @DONVITIENTE";
            DataProvider.Instance.ExecuteQuery(query, new object[] { tenPhong, maLoaiPhong, giaPhong, donViTienTe });
            
        }
        public void UpdatePhong(string maPhong ,string tenPhong, string maLoaiPhong, float giaPhong, string donViTienTe)
        {
            string query = "execute updatePhong @MAPHONG , @tenphong , @MALOAIPHONG , @GIAPHONG , @DONVITIENTE ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { maPhong, tenPhong, maLoaiPhong, giaPhong, donViTienTe });

        }
        public void RemovePhong(string maPhong)
        {
            string query = "execute RemovePhong @maphong ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { maPhong });

        }
    }
}
