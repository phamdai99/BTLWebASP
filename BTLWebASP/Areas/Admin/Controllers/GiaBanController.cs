using BTLWebASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLWebASP.Areas.Admin.Controllers
{
    public class GiaBanController : Controller
    {
        GiaBanModel model = new GiaBanModel();
        // GET: Admin/GiaBan
        public ActionResult Index()
        {
            return View(model.getAllGiaBan());
        }
        
        public ActionResult CreateGiaBan(string cal, string MaGB, string MaSP, string Gia, string NgayBD, string NgayKT)
        {
            if (!String.IsNullOrEmpty(cal))
            {
                if (cal.Equals("Thêm"))
                {
                    if (!String.IsNullOrEmpty(MaGB) && !String.IsNullOrEmpty(MaSP) && !String.IsNullOrEmpty(Gia))
                    {
                        GiaBan item = new GiaBan(MaGB, MaSP, Gia,DateTime.Parse(NgayBD),DateTime.Parse(NgayKT));
                        model.addGB(item);
                    }
                }
            }
            return View();
        }

        //CẬP NHẬT GIÁ BÁN
        public ActionResult Update()
        {
            return View(getAllGiaBan());
        }

        public List<GiaBan> getAllGiaBan()
        {
            return model.getAllGiaBan();
        }

        public ActionResult UpdateGiaBan(string call, string maGB, string maSP, string gia,DateTime ngayBD,DateTime ngayKT)
        {
            GiaBan item = new GiaBan(maGB, maSP, gia,ngayBD,ngayKT);
            if (!String.IsNullOrEmpty(call))
                if (call.Equals("Cập nhật"))
                {
                    if (!String.IsNullOrEmpty(maSP) && !String.IsNullOrEmpty(gia))
                    {
                        model.updateGB(item);
                        return RedirectToAction("Update");
                    }
                }
            return View(item);
        }

        public ActionResult Delete()
        {
            return View(getAllGiaBan());
        }

        public ActionResult DeleteGiaBan(string call, string maGB, string maSP, string gia, DateTime ngayBD, DateTime ngayKT)
        {
            GiaBan item = new GiaBan(maGB, maSP, gia, ngayBD, ngayKT);
            if (!String.IsNullOrEmpty(call))
                if (call.Equals("Xóa giá bán"))
                {
                    if (!String.IsNullOrEmpty(maGB) && !String.IsNullOrEmpty(maSP))
                    {
                        model.deleteGB(maGB);
                        return RedirectToAction("Delete");
                    }
                }
            return View(item);
        }
    }
}