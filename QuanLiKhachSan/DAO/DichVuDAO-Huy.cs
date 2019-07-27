using QuanLiKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DAO
{
    public class DichVuDAO
    {
        private static DichVuDAO instances;

        public static DichVuDAO Instances {
            get
            {
                if (instances == null) instances = new DichVuDAO();return instances;
            }
             set => instances = value; }
        public DichVuDAO() { }
        public List<DichVu> LoadDanhSachDichVu()
        {
            string query = "select * from DichVu";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            List<DichVu> danhsachdichvu = new List<DichVu>();
            foreach (DataRow item in dataTable.Rows)
            {
                DichVu dichVu = new DichVu(item);
                danhsachdichvu.Add(dichVu);
            }
            return danhsachdichvu;
        }
        public List<DatDichVu> LoadDanhSachDatDichVu(string madatphong)
        {
            string query = "execute DanhSachDatDichVu @madatphong";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query,new object[] { madatphong});
            List<DatDichVu> danhsachdichvu = new List<DatDichVu>();
            foreach (DataRow item in dataTable.Rows)
            {
                DatDichVu dichVu = new DatDichVu(item);
                danhsachdichvu.Add(dichVu);
            }
            return danhsachdichvu;
        }
        public List<DatDichVu> LoadDanhSachDatDichVu()
        {
            string query = "select * from DatDichVu";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            List<DatDichVu> danhsachdichvu = new List<DatDichVu>();
            foreach (DataRow item in dataTable.Rows)
            {
                DatDichVu dichVu = new DatDichVu(item);
                danhsachdichvu.Add(dichVu);
            }
            return danhsachdichvu;
        }
        public void ThemDatDichVu(string madp, string madv, int soLuong, DateTime ngayDung, float giadichvu)
        {
            string query = "execute ThemDatDichVu @madp , @madv , @SoLuong , @ngayDung , @giadichvuhientai";
            DataProvider.Instance.ExecuteQuery(query, new object[] { madp, madv, soLuong, ngayDung, giadichvu });
        }
        public void ThemDatDichVuSoLuong(string madp, string madv, int soLuong, DateTime ngayDung, float giadichvu)
        {
            string query = "execute ThemSoLuongDatDichVu @madp , @madv , @SoLuong , @ngayDung , @giadichvuhientai ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { madp, madv, soLuong, ngayDung, giadichvu });
        }
        public void SuaDatDichVuSoLuong(string madp, string madv, int soLuong, DateTime ngayDung, float giadichvu)
        {
            string query = "execute SuaSoLuongDatDichVu @madp , @madv , @SoLuong , @ngayDung , @giadichvuhientai ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { madp, madv, soLuong, ngayDung, giadichvu });
        }
        public void XoaDatDichVuSoLuong(string madp, string madv, int soLuong, DateTime ngayDung)
        {
            string query = "execute XoaDatDichVuSoLuong @madp , @madv , @SoLuong , @ngayDung";
            DataProvider.Instance.ExecuteQuery(query, new object[] { madp, madv, soLuong, ngayDung });
        }
    }
}
