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
        public List<SanPham> getProductSale(int type)
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
                    sp.DVT = dr[4].ToString();
                    sp.MType = int.Parse(dr[5].ToString());
                    sp.SoLuong = int.Parse(dr[6].ToString());
                    sp.SoLuongCon = int.Parse(dr[7].ToString());
                    sp.Mota = dr[8].ToString();
                    sp.Created_at = DateTime.Parse(dr[9].ToString());
                    sp.giaBans = giaBanModel.getNewGiaBan(sp.MaSP);
                    li.Add(sp);
                }
                Debug.WriteLine(masp);
            }
            return li;
        }

        //lấy 10 sản phẩm mới nhất
        public List<SanPham> getNewProduct(int type)
        {
            //SELECT top 10 * FROM SanPham order by Created_at DESC
            DataTable dt = db.layDeLieu("SELECT top 10 * FROM SanPham where MType='" + type + "' order by Created_at DESC");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.MaLoai = dr[1].ToString();
                sp.TenSP = dr[2].ToString();
                sp.HinhSP = dr[3].ToString();
                sp.DVT = dr[4].ToString();
                sp.MType = int.Parse(dr[5].ToString());
                sp.SoLuong = int.Parse(dr[6].ToString());
                sp.SoLuongCon = int.Parse(dr[7].ToString());
                sp.Mota = dr[8].ToString();
                sp.Created_at = DateTime.Parse(dr[9].ToString());
                sp.giaBans = giaBanModel.getGiaBan(sp.MaSP);
                li.Add(sp);
            }
            return li;
        }

        //lấy sản phẩm sắp có
        public List<SanPham> getCommingSoonProduct(int type)
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
                sp.DVT = dr[4].ToString();
                sp.MType = int.Parse(dr[5].ToString());
                sp.SoLuong = int.Parse(dr[6].ToString());
                sp.SoLuongCon = int.Parse(dr[7].ToString());
                sp.Mota = dr[8].ToString();
                sp.Created_at = DateTime.Parse(dr[9].ToString());
                sp.giaBans = giaBanModel.getGiaBan(sp.MaSP);
                li.Add(sp);
            }
            return li;
        }

        //lấy 1 sản phẩm mới nhất
        public SanPham getOneNewProduct()
        {
            DataTable dt = db.layDeLieu("SELECT top 1 * FROM SanPham order by Created_at DESC");
            SanPham sp = new SanPham();
            string maItem = dt.Rows[0][0].ToString();
            string[] temp = maItem.Split('P');
            int position = Int32.Parse(temp[1]) + 1;
            string maSP = "SP" + position;
            sp.MaSP = maSP;
            sp.MaLoai = dt.Rows[0][1].ToString();
            sp.TenSP = dt.Rows[0][2].ToString();
            sp.HinhSP = dt.Rows[0][3].ToString();
            sp.DVT = dt.Rows[0][4].ToString();
            sp.MType = int.Parse(dt.Rows[0][5].ToString());
            sp.SoLuong = int.Parse(dt.Rows[0][6].ToString());
            sp.SoLuongCon = int.Parse(dt.Rows[0][7].ToString());
            sp.Mota = dt.Rows[0][8].ToString();
            sp.Created_at = DateTime.Parse(dt.Rows[0][9].ToString());
            //sp.giaBans = giaBanModel.getGiaBan(sp.MaSP);
            return sp;
        }

        //lấy tất cả sản phẩm
        public List<SanPham> getAllProduct()
        {
            DataTable dt = db.layDeLieu("select * from SanPham");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.MaLoai = dr[1].ToString();
                sp.TenSP = dr[2].ToString();
                sp.HinhSP = dr[3].ToString();
                sp.DVT = dr[4].ToString();
                sp.MType = int.Parse(dr[5].ToString());
                sp.SoLuong = int.Parse(dr[6].ToString());
                sp.SoLuongCon = int.Parse(dr[7].ToString());
                sp.Mota = dr[8].ToString();
                sp.Created_at = DateTime.Parse(dr[9].ToString());
                li.Add(sp);
            }
            return li;
        }

        public SanPham getDetailProduct(string id)
        {
            DataTable dt = db.layDeLieu("SELECT * FROM SanPham WHERE maSP='" + id + "'");
            SanPham sp = new SanPham();
            sp.MaSP = dt.Rows[0][0].ToString();
            sp.MaLoai = dt.Rows[0][1].ToString();
            sp.TenSP = dt.Rows[0][2].ToString();
            sp.HinhSP = dt.Rows[0][3].ToString();
            sp.DVT = dt.Rows[0][4].ToString();
            sp.MType = int.Parse(dt.Rows[0][5].ToString());
            sp.SoLuong = int.Parse(dt.Rows[0][6].ToString());
            sp.SoLuongCon = int.Parse(dt.Rows[0][7].ToString());
            sp.Mota = dt.Rows[0][8].ToString();
            sp.Created_at = DateTime.Parse(dt.Rows[0][9].ToString());
            sp.giaBans = giaBanModel.getGiaBan(sp.MaSP);
            return sp;
        }

        //TÌM KIẾM GẦN ĐÚNG THEO TÊN
        public List<SanPham> searchProduct(string productName)
        {
            DataTable dt = db.layDeLieu("SELECT* FROM SanPham WHERE TenSP like N'%" + productName + "%'");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.MaLoai = dr[1].ToString();
                sp.TenSP = dr[2].ToString();
                sp.HinhSP = dr[3].ToString();
                sp.DVT = dr[4].ToString();
                sp.MType = int.Parse(dr[5].ToString());
                sp.SoLuong = int.Parse(dr[6].ToString());
                sp.SoLuongCon = int.Parse(dr[7].ToString());
                sp.Mota = dr[8].ToString();
                sp.Created_at = DateTime.Parse(dr[9].ToString());
                sp.giaBans = giaBanModel.getGiaBan(sp.MaSP);
                li.Add(sp);
            }
            return li;
        }

        public void addSp(SanPham item)
        {
            db.ghiDuLieu("INSERT INTO SanPham (MaSP,MaLoai,TenSP,HinhSP,DVT,MType,SoLuong,SoLuongCon,Mota) VALUES('" + item.MaSP + "','" + item.MaLoai + "',N'" + item.TenSP + "','" + item.HinhSP + "','" + item.DVT + "'," + item.MType + "," + item.SoLuong + "," + item.SoLuongCon + ",N'" + item.Mota + "');");
        }
        public void updateProduct(SanPham item)
        {
            db.ghiDuLieu("UPDATE SanPham SET MaSP='" + item.MaSP + "',MaLoai='" + item.MaLoai + "',TenSP=N'" + item.TenSP + "',HinhSP='" + item.HinhSP + "',DVT='" + item.DVT + "',MType='" + item.MType + "',SoLuong='" + item.SoLuong + "',SoLuongCon='" + item.SoLuongCon + "',Mota=N'" + item.Mota + "' WHERE MaSP='" + item.MaSP + "'");
        }

        public void deleteProduct(string maSp)
        {
            db.ghiDuLieu("DELETE FROM SanPham where MaSP='" + maSp + "'");
        }
    }
}