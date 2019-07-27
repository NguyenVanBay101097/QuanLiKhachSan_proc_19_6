using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
    public class KhachHang_huy
    {
        private string maKH;
        private string tenKH;
        private string gioiTinh;
        private DateTime ngaySinh;
        private string diaChi;
        private string chungMinhThu;
        private int soDienThoai;
        private object item;
        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string ChungMinhThu { get => chungMinhThu; set => chungMinhThu = value; }

        public KhachHang_huy(string maKH,string tenKH,string gioiTinh, DateTime ngaySinh, string diaChi, int soDienThoai,string chungMinhThu)
        {
            MaKH = maKH;
            TenKH = tenKH;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            ChungMinhThu = chungMinhThu;
        }
        public KhachHang_huy() { }
        public KhachHang_huy(DataRow row)
        {
            MaKH = row["MaKH"].ToString();
            TenKH = row["TenKH"].ToString();
            GioiTinh = row["GioiTinh"].ToString();
            if(row["NgaySinh"].ToString()!="")
            NgaySinh = (DateTime)row["NgaySinh"];
            DiaChi = row["DiaChi"].ToString();
            SoDienThoai = (int)row["SODIENTHOAI"];
            ChungMinhThu = row["ChungMinhThu"].ToString();
        }
        public KhachHang_huy(object item)
        {
            this.item = item;
        }
    }
}
