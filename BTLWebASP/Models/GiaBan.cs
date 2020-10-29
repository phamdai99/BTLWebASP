using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTLWebASP.Models
{
    public class GiaBan
    {
        public string MaGB { get; set; }
        public string MaSP { get; set; }
        public int GiaMoi { get; set; }
        public int GiaCu { get; set; }
        public string DVTinh { get; set; }
        public System.DateTime NgayBD { get; set; }
        public System.DateTime NgayKT { get; set; }
    }
}