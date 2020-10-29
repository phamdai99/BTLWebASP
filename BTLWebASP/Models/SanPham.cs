using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTLWebASP.Models
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string MaLoai { get; set; }
        public string TenSP { get; set; }
        public string HinhSP { get; set; }

        public string DVT { get; set; }
        public Nullable<int> MType { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> SoLuongCon { get; set; }
        public string Mota { get; set; }
        public System.DateTime Created_at { get; set; }

        public GiaBan giaBans { get; set; }
    }
}