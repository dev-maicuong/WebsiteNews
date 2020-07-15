using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteNews.Models;

namespace WebsiteNews.Controllers
{
    public class tbNguoiDungsController : Controller
    {
        private DataNewsEntities db = new DataNewsEntities();

        // GET: tbNguoiDungs
        public ActionResult Index()
        {
            return View(db.tbNguoiDungs.ToList());
        }

        // GET: tbNguoiDungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNguoiDung tbNguoiDung = db.tbNguoiDungs.Find(id);
            if (tbNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(tbNguoiDung);
        }

        // GET: tbNguoiDungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbNguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNguoiDung,TenNguoiDung,EmailNguoiDung,MatKhauNguoiDung,DiaChiNguoiDung,SDTNguoiDung,AnhNguoiDung,SoTinDang")] tbNguoiDung tbNguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.tbNguoiDungs.Add(tbNguoiDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbNguoiDung);
        }

        // GET: tbNguoiDungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNguoiDung tbNguoiDung = db.tbNguoiDungs.Find(id);
            if (tbNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(tbNguoiDung);
        }

        // POST: tbNguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNguoiDung,TenNguoiDung,EmailNguoiDung,MatKhauNguoiDung,DiaChiNguoiDung,SDTNguoiDung,AnhNguoiDung,SoTinDang")] tbNguoiDung tbNguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbNguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbNguoiDung);
        }

        // GET: tbNguoiDungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNguoiDung tbNguoiDung = db.tbNguoiDungs.Find(id);
            if (tbNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(tbNguoiDung);
        }

        // POST: tbNguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbNguoiDung tbNguoiDung = db.tbNguoiDungs.Find(id);
            db.tbNguoiDungs.Remove(tbNguoiDung);
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
    }
}
