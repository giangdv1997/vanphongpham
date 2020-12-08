using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom1_VanPhongPham.Models;

namespace Nhom1_VanPhongPham.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();

        public ActionResult Index()
        {
            ViewBag.cats = db.DanhMucs.Select(c => c).ToList();
             var results = db.SanPhams.Select(s => s).GroupBy(s => s.DanhMuc).Take(5)
                .Select(x => new { cat = x.Key, products = x.Take(4).ToList() })
                .ToList();
            List<ProductByCat> productByCats = new List<ProductByCat>();
            results.ForEach(e =>
            {
                ProductByCat productByCat = new ProductByCat();
                productByCat.cat = e.cat;
                productByCat.products = e.products;
                productByCats.Add(productByCat);
            });
            return View(productByCats);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult News()
        {

            return View();
        }
        
        public ActionResult Preview(int? id)
        {
            var product = db.SanPhams.FirstOrDefault(e => e.MaSanPham == id);
            return View(product);
        }
        
        public PartialViewResult _CategoryList()
        {
            var cats = db.DanhMucs.Select(c => c).ToList();
            return PartialView(cats);
        }
        
        public PartialViewResult _RelatedProducts(String productName)
        {
            string[] keywords = productName.Split(' ');

            var results = db.SanPhams.Select(s => s);

            foreach (string k in keywords)
            {

                results = from a in results
                          where a.TenSanPham.Contains(k)
                          select a;
            }
            return PartialView(results.ToList());
        }


    }
}