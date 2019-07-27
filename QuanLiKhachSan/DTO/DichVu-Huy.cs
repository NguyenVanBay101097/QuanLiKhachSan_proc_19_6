using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhachSan.DTO
{
    public class DichVu
    {
        private string maDV;
        private string tenDV;
        private float giaDV;
        private object item;
        public string MaDV { get => maDV; set => maDV = value; }
        public string TenDV { get => tenDV; set => tenDV = value; }
        public float GiaDV { get => giaDV; set => giaDV = value; }
        public DichVu(string maDV,string tenDV,float giaDV)
        {
            MaDV = maDV;
            TenDV = tenDV;
            GiaDV = giaDV;
        }
        public DichVu(DataRow row)
        {
            MaDV = row["MaDV"].ToString();
            TenDV = row["TenDV"].ToString();
            GiaDV = float.Parse(row["GiaDV"].ToString());
        }
        public DichVu(object item)
        {
            this.item = item;
        }
    }
}