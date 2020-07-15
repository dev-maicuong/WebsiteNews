using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteNews.Models;

namespace WebsiteNews.Controllers
{
    public class LocTheoCacLoaiTinController : Controller
    {
        DataNewsEntities db = new DataNewsEntities();
        // GET: LocTheoCacLoaiTin
        public ActionResult CacLoaiTin(int ? macacloaitin)
        {
            return View(db.tbTinTucs.Where(n=>n.MaLoaiTinTuc == macacloaitin).ToList());
        }
    }
}