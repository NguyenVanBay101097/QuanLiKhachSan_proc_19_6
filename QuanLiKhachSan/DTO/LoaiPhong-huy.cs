using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
    public class LoaiPhong
    {
        private object item;
        private string mA;
        private string tenLoaiPhong;
        private string thietBi;
        public string MA { get => mA;private set => mA = value; }
        public string TenLoaiPhong { get => tenLoaiPhong;private set => tenLoaiPhong = value; }
        public string ThietBi { get => thietBi;private set => thietBi = value; }
        public LoaiPhong(string mA,string tenLoaiPhong,string thietBi)
        {
            this.MA = mA;
            this.TenLoaiPhong = tenLoaiPhong;
            this.ThietBi = thietBi;
        }
        public LoaiPhong(DataRow row)
        {
            this.MA = row["MALOAIPHONG"].ToString();
            this.TenLoaiPhong = row["TENLOAIPHONG"].ToString();
            this.ThietBi = row["THIETBI"].ToString();
        }
        public LoaiPhong(object item)
        {
            this.item = item;
        }
    }
}
