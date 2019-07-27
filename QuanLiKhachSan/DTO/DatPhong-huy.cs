using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
    public class DatPhong
    {
        private string maDatPhong;
        private string maPhong;
        private string maKH;
        private float  traTruoc;
        private DateTime ngayO;
        private DateTime? ngayDi;
        private float giaPhongHienTai;
        private object item;
       
        private bool trangThaiThanhToan;
        public string MaDatPhong { get => maDatPhong; set => maDatPhong = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public float TraTruoc { get => traTruoc; set => traTruoc = value; }
        public DateTime NgayO { get => ngayO; set => ngayO = value; }
        public DateTime? NgayDi { get => ngayDi; set => ngayDi = value; }
        public bool TrangThaiThanhToan { get => trangThaiThanhToan; set => trangThaiThanhToan = value; }
        
        public float GiaPhongHienTai { get => giaPhongHienTai; set => giaPhongHienTai = value; }

        public DatPhong(string maDatPhong, string maPhong, string maKH, float traTruoc, DateTime ngayO, DateTime ngayDi,
            bool trangThaiThanhToan,float giaPhongHienTai)
        {
            this.MaDatPhong=maDatPhong;
            this.MaPhong=maPhong;
            this.MaKH=maKH;
            this.TraTruoc=traTruoc;
            this.NgayO=ngayO;
            this.NgayDi=ngayDi;
           
            this.TrangThaiThanhToan = trangThaiThanhToan;
            this.GiaPhongHienTai = giaPhongHienTai;
        }
        public DatPhong(DataRow row)
        {
            this.MaDatPhong = row["MADATPHONG"].ToString();
            this.MaPhong = row["MAPHONG"].ToString();
            this.MaKH = row["MAKH"].ToString();
            this.TraTruoc = float.Parse(row["TRATRUOC"].ToString());
            this.NgayO = (DateTime)row["NGAYO"];
            if(row["NGAYDI"].ToString()!="")
            this.NgayDi = (DateTime?)row["NGAYDI"];
            this.TrangThaiThanhToan = (bool)row["TrangThaiThanhToan"];
            this.GiaPhongHienTai = float.Parse(row["GiaPhongHienTai"].ToString());
        }
        public DatPhong(DataRow row,int a)
        {
            this.MaDatPhong = row["MADATPHONG"].ToString();
        }
        
        public DatPhong(object item)
        {
            this.item = item;
        }
    }
}
