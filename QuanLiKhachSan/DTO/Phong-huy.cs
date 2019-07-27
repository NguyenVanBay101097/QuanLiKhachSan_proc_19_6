using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
    public class Phong
    {
       

        private float giaPhong;
        private string donViTienTe;
        private string maLoaiPhong;
        private int tinhTrangPhong;
        private string tenPhong;
        private string mA;
        private object item;

        public string MA { get => mA; set => mA = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public int TinhTrangPhong { get => tinhTrangPhong; set => tinhTrangPhong = value; }
        public string MaLoaiPhong { get => maLoaiPhong; set => maLoaiPhong = value; }
        public float GiaPhong { get => giaPhong; set => giaPhong = value; }
        public string DonViTienTe { get => donViTienTe; set => donViTienTe = value; }
       
       

        
        public Phong(string mA, string tenPhong, int tinhTrangPhong, string maLoaiPhong, float giaPhong, string donViTienTe) {
            this.MA = mA;
            this.TenPhong = tenPhong;
            this.TinhTrangPhong = tinhTrangPhong;
            this.MaLoaiPhong = maLoaiPhong;
            GiaPhong = giaPhong;
            DonViTienTe = donViTienTe;
        }
        public Phong(DataRow row)
        {
          
            MA = row["MAPHONG"].ToString();
            TenPhong = row["tenphong"].ToString();
            TinhTrangPhong = (int)row["tinhtrangphong"];
            MaLoaiPhong = row["maloaiphong"].ToString();
            GiaPhong = float.Parse(row["giaphong"].ToString());
            DonViTienTe = row["donvitiente"].ToString();
        }
        

        public Phong(object item)
        {
            this.item = item;
        }
    }
}// de t them cho cai nao ko phai m di chuyen chuot//// chua xoa may cai kia ma