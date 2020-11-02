using BTLWebASP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLWebASP.Areas.Admin.Controllers
{
    public class LoaiHangController : Controller
    {
        LoaiHangModel LoaiHangModel = new LoaiHangModel();
        // GET: Admin/LoaiHang
        public ActionResult Index()
        {
            return View(getAllLoaiHang());
        }

        public List<LoaiHang> getAllLoaiHang()
        {
            return LoaiHangModel.getAll();
        }

        //THÊM LOẠI HÀNG MỚI
        public ActionResult CreateLoaiHang(string cal, string maLoai, string tenLoai, string HinhLoai)
        {
            LoaiHang sanPham = LoaiHangModel.getOneNewLoaiHang();
            if (!String.IsNullOrEmpty(cal))
            {
                if (cal.Equals("Thêm"))
                {
                    if (!String.IsNullOrEmpty(maLoai) && !String.IsNullOrEmpty(tenLoai))
                    {
                        LoaiHang item = new LoaiHang(maLoai, tenLoai, HinhLoai);
                        LoaiHangModel.addLoaiSP(item);
                    }
                    LoaiHang LH = LoaiHangModel.getOneNewLoaiHang();
                    return View(LH);
                }
            }
            return View(sanPham);
        }

        //CẬP NHẬT LOẠI HÀNG
        public ActionResult Update()
        {
            return View(getAllLoaiHang());
        }

        public ActionResult UpdateLoaiHang(string call, string maLoai, string tenLoai, string hinhLoai)
        {
            LoaiHang item = new LoaiHang(maLoai, tenLoai, hinhLoai);
            if (!String.IsNullOrEmpty(call))
                if (call.Equals("Cập nhật"))
                {
                    Debug.WriteLine("Cập nhật:" + maLoai);
                    if (!String.IsNullOrEmpty(maLoai) && !String.IsNullOrEmpty(maLoai) && !String.IsNullOrEmpty(tenLoai))
                    {
                        LoaiHangModel.updateLoaiHang(item);
                        return RedirectToAction("Update");
                    }
                }
            return View(item);
        }

        //XÓA SẢN PHẨM
        public ActionResult Delete()
        {
            return View(getAllLoaiHang());
        }

        public ActionResult DeleteLoaiHang(string call, string maLoai, string tenLoai, string hinhLoai)
        {
            LoaiHang item = new LoaiHang(maLoai, tenLoai, hinhLoai);
            if (!String.IsNullOrEmpty(call))
                if (call.Equals("Xóa loại hàng"))
                {
                    Debug.WriteLine("Cập nhật:" + maLoai);
                    if (!String.IsNullOrEmpty(maLoai) && !String.IsNullOrEmpty(tenLoai))
                    {
                        LoaiHangModel.deleteProduct(maLoai);
                        return RedirectToAction("Delete");
                    }
                }
            return View(item);
        }


        //THÔNG TIN CHI TIẾT LOẠI HÀNG
        public ActionResult Detail(String maSP)
        {
            LoaiHang item = LoaiHangModel.getDetailLH(maSP);
            return View(item);
        }
    }
}