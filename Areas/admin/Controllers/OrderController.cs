using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom1_VanPhongPham.Areas.admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: admin/Order
        public ActionResult Index()
        {
            ViewBag.orders = new string[3] { "ĐH01", "ĐH02", "ĐH03" };
            return View();
        }
    }
}