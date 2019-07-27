using QuanLiKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DAO
{
    public class DatPhongDAO
    {
        private static DatPhongDAO instances;

        public static DatPhongDAO Instances { get {
                if (instances == null) instances = new DatPhongDAO(); return instances;
            }set => instances = value; }
       
        public List<DatPhong> HienThiDanhSachDatPhong()
        {
            List<DatPhong> danhsachdatphong = new List<DatPhong>();
            string query = "execute DanhSachDatPhong"; 
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DatPhong datPhong = new DatPhong(item);
                danhsachdatphong.Add(datPhong);
            }
            return danhsachdatphong;
        }
        public List<DatPhong> HienThiDanhSachDatPhongChuaThanhToan()
        {
            List<DatPhong> danhsachdatphong = new List<DatPhong>();
            string query = "execute DanhSachDatPhongChuaThanhToan";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DatPhong datPhong = new DatPhong(item);
                danhsachdatphong.Add(datPhong);
            }
            return danhsachdatphong;
        }

        public List<DatPhong> HienThiDanhSachDatPhongVaocbb()
        {
            List<DatPhong> danhsachdatphong = new List<DatPhong>();
            string query = "execute DanhSachDatPhongVaocbb";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DatPhong datPhong = new DatPhong(item, 2);
                danhsachdatphong.Add(datPhong);
            }
            return danhsachdatphong;
        }
        public List<DatPhong> HienThiDanhSachDatPhong(string MaDP)
        {
            List<DatPhong> danhsachdatphong = new List<DatPhong>();
            string query = "EXECUTE TimDatPhongTHeoMa @madp";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] {MaDP });
            foreach (DataRow item in data.Rows)
            {
                DatPhong datPhong = new DatPhong(item);
                danhsachdatphong.Add(datPhong);
            }
            return danhsachdatphong;
        }
        public void SuaDichVuVoiMaDatPhongVaMaPhong(string maDatPhong,string maPhong,string maDV,int soLuong)
        {
            string query = "execute SuaDichVu @maDatPhong , @MaPhong , @maDV , @soluong";
            DataProvider.Instance.ExecuteQuery(query,new object[] {maDatPhong,maPhong,maDV,soLuong });
        }
        public List<DatPhong> HienThiDanhSachDatPhongCoCacPhongDuocGiu()
        {
            List<DatPhong> danhsachdatphong = new List<DatPhong>();
            string query = "DanhSachDatPhongCoCacPhongDangDuocGiu";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DatPhong datPhong = new DatPhong(item);
                danhsachdatphong.Add(datPhong);
            }
            return danhsachdatphong;
        }
        public void XoaToanBoDatPhongTheoMaDatPhong(string maDatPhong)
        {
            string query = "execute XoaToanBoDatPhongTheoMaDatPhong @madatphong";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maDatPhong});
        }
        public void XoaDichVuTheoMaPhongVaMaDatPhong(string maDatPhong,string maPhong, string maDichVu)
        {
            string query = "execute XoaDichVuTheoMaPhongVaMaDatPhong @madatphong , @maphong , @madichvu";
            DataProvider.Instance.ExecuteQuery(query, new object[] {maDatPhong,maPhong,maDichVu });
        }
        public List<DatPhong> HienThiDanhSachDatPhongMaPhongTuongUng(string maDatPhong,string maPhong)
        {
            List<DatPhong> danhsachdatphong = new List<DatPhong>();
            string query = "HienThiDanhSachDatPhongMaPhongTuongUng @madatphong , @maphong";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] {maDatPhong,maPhong });
            foreach (DataRow item in data.Rows)
            {
                DatPhong datPhong = new DatPhong(item);
                danhsachdatphong.Add(datPhong);
            }
            return danhsachdatphong;
        }
        public List<DatPhong> HienThiDanhSachDatPhongCoCacPhongDangO()
        {
            List<DatPhong> danhsachdatphong = new List<DatPhong>();
            string query = "DanhSachDatPhongCoCacPhongDangO";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DatPhong datPhong = new DatPhong(item);
                danhsachdatphong.Add(datPhong);
            }
            return danhsachdatphong;
        }
        public bool KiemTraPhongCoTonTaiTrongMaDP(string maPhong)
        {
            string query = "execute TimPhongCoTrongDatPhong @maPhong";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {maPhong });
            return data.Rows.Count > 0;
        }
        public void removeDatPhongTheoMaPhong(string maPhong)
        {
            string query = "execute XoaDatPhongTheoMaPhong @maPhong";
            DataProvider.Instance.ExecuteQuery(query,new object[] {maPhong });
        }
        public void removeDatPhongTheoMaPhongVaMaDatPhong(string maDatPhong,string maPhong)
        {
            string query = "execute XoaPhongTheoMaDPTuongUng @madatphong , @maphong";
            DataProvider.Instance.ExecuteQuery(query, new object[] { maDatPhong,maPhong });
        }
        public void ThemDatPhongOLien(string maPhong,string maKH,float traTruoc,DateTime ngayO,DateTime ngayDi)
        {
            string query =" execute ThemDatPhongOLien @MAPHONG , @MAKH , @TRATRUOC , @NGAYO , @NGAYDI ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { maPhong, maKH, traTruoc, ngayO, ngayDi});
        }
        public void ThemPhongOLienVaoDatPhong(string maDatPhong,string maPhong, string maKH, float traTruoc, DateTime ngayO, DateTime ngayDi, string MaDV, int SoLuong)
        {
            string query = " execute THEMPHONGVAOMADP @MADATPHONG , @MAPHONG , @MAKH , @TRATRUOC , @NGAYO , @NGAYDI , @MADV , @SOLUONG ";
            DataProvider.Instance.ExecuteQuery(query, new object[] {maDatPhong, maPhong, maKH, traTruoc, ngayO, ngayDi, MaDV, SoLuong });
        }
        public void ThemDatPhongVaGiuPhong(string maPhong, string maKH, float traTruoc, DateTime ngayO, DateTime ngayDi)
        {
            string query = " execute ThemDatPhongGiuPhong @MAPHONG , @MAKH , @TRATRUOC , @NGAYO , @NGAYDI  ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { maPhong, maKH, traTruoc, ngayO, ngayDi});
        }
        public void ThemPhongVaGiuPhongVaoDatPhong(string maDatPhong, string maPhong, string maKH, float traTruoc, DateTime ngayO, DateTime ngayDi, string MaDV, int SoLuong)
        {
            string query = " execute ThemPhongVaGiuPhongVaoDatPhong @MADATPHONG , @MAPHONG , @MAKH , @TRATRUOC , @NGAYO , @NGAYDI , @MADV , @SOLUONG ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { maDatPhong, maPhong, maKH, traTruoc, ngayO, ngayDi, MaDV, SoLuong });
        }
    }
}
