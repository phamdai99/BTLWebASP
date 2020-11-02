using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BTLWebASP.Models
{
    public class GiaBanModel
    {
        dataconnection db = new dataconnection();

        //lấy tất giá bán
        public List<GiaBan> getAllGiaBan()
        {
            DataTable dt = db.layDeLieu("select * from GiaBan");
            List<GiaBan> li = new List<GiaBan>();
            foreach (DataRow dr in dt.Rows)
            {
                GiaBan giaBan = new GiaBan();
                giaBan.MaGB = dr[0].ToString();
                giaBan.MaSP = dr[1].ToString();
                giaBan.Gia = dr[2].ToString();
                giaBan.NgayBD = DateTime.Parse(dr[4].ToString());
                giaBan.NgayKT = DateTime.Parse(dr[5].ToString());

                //giaBan.TenSP = (sp.MaSP);
                li.Add(giaBan);
            }
            return li;
        }

        //lấy giá bán theo mã sản phẩm
        public GiaBan getGiaBan(string maSp)
        {
            DataTable dt = db.layDeLieu("select * from GiaBan where MaSP='" + maSp + "'");
            GiaBan giaBan = new GiaBan();
            giaBan.MaGB = dt.Rows[0][0].ToString();
            giaBan.MaSP = dt.Rows[0][1].ToString();
            giaBan.GiaMoi = int.Parse(dt.Rows[0][2].ToString());
            giaBan.DVTinh = dt.Rows[0][3].ToString();
            giaBan.NgayBD = DateTime.Parse(dt.Rows[0][4].ToString());
            giaBan.NgayKT = DateTime.Parse(dt.Rows[0][5].ToString());
            return giaBan;
        }

        //Lấy giá bán mới nhất theo mã sản phẩm
        public GiaBan getNewGiaBan(string maSp)
        {
            GiaBan giaBan = new GiaBan();
            DataTable dt = db.layDeLieu("select top 1 * from GiaBan where MaSP='" + maSp + "' order by MaGB DESC");
            giaBan.MaGB = dt.Rows[0][0].ToString();
            giaBan.MaSP = dt.Rows[0][1].ToString();
            giaBan.GiaMoi = int.Parse(dt.Rows[0][2].ToString());
            giaBan.DVTinh = dt.Rows[0][3].ToString();
            giaBan.NgayBD = DateTime.Parse(dt.Rows[0][4].ToString());
            giaBan.NgayKT = DateTime.Parse(dt.Rows[0][5].ToString());
            giaBan.GiaCu = getOldGiaBan(maSp).GiaCu;
            Debug.WriteLine(giaBan.GiaMoi + "/" + giaBan.GiaCu);
            return giaBan;
        }

        //Lấy giá bán mới nhất theo mã sản phẩm
        public GiaBan getOldGiaBan(string maSp)
        {
            GiaBan giaBan = new GiaBan();
            if (getSize(maSp) > 1)
            {
                DataTable dt = db.layDeLieu("select top 1 * from GiaBan where MaSP='" + maSp + "' order by MaGB ASC");
                giaBan.MaGB = dt.Rows[0][0].ToString();
                giaBan.MaSP = dt.Rows[0][1].ToString();
                giaBan.GiaCu = int.Parse(dt.Rows[0][2].ToString());
                giaBan.DVTinh = dt.Rows[0][3].ToString();
                giaBan.NgayBD = DateTime.Parse(dt.Rows[0][4].ToString());
                giaBan.NgayKT = DateTime.Parse(dt.Rows[0][5].ToString());
            }
            return giaBan;
        }

        public int getSize(string maSP)
        {
            int size;
            DataTable dt = db.layDeLieu("select * from GiaBan where MaSP='" + maSP + "'");
            List<GiaBan> li = new List<GiaBan>();
            foreach (DataRow dr in dt.Rows)
            {
                GiaBan giaBan = new GiaBan();
                giaBan.MaGB = dt.Rows[0][0].ToString();
                giaBan.MaSP = dt.Rows[0][1].ToString();
                giaBan.GiaMoi = int.Parse(dt.Rows[0][2].ToString());
                giaBan.DVTinh = dt.Rows[0][3].ToString();
                giaBan.NgayBD = DateTime.Parse(dt.Rows[0][4].ToString());
                giaBan.NgayKT = DateTime.Parse(dt.Rows[0][5].ToString());
                li.Add(giaBan);
            }
            size = li.Count;
            return size;
        }

        public void addGB(GiaBan item)
        {
            db.ghiDuLieu("INSERT INTO GiaBan (MaGB,MaSP,Gia,NgayBD,NgayKT) VALUES('" + item.MaGB + "','" + item.MaSP + "'," + item.Gia + ",'" + item.NgayBD + "','" + item.NgayKT + "');");
        }
        public void updateGB(GiaBan item)
        {
            db.ghiDuLieu("UPDATE GiaBan SET MaSP='" + item.MaSP + "',Gia='" + item.Gia + "',NgayBD='" + item.NgayBD + "',NgayKT='" + item.NgayKT + "' WHERE MaGB='" + item.MaGB + "'");
        }

        public void deleteGB(string MaGB)
        {
            db.ghiDuLieu("DELETE FROM GiaBan where MaGB='" + MaGB + "'");
        }
    }
}