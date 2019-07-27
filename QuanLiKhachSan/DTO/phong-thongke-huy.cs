using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
    public class TableHienThiThongKeTinhTrangPhong
    {
        private int tinhTrangPhong;
        private int soLuong;
        private object item;
        
       
        public int TinhTrangPhong { get => tinhTrangPhong;private set => tinhTrangPhong = value; }
        public int SoLuong { get => soLuong;private set => soLuong = value; }
        public TableHienThiThongKeTinhTrangPhong(int tinhtrangphong,int soluong)
        {
            this.TinhTrangPhong = tinhtrangphong;
            this.SoLuong = soluong;
        }
        public TableHienThiThongKeTinhTrangPhong(DataRow row)
        {
            this.TinhTrangPhong = (int)row["TINHTRANGPHONG"];
            this.SoLuong = (int)row["So Luong"];
        }
        public TableHienThiThongKeTinhTrangPhong(object item)
        {
            this.item = item;
        }
    }
}
