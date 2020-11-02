using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BTLWebASP.Models
{
    public class LoaiHang
    {
        public LoaiHang()
        {
        }

        public LoaiHang(string maLoai, string tenLoai, string hinhLoai)
        {
            MaLoai = maLoai;
            TenLoai = tenLoai;
            HinhLoai = hinhLoai;
        }
        [DisplayName("Mã loại")]
        public string MaLoai { get; set; }
        [DisplayName("Tên loại")]
        public string TenLoai { get; set; }
        [DisplayName("Hình ảnh")]
        public string HinhLoai { get; set; }
        [DisplayName("Ngày thêm")]
        public System.DateTime Created_at { get; set; }
    }
}