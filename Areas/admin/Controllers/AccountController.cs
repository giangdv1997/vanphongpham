using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom1_VanPhongPham.Areas.admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: admin/Account
        public ActionResult Index()
        {
            ViewBag.accounts = new string[3] { "giang1", "giang2", "giang3" };
            return View();
        }
    }
}