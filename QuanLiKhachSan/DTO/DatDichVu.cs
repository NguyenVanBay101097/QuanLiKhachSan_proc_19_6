using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
    public class DatDichVu
    {
        private string maDatPhong;
        private string maDichVu;
        private int soLuong;
        private DateTime ngayDung;
        private float giaTien;
        private object item;
        public DatDichVu(string maDatPhong,string maDichVu,int soLuong,DateTime ngayDung,float giaTien)
        {
            MaDatPhong = maDatPhong;
            TenDV = maDichVu;
            SoLuong = soLuong;
            NgayDung = ngayDung;
            GiaTien = giaTien;
        }
        public DatDichVu(DataRow row)
        {
            MaDatPhong = row["madp"].ToString();
            TenDV = row["TENDV"].ToString();
            SoLuong = int.Parse(row["SoLuong"].ToString());
            NgayDung = DateTime.Parse(row["ngayDung"].ToString());
            GiaTien = float.Parse(row["giadichvuhientai"].ToString());
        }
        public string MaDatPhong { get => maDatPhong; set => maDatPhong = value; }
        public string TenDV { get => maDichVu; set => maDichVu = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public DateTime NgayDung { get => ngayDung; set => ngayDung = value; }
        public float GiaTien { get => giaTien; set => giaTien = value; }
    }
}
