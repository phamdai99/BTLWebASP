using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BTLWebASP.Models
{
    public class LoaiHangModel
    {
        dataconnection db = new dataconnection();

        public List<LoaiHang> getAll()
        {
            DataTable dt = db.layDeLieu("select * from LoaiHang");
            List<LoaiHang> li = new List<LoaiHang>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiHang sp = new LoaiHang();
                sp.MaLoai = dr[0].ToString();
                sp.TenLoai = dr[1].ToString();
                sp.HinhLoai = dr[2].ToString();
                li.Add(sp);
            }
            return li;
        }

        public LoaiHang getOneNewLoaiHang()
        {
            DataTable dt = db.layDeLieu("SELECT top 1 * FROM LoaiHang order by Created_at DESC");
            LoaiHang sp = new LoaiHang();
            string maItem = dt.Rows[0][0].ToString();
            string[] temp = maItem.Split('H');
            int position = Int32.Parse(temp[1]) + 1;
            string maSP = "LH" + position;
            sp.MaLoai = maSP;
            sp.TenLoai = dt.Rows[0][1].ToString();
            sp.HinhLoai = dt.Rows[0][2].ToString();
            sp.Created_at = DateTime.Parse(dt.Rows[0][3].ToString());
            return sp;
        }

        public LoaiHang getDetailLH(string id)
        {
            DataTable dt = db.layDeLieu("SELECT * FROM LoaiHang WHERE MaLoai='" + id + "'");
            LoaiHang sp = new LoaiHang();
            sp.MaLoai = dt.Rows[0][0].ToString();
            sp.TenLoai = dt.Rows[0][1].ToString();
            sp.HinhLoai = dt.Rows[0][2].ToString();
            sp.Created_at = DateTime.Parse(dt.Rows[0][3].ToString());
            return sp;
        }

        public void addLoaiSP(LoaiHang item)
        {
            db.ghiDuLieu("INSERT INTO LoaiHang (MaLoai,TenLoai,HinhLoai) VALUES('" + item.MaLoai + "',N'" + item.TenLoai + "',N'" + item.HinhLoai + "');");
        }

        public void updateLoaiHang(LoaiHang item)
        {
            db.ghiDuLieu("UPDATE LoaiHang SET TenLoai=N'" + item.TenLoai + "',HinhLoai=N'" + item.HinhLoai + "' WHERE MaLoai='" + item.MaLoai + "'");
        }

        public void deleteProduct(string maLoai)
        {
            db.ghiDuLieu("DELETE FROM LoaiHang where MaLoai='" + maLoai + "'");
        }
    }
}