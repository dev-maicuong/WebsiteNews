using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteNews.Models;

namespace WebsiteNews.Controllers
{
    public class HomeController : Controller
    {
        DataNewsEntities db = new DataNewsEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult TinMoiNgayHomNay()
        {
            var bien = db.tbTinTucs.OrderByDescending(n => n.NgayDangTinTuc).Where(n => n.NgayDangTinTuc.Value.Day == DateTime.Now.Day && n.TrangThaiTin == true).Take(3).ToList();
            if(bien.Count() == 0)
            {
                ViewBag.thongbao = "Hôm nay chưa có tin mới";
            }
            return PartialView(bien);
        }
        public PartialViewResult TinCongNghe()
        {
            return PartialView(db.tbTinTucs.Where(n=>n.tbLoaiTinTuc.TenLoaiTin == "Tin công nghệ" && n.TrangThaiTin == true).OrderByDescending(n=>n.NgayDangTinTuc).Take(2).ToList());
        }
        public PartialViewResult TinTheThao()
        {
            return PartialView(db.tbTinTucs.Where(n=>n.tbLoaiTinTuc.TenLoaiTin == "Tin thể thao" && n.TrangThaiTin == true).OrderByDescending(n=>n.NgayDangTinTuc).Take(3).ToList());
        }
        public PartialViewResult TinTaiChinh()
        {
            return PartialView(db.tbTinTucs.Where(n=>n.tbLoaiTinTuc.TenLoaiTin == "Tin tài chính" && n.TrangThaiTin == true).OrderByDescending(n=>n.NgayDangTinTuc).Take(3).ToList());
        }
        public PartialViewResult TinXe()
        {
            return PartialView(db.tbTinTucs.Where(n => n.tbLoaiTinTuc.TenLoaiTin == "Tin xe" && n.TrangThaiTin == true).OrderByDescending(n => n.NgayDangTinTuc).Take(3).ToList());
        }
        public PartialViewResult TinThoiTrang()
        {
            return PartialView(db.tbTinTucs.Where(n => n.tbLoaiTinTuc.TenLoaiTin == "Tin thời trang" && n.TrangThaiTin == true).OrderByDescending(n => n.NgayDangTinTuc).Take(3).ToList());
        }
        public PartialViewResult TinAmThuc()
        {
            return PartialView(db.tbTinTucs.Where(n => n.tbLoaiTinTuc.TenLoaiTin == "Tin ẩm thực" && n.TrangThaiTin == true).OrderByDescending(n => n.NgayDangTinTuc).Take(2).ToList());
        }
        public PartialViewResult TinDuLich()
        {
            return PartialView(db.tbTinTucs.Where(n => n.tbLoaiTinTuc.TenLoaiTin == "Tin du lịch" && n.TrangThaiTin == true).OrderByDescending(n => n.NgayDangTinTuc).Take(2).ToList());
        }
        public PartialViewResult CacTinNgayHomQua()
        {
            return PartialView(db.tbTinTucs.Where(n=>n.NgayDangTinTuc.Value.Day == DateTime.Now.Day -1 && n.TrangThaiTin == true).OrderByDescending(n=>n.NgayDangTinTuc.Value.Hour).Take(7).ToList());
        }
        public PartialViewResult TinDocNhieuNhat()
        {
            return PartialView(db.tbTinTucs.OrderByDescending(n => n.LuotXemTinTuc).Where(n=>n.TrangThaiTin == true).Take(4).ToList());
        }
        public PartialViewResult TopNguoiDangTin()
        {
            return PartialView(db.tbNguoiDungs.OrderByDescending(n => n.SoTinDang).Take(5).ToList());
        }
        public PartialViewResult Video()
        {
            return PartialView(db.tbTinTucs.OrderByDescending(n=>n.NgayDangTinTuc).Take(2).ToList());
        }
    }
}