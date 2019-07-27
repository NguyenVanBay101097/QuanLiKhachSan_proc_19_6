using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiKhachSan.DTO;
using System.Data;

namespace QuanLiKhachSan.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instances;
        public NhanVienDAO() { }
        public static NhanVienDAO Instances
        {
            get
            {
                if (instances == null) instances = new NhanVienDAO(); return instances;
            }
            set => instances = value;
        }


        public bool ThemNhanVien(EC_NHANVIEN ec)
        {
            string query = " execute ThemNhanVien_thinh @TENNHANVIEN , @GIOITINH , @NGAYSINH , @DIACHI , @MACHUCVU , @SODIENTHOAI";
            DataProvider.Instance.ExecuteQuery(query, new object[] {ec.TenNhanVien,ec.GioiTinh,ec.NgaySinh,ec.DiaChi,ec.MaChucVu,ec.SDT});
            return true;
        }
        public bool ThemTK(EC_TAIKHOAN ec)
        {
            string query = "execute ThemTK_thinh @PASS , @MACHUCVU , @MANHANVIEN";
            DataProvider.Instance.ExecuteQuery(query, new object[] { ec.MatKhau,ec.MaChucVu,ec.MaNhanVien});
            return true;
        }
        public bool XoaNhanVien(EC_NHANVIEN ec)
        {
            string query = "execute XoaNhanVien_thinh @Manv";
            DataProvider.Instance.ExecuteQuery(query, new object[] {ec.MaNhanVien });
            return true;
        }

        public bool SuaNhanVien(EC_NHANVIEN ec)
        {
            string query = "  execute SuaNhanVien_thinh @MANHANVIEN , @TENNHANVIEN , @GIOITINH , @NGAYSINH , @DIACHI , @MACHUCVU , @SODIENTHOAI";
            DataProvider.Instance.ExecuteQuery(query, new object[] {ec.MaNhanVien, ec.TenNhanVien, ec.GioiTinh, ec.NgaySinh, ec.DiaChi, ec.MaChucVu, ec.SDT });
            return true;
        }
        public bool SuaTK(EC_TAIKHOAN ec)
        {
            string query = "EXECUTE SuaTK_thinh @PASS , @MANHANVIEN";
            DataProvider.Instance.ExecuteQuery(query, new object[] { ec.MatKhau,ec.MaNhanVien });
            return true;
        }
        public DataTable Taobang(string Dieukien)
        {
          
            string query = " SELECT NHANVIEN.MANHANVIEN, NHANVIEN.SODIENTHOAI, NHANVIEN.TENNHANVIEN, NHANVIEN.GIOITINH, NHANVIEN.NGAYSINH, NHANVIEN.DIACHI, TAIKHOAN.TENTAIKHOAN, TAIKHOAN.PASS, CHUCVU.TENCHUCVU FROM NHANVIEN INNER JOIN TAIKHOAN ON NHANVIEN.MANHANVIEN = TAIKHOAN.MANHANVIEN INNER JOIN CHUCVU ON NHANVIEN.MACHUCVU = CHUCVU.MACHUCVU AND TAIKHOAN.MACHUCVU = CHUCVU.MACHUCVU" + Dieukien;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            return dt;
        }

    }
}
