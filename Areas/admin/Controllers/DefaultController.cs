﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom1_VanPhongPham.Areas.admin.Controllers
{
    public class DefaultController : Controller
    {
        // GET: admin/Default
        public ActionResult Index()
        {
            return Redirect("admin/Account/Index");
        }
    }
}