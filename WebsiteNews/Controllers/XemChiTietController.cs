using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteNews.Models;

namespace WebsiteNews.Controllers
{
    
    public class XemChiTietController : Controller
    {
        DataNewsEntities db = new DataNewsEntities();
        // GET: XemChiTiet
        public ActionResult XemChiTiet(int ? matintuc)
        {
            luotxemtintuc(matintuc);
            return View(db.tbTinTucs.SingleOrDefault(n=>n.MaTinTuc==matintuc));
        }
        public void luotxemtintuc(int ? matintuc)
        {
            int dem = (int)db.tbTinTucs.Find(matintuc).LuotXemTinTuc;
            dem++;
            db.tbTinTucs.Find(matintuc).LuotXemTinTuc = dem;
            db.SaveChanges();
        }
    }
}