using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteNews.Models;

namespace WebsiteNews.Controllers
{
    public class NguoiDungController : Controller
    {
        DataNewsEntities db = new DataNewsEntities();
        // GET: NguoiDung
        public ActionResult TrangChuNguoiDung()
        {
            tbNguoiDung nd = (tbNguoiDung)Session["nguoidung"];
            var bien = db.tbNguoiDungs.SingleOrDefault(n => n.MaNguoiDung == nd.MaNguoiDung);
            if (bien == null)
            {
                return Redirect("/Home/Index");
            }
            return View(bien);
        }
        public ActionResult DoiMatKhau()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoiMatKhau(FormCollection f)
        {
            tbNguoiDung nd = (tbNguoiDung)Session["nguoidung"];
            String mkcu = f["frMatKhauCu"].ToString();
            String mkmoi = f["frmMatKhauMoi"].ToString();
            String mklmkm = f["frmNhapLaiMatKhauMoi"].ToString();
            if(nd.MatKhauNguoiDung == mkcu)
            {
                if(mkmoi == mklmkm)
                {
                    db.tbNguoiDungs.Find(nd.MaNguoiDung).MatKhauNguoiDung = mkmoi;
                    db.SaveChanges();
                    return Redirect("/NguoiDung/TrangChuNguoiDung");
                }
                else
                {
                    ViewBag.thongbao10 = "Sai mật khẩu nhập lại";
                }
            }
            else
            {
                ViewBag.thongbao11 = " Sai mật khẩu cũ";
            }
            return View();
        }
        public ActionResult SuaThongTinCaNhan(int? id)
        {
            tbNguoiDung tbNguoiDung = db.tbNguoiDungs.Find(id);
            return View(tbNguoiDung);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaThongTinCaNhan([Bind(Include = "MaNguoiDung,TenNguoiDung,EmailNguoiDung,MatKhauNguoiDung,DiaChiNguoiDung,SDTNguoiDung,AnhNguoiDung,SoTinDang")] tbNguoiDung tbNguoiDung, HttpPostedFileBase fileUpload)
        {
            tbNguoiDung nd = (tbNguoiDung)Session["nguoidung"];
            if(fileUpload == null)
            {
                tbNguoiDung.AnhNguoiDung =nd.AnhNguoiDung ;
                tbNguoiDung.EmailNguoiDung = nd.EmailNguoiDung;
                db.Entry(tbNguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TrangChuNguoiDung");
            }
            else
            {
                var fileimg = Path.GetFileName(fileUpload.FileName);
                var pa = Path.Combine(Server.MapPath("~/Content/Layout_NguoiDung/images"), fileimg);
                if (System.IO.File.Exists(pa))
                {
                    ViewBag.Img = "Anh trung";
                }
                else
                {
                    fileUpload.SaveAs(pa);
                    tbNguoiDung.EmailNguoiDung = nd.EmailNguoiDung;
                    tbNguoiDung.AnhNguoiDung = fileUpload.FileName;
                    db.Entry(tbNguoiDung).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("TrangChuNguoiDung");
                }
            }
            return View(tbNguoiDung);
        }
    }
}