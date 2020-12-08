using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom1_VanPhongPham.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: admin/Product
        public ActionResult Index()
        {
            ViewBag.products = new string[3] { "kẹo 1", "kẹo 2", "kẹo 3" };
            return View();
        }
    }
}