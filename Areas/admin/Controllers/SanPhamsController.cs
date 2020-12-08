using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Nhom1_VanPhongPham.Areas.admin.Dto;
using Nhom1_VanPhongPham.Areas.admin.Models;
using PagedList;

namespace Nhom1_VanPhongPham.Areas.admin.Controllers
{
    public class SanPhamsController : Controller
    {
        private Model1 db = new Model1();

        // GET: admin/SanPhams
        public ActionResult Index(int page = 1, string search = "")
        {
            ViewBag.search = search;
            var sanPhams = db.SanPhams.Select(item => item)
                .OrderBy(item => item.MaSanPham)
                .Where(item => item.TenSanPham.Contains(search));
            return View(sanPhams.ToPagedList(page, 10));
        }

        // GET: admin/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }

            List<SanPhamMauSac> spMsList = db.SanPhamMauSacs.Select(item => item)
                .Where(item => item.MaSanPham == id)
                .ToList();
            ViewBag.sanPhamMauSacList = spMsList;
            return View(sanPham);
        }

        // GET: admin/SanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,TenSanPham,TongSoLuong,XuatXu,QuyCach,DonViTinh,MaDanhMuc,AnhSanPham")] SanPham sanPham)
        {
            var colors = Request.Params["colors"];
            var quantities = Request.Params["quantities"];
            var file = Request.Files["imgProd"];
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = file.FileName.Trim();
                    file.SaveAs(Server.MapPath("~/wwwroot/img/") + fileName);
                    sanPham.AnhSanPham = fileName;
                    if(quantities != null && quantities.Length > 0)
                    {
                        sanPham.TongSoLuong = quantities.Split(',').Sum(i => int.Parse(i));
                    }
                }

                db.SanPhams.Add(sanPham);
                db.SaveChanges();

                //save color
                if (colors != null && colors.Length > 0)
                {
                    string[] arrQuantity = quantities.Split(',');
                    string[] arrColor = colors.Split(',');
                    for(int i = 0; i< arrColor.Length; i ++)
                    {
                        MauSac savedColor = this.saveColor(arrColor[i]);
                        this.saveProductColor(sanPham, savedColor, arrQuantity[i]);
                    }
                }

                return RedirectToAction("Index");
            }
            return View(sanPham);
        }

        // GET: admin/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }

            List<SanPhamMauSac> spMsList = db.SanPhamMauSacs.Select(item => item)
                .Where(item => item.MaSanPham == id)
                .ToList();
            ViewBag.sanPhamMauSacList = new JavaScriptSerializer().Serialize(spMsList);

            return View(sanPham);
        }

        // POST: admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,TenSanPham,TongSoLuong,XuatXu,QuyCach,DonViTinh,MaDanhMuc,AnhSanPham")] SanPham sanPham)
        {
            var colors = Request.Params["colors"];
            var quantities = Request.Params["quantities"];
            
            if(colors != null && quantities !=null)
            {
                string[] arrColor = colors.Split(',');
                string[] arrQuantity = quantities.Split(',');
                sanPham.TongSoLuong = arrQuantity.Sum(item => int.Parse(item));

                for(int i= 0; i< arrColor.Length;i ++)
                {
                    var colorCode = arrColor[i];
                    SanPhamMauSac spMs =  db.SanPhamMauSacs.Select(el => el)
                        .Where(el => el.MaMau.Equals(colorCode) && el.MaSanPham == sanPham.MaSanPham).First();
                    if(spMs != null)
                    {
                        spMs.SoLuongCon = int.Parse(arrQuantity[i]);
                        db.Entry(spMs).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            
            var file = Request.Files["imgProd"];
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = file.FileName.Trim();
                    file.SaveAs(Server.MapPath("~/wwwroot/img/") + fileName);
                    sanPham.AnhSanPham = fileName;
                }

                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }

        // GET: admin/SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            List<SanPhamMauSac> listSpMs = db.SanPhamMauSacs.Select(spMs => spMs)
                .Where(spMs => spMs.MaSanPham == id)
                .ToList();
            listSpMs.ForEach(el => { 
                db.SanPhamMauSacs.Remove(el); 
                db.SaveChanges(); 
            });

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        protected MauSac saveColor(string colorCode)
        {
            MauSac mauSac = null;
            try
            {
                mauSac = db.MauSacs.Select(mau => mau)
                    .Where(mau => mau.MaMau.Equals(colorCode))
                    .First();
                return mauSac;
            }catch(Exception e)
            {
                mauSac = new MauSac();
                mauSac.MaMau = colorCode;
                mauSac =  db.MauSacs.Add(mauSac);
                db.SaveChanges();
                return mauSac;
            }
        }

        protected SanPhamMauSac saveProductColor(SanPham sp, MauSac mauSac, string quantity)
        {
            try
            {
                SanPhamMauSac spMs = new SanPhamMauSac();
                spMs.MaMau = mauSac.MaMau;
                spMs.MaSanPham = sp.MaSanPham;
                spMs.SoLuongCon = int.Parse(quantity);
                spMs = db.SanPhamMauSacs.Add(spMs);
                db.SaveChanges();
                return spMs;
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}
