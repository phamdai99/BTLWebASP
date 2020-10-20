using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BTLWebASP.Models
{
    public class SanPhamModel
    {
        dataconnection db = new dataconnection();
        GiaBanModel giaBanModel = new GiaBanModel();
        //TYPE  1:hàng sắp có
        //      2:hàng đã bán

        //lấy sản phẩm đang giảm giá
        public List<SanPham> getSPSale(int type)
        {
            DataTable dt = db.layDeLieu("select * from SanPham where MType='" + type + "'");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                string masp = dr[0].ToString();
                int sizeGB = giaBanModel.getSize(masp);
                if (sizeGB > 1)
                {
                    SanPham sp = new SanPham();
                    sp.MaSP = dr[0].ToString();
                    sp.MaLoai = dr[1].ToString();
                    sp.TenSP = dr[2].ToString();
                    sp.HinhSP = dr[3].ToString();
                    sp.MType = int.Parse(dr[4].ToString());
                    sp.SoLuong = int.Parse(dr[5].ToString());
                    sp.SoLuongCon = int.Parse(dr[6].ToString());
                    sp.Mota = dr[7].ToString();
                    sp.Created_at = DateTime.Parse(dr[8].ToString());
                    sp.giaBans = giaBanModel.getNewGiaBan(sp.MaSP);
                    li.Add(sp);
                }
                Debug.WriteLine(masp);
            }
            return li;
        }

        public List<SanPham> getAllSP(int type)
        {
            DataTable dt = db.layDeLieu("select * from SanPham where MType='" + type + "'");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.MaLoai = dr[1].ToString();
                sp.TenSP = dr[2].ToString();
                sp.HinhSP = dr[3].ToString();
                sp.MType = int.Parse(dr[4].ToString());
                sp.SoLuong = int.Parse(dr[5].ToString());
                sp.SoLuongCon = int.Parse(dr[6].ToString());
                sp.Mota = dr[7].ToString();
                sp.Created_at = DateTime.Parse(dr[8].ToString());
                sp.giaBans = giaBanModel.getGiaBan(sp.MaSP);
                li.Add(sp);
            }
            return li;
        }

        public SanPham getSP(string id)
        {
            DataTable dt = db.layDeLieu("select * from SanPham where masp='" + id + "'");
            SanPham sp = new SanPham();
            sp.MaSP = dt.Rows[0][0].ToString();
            sp.MaLoai = dt.Rows[0][1].ToString();
            sp.TenSP = dt.Rows[0][2].ToString();
            sp.HinhSP = dt.Rows[0][3].ToString();
            sp.MType = int.Parse(dt.Rows[0][4].ToString());
            sp.SoLuong = int.Parse(dt.Rows[0][5].ToString());
            sp.SoLuongCon = int.Parse(dt.Rows[0][6].ToString());
            sp.Mota = dt.Rows[0][7].ToString();
            sp.Created_at = DateTime.Parse(dt.Rows[0][7].ToString());
            return sp;
        }
    }
}