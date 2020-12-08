using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom1_VanPhongPham.Areas.admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: admin/Category
        public ActionResult Index()
        {
            ViewBag.cats = new string[3] { "Danhmuc1", "Danhmuc2", "Danhmuc3" };
            return View();
        }
    }
}