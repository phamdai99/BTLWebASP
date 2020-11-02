using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTLWebASP.Models
{
    public class GiaBan
    {
        public GiaBan()
        {
        }

        public GiaBan(string maGB, string maSP, string gia, DateTime ngayBD, DateTime ngayKT)
        {
            MaGB = maGB;
            MaSP = maSP;
            Gia = gia;
            NgayBD = ngayBD;
            NgayKT = ngayKT;
        }

        public string MaGB { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Gia { get; set; }
        public int GiaMoi { get; set; }
        public int GiaCu { get; set; }
        public string DVTinh { get; set; }
        public System.DateTime NgayBD { get; set; }
        public System.DateTime NgayKT { get; set; }
    }
}