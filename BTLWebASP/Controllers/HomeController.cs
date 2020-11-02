using BTLWebASP.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;

namespace BTLWebASP.Controllers
{
    public class HomeController : Controller
    {
        SanPhamModel sanPhamModel = new SanPhamModel();
        GiaBanModel giaBanModel = new GiaBanModel();
        public ActionResult Index()
        {
            //đang giảm giá
            ViewBag.SaleProduct = getSaleProducts();
            //Sản phẩm mới
            ViewBag.newProduct = getNewProducts();
            //Sản phẩm sắp có
            ViewBag.comingSoonProduct = getComingSoonProducts();
            return View();
        }

        //lấy sản phẩm đang giảm giá
        public List<SanPham> getSaleProducts()
        {
            return sanPhamModel.getProductSale(2);
        }

        //lấy 10 sản phẩm mới nhất theo kiểu sp: 1= sắp có, 2=đã có
        public List<SanPham> getNewProducts()
        {
            return sanPhamModel.getNewProduct(2);
        }


        //lấy danh sách sản phẩm sắp có
        public List<SanPham> getComingSoonProducts()
        {
            return sanPhamModel.getCommingSoonProduct(1);
        }

        public ActionResult ProductDetail(string maSP)
        {
            //ViewBag.detailProduct = getDetailProduct(maSP);
            return View(getDetailProduct(maSP));
        }

        public SanPham getDetailProduct(string maSP)
        {
            return sanPhamModel.getDetailProduct(maSP);
        }

        //TÌM KIẾM SẢN PHẨM
        public ActionResult searchProducts(string keyword)
        {
            //ViewBag.detailProduct = getDetailProduct(maSP);
            Debug.WriteLine(keyword);
            return View(searchProduct(keyword));
        }

        public List<SanPham> searchProduct(string productName)
        {
            return sanPhamModel.searchProduct(productName);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}