using BTLWebASP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace BTLWebASP.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        SanPhamModel sanPhamModel = new SanPhamModel();

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View(getAllProduct());
        }

        public List<SanPham> getAllProduct()
        {
            return sanPhamModel.getAllProduct();
        }

        public ActionResult Create(string maSanPham, string maLoai, string tenSanPham, string hinhAnh, string dvt, string trangThai, string soLuong, string soLuongCon, string moTa)
        {
            SanPham item = new SanPham(maSanPham, maLoai, tenSanPham, hinhAnh, dvt, Int32.Parse(trangThai), Int32.Parse(trangThai), Int32.Parse(soLuongCon), moTa);
            sanPhamModel.addSp(item);
            return View();
        }
    }
}