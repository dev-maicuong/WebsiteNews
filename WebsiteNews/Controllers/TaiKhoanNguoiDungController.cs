using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteNews.Models;

namespace WebsiteNews.Controllers
{
    public class TaiKhoanNguoiDungController : Controller
    {
        DataNewsEntities db = new DataNewsEntities();
        // GET: TaiKhoanNguoiDung
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            tbNguoiDung nd;
            String email = f["frmEmail"].ToString();
            String password = f["frmMatKhau"].ToString();
            nd = db.tbNguoiDungs.SingleOrDefault(n => n.EmailNguoiDung == email && n.MatKhauNguoiDung == password);
            if (nd != null)
            {
                Session["nguoidung"] = nd;
                return Redirect("/Home/Index");
            }
            else
            {
                ViewBag.thongbao = " Sai tài khoản hoặc mật khẩu";
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["nguoidung"] = null;
            return Redirect("/Home/Index");
        }
        public ActionResult TaoTaiKhoan()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoTaiKhoan(FormCollection f,[Bind(Include = "MaNguoiDung,TenNguoiDung,EmailNguoiDung,MatKhauNguoiDung,DiaChiNguoiDung,SDTNguoiDung,AnhNguoiDung,SoTinDang")] tbNguoiDung tbNguoiDung, HttpPostedFileBase fileUpload)
        {
            var fileimg = Path.GetFileName(fileUpload.FileName);
            var pa = Path.Combine(Server.MapPath("~/Content/Layout_NguoiDung/images"), fileimg);
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }
            else if (System.IO.File.Exists(pa))
            {
                ViewBag.ThongBao2 = "Hình ảnh đã tồn tại!";
            }
            else
            {
                fileUpload.SaveAs(pa);
            }
            String matkhau = f["MatKhauNguoiDung"].ToString();
            String nhaplaimatkhau = f["NhapLaiMatKhauNguoiDung"].ToString();
            String email = f["EmailNguoiDung"].ToString();
            tbNguoiDung nd = db.tbNguoiDungs.FirstOrDefault(n => n.EmailNguoiDung == email);
            if(nd != null)
            {
                ViewBag.thongbao1 = "Email đã sử dụng";
            }
            else
            {
                if (matkhau == nhaplaimatkhau)
                {
                    tbNguoiDung.AnhNguoiDung = fileUpload.FileName;
                    db.tbNguoiDungs.Add(tbNguoiDung);
                    db.SaveChanges();
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.thongbao = "Sai mật khẩu nhập lại";
                }
            }
            return View(tbNguoiDung);
        }
    }
}