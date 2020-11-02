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

        //THÊM SẢN PHẨM MỚI
        public ActionResult CreateProduct(string cal, string maSanPham, string maLoai, string tenSanPham, string hinhAnh, string dvt, string trangThai, string soLuong, string soLuongCon, string moTa)
        {
            SanPham sanPham = sanPhamModel.getOneNewProduct();
            if (!String.IsNullOrEmpty(cal))
            {
                if (cal.Equals("Thêm"))
                {
                    if (!String.IsNullOrEmpty(maSanPham) && !String.IsNullOrEmpty(maLoai) && !String.IsNullOrEmpty(tenSanPham) && !String.IsNullOrEmpty(hinhAnh) && !String.IsNullOrEmpty(trangThai) && !String.IsNullOrEmpty(soLuong) && !String.IsNullOrEmpty(soLuongCon) && !String.IsNullOrEmpty(moTa))
                    {
                        SanPham item = new SanPham(maSanPham, maLoai, tenSanPham, hinhAnh, dvt, Int32.Parse(trangThai), Int32.Parse(trangThai), Int32.Parse(soLuongCon), moTa);
                        sanPhamModel.addSp(item);
                    }
                    SanPham sanPham1 = sanPhamModel.getOneNewProduct();
                    return View(sanPham1);
                }
            }
            return View(sanPham);
        }

        //CẬP NHẬT THÔNG TIN SẢN PHẨM
        public ActionResult Update()
        {
            return View(getAllProduct());
        }

        public ActionResult UpdateProduct(string call, string maSanPham, string maLoai, string tenSanPham, string hinhAnh, string dvt, string trangThai, string soLuong, string soLuongCon, string moTa)
        {
            SanPham item = new SanPham(maSanPham, maLoai, tenSanPham, hinhAnh, dvt, Int32.Parse(trangThai), Int32.Parse(soLuong), Int32.Parse(soLuongCon), moTa);
            if (!String.IsNullOrEmpty(call))
                if (call.Equals("Cập nhật"))
                {
                    Debug.WriteLine("Cập nhật:" + maSanPham);
                    if (!String.IsNullOrEmpty(maSanPham) && !String.IsNullOrEmpty(maLoai) && !String.IsNullOrEmpty(tenSanPham) && !String.IsNullOrEmpty(hinhAnh) && !String.IsNullOrEmpty(trangThai) && !String.IsNullOrEmpty(soLuong) && !String.IsNullOrEmpty(soLuongCon) && !String.IsNullOrEmpty(moTa))
                    {
                        sanPhamModel.updateProduct(item);
                        return RedirectToAction("Update");
                    }
                }
            return View(item);
        }

        //XÓA SẢN PHẨM
        public ActionResult Delete()
        {
            return View(getAllProduct());
        }

        public ActionResult DeleteProduct(string call, string maSanPham, string maLoai, string tenSanPham, string hinhAnh, string dvt, string trangThai, string soLuong, string soLuongCon, string moTa)
        {
            SanPham item = new SanPham(maSanPham, maLoai, tenSanPham, hinhAnh, dvt, Int32.Parse(trangThai), Int32.Parse(soLuong), Int32.Parse(soLuongCon), moTa);
            if (!String.IsNullOrEmpty(call))
                if (call.Equals("Xóa sản phẩm"))
                {
                    Debug.WriteLine("Cập nhật:" + maSanPham);
                    if (!String.IsNullOrEmpty(maSanPham) && !String.IsNullOrEmpty(maLoai) && !String.IsNullOrEmpty(tenSanPham) && !String.IsNullOrEmpty(hinhAnh) && !String.IsNullOrEmpty(trangThai) && !String.IsNullOrEmpty(soLuong) && !String.IsNullOrEmpty(soLuongCon) && !String.IsNullOrEmpty(moTa))
                    {
                        sanPhamModel.deleteProduct(maSanPham);
                        return RedirectToAction("Delete");
                    }
                }
            return View(item);
        }

        //THÔNG TIN CHI TIẾT MỘT SẢN PHẨM
        public ActionResult Detail(String maSP)
        {
            SanPham item = sanPhamModel.getDetailProduct(maSP);
            return View(item);
        }
    }
}