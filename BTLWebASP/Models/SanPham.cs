using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BTLWebASP.Models
{
    public class SanPham
    {
        public SanPham()
        {
        }

        public SanPham(string maSP, string maLoai, string tenSP, string hinhSP, string dVT, int? mType, int? soLuong, int? soLuongCon, string mota)
        {
            MaSP = maSP;
            MaLoai = maLoai;
            TenSP = tenSP;
            HinhSP = hinhSP;
            DVT = dVT;
            MType = mType;
            SoLuong = soLuong;
            SoLuongCon = soLuongCon;
            Mota = mota;
        }

        [DisplayName("Mã sản phẩm")]
        public string MaSP { get; set; }
        [DisplayName("Mã loại")]
        public string MaLoai { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string TenSP { get; set; }
        [DisplayName("Hình ảnh")]
        public string HinhSP { get; set; }
        [DisplayName("Đơn vị tính")]

        public string DVT { get; set; }
        [DisplayName("Trạng thái")]
        public Nullable<int> MType { get; set; }
        [DisplayName("Số lượng")]
        public Nullable<int> SoLuong { get; set; }
        [DisplayName("Số lượng còn")]
        public Nullable<int> SoLuongCon { get; set; }
        [DisplayName("Mô tả")]
        public string Mota { get; set; }
        [DisplayName("Ngày thêm")]
        public System.DateTime Created_at { get; set; }

        public GiaBan giaBans { get; set; }
    }
}