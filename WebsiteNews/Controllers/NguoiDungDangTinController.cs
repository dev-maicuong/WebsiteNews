using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteNews.Models;

namespace WebsiteNews.Controllers
{
    public class NguoiDungDangTinController : Controller
    {
        private DataNewsEntities db = new DataNewsEntities();

        // GET: NguoiDungDangTin
        public ActionResult Index()
        {
            tbNguoiDung nd = (tbNguoiDung)Session["nguoidung"];
            return View(db.tbTinTucs.Where(n=>n.MaNguoiDung == nd.MaNguoiDung).ToList());
        }

        // GET: NguoiDungDangTin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTinTuc tbTinTuc = db.tbTinTucs.Find(id);
            if (tbTinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tbTinTuc);
        }

        // GET: NguoiDungDangTin/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiTinTuc = new SelectList(db.tbLoaiTinTucs, "MaLoaiTinTuc", "TenLoaiTin");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTinTuc,TenTinTuc,MaLoaiTinTuc,NoiDungTinTuc,NgayDangTinTuc,LuotXemTinTuc,MaNguoiDung,AnhTinTuc,IfrVideo,video,TrangThaiTin")] tbTinTuc tbTinTuc, HttpPostedFileBase fileUpload, HttpPostedFileBase fileUploadVideo)
        {
            // Ảnh
            var fileimg = Path.GetFileName(fileUpload.FileName);
            var pa = Path.Combine(Server.MapPath("~/Content/Layout_NguoiDung/images"),fileimg);
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }
            else if (System.IO.File.Exists(pa))
            {
                ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
            }
            else
            {
                fileUpload.SaveAs(pa);
            }
            //Video
            var filevideo = Path.GetFileName(fileUploadVideo.FileName);
            var pv = Path.Combine(Server.MapPath("~/Content/video"), filevideo);
            if(fileUploadVideo == null)
            {
                ViewBag.ThongBao = "Chọn video";
                return View();
            }
            else if (System.IO.File.Exists(pv))
            {
                ViewBag.ThongBao = "Video đã tồn tại!";
            }
            else
            {
                fileUploadVideo.SaveAs(pv);
            }
            tbTinTuc.video = fileUploadVideo.FileName;
            tbTinTuc.LuotXemTinTuc = 0;
            tbTinTuc.NgayDangTinTuc = DateTime.Now;
            tbTinTuc.AnhTinTuc = fileUpload.FileName;
            db.tbTinTucs.Add(tbTinTuc);
            db.SaveChanges();
            ViewBag.MaLoaiTinTuc = new SelectList(db.tbLoaiTinTucs, "MaLoaiTinTuc", "TenLoaiTin", tbTinTuc.MaLoaiTinTuc);
            return RedirectToAction("Index");
        }

        // GET: NguoiDungDangTin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTinTuc tbTinTuc = db.tbTinTucs.Find(id);
            if (tbTinTuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiTinTuc = new SelectList(db.tbLoaiTinTucs, "MaLoaiTinTuc", "TenLoaiTin", tbTinTuc.MaLoaiTinTuc);
            return View(tbTinTuc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTinTuc,TenTinTuc,MaLoaiTinTuc,NoiDungTinTuc,NgayDangTinTuc,LuotXemTinTuc,MaNguoiDung,AnhTinTuc,IfrVideo,video,TrangThaiTin")] tbTinTuc tbTinTuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbTinTuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiTinTuc = new SelectList(db.tbLoaiTinTucs, "MaLoaiTinTuc", "TenLoaiTin", tbTinTuc.MaLoaiTinTuc);
            return View(tbTinTuc);
        }

        // GET: NguoiDungDangTin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTinTuc tbTinTuc = db.tbTinTucs.Find(id);
            if (tbTinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tbTinTuc);
        }

        // POST: NguoiDungDangTin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbTinTuc tbTinTuc = db.tbTinTucs.Find(id);
            db.tbTinTucs.Remove(tbTinTuc);
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
