using Nhom1_VanPhongPham.Areas.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom1_VanPhongPham.Areas.admin.Controllers
{
    public class CategoryController : Controller
    {

        Model1 model1 = new Model1();
        // GET: admin/Category
        public ActionResult Index()
        {
            List<DanhMuc> listDanhMuc = model1.DanhMucs.ToList();
            // ViewBag.cats = new string[3] { "Danhmuc1", "Danhmuc2", "Danhmuc3" };
            return View(listDanhMuc);
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            DanhMuc danhMuc = model1.DanhMucs.Where(item => item.MaDanhMuc == id).First();
            return View(danhMuc);
        }

        [HttpPost]
        public ActionResult UpdateAction(DanhMuc dm)
        {
            DanhMuc danhMuc = model1.DanhMucs.Where(item => item.MaDanhMuc == dm.MaDanhMuc).First();
            model1.DanhMucs.Add(dm);
            return RedirectToAction("Index");
        }
    }
}