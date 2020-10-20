using BTLWebASP.Models;
using System.Collections.Generic;
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
            //
            ViewBag.BestSellingProduct = getBestSellingProducts();
            return View();
        }

        public List<SanPham> getSaleProducts()
        {
            return sanPhamModel.getSPSale(2);
        }

        public List<SanPham> getBestSellingProducts()
        {
            return sanPhamModel.getAllSP(2);
        }

        public ActionResult ProductDetail()
        {
            return View();
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