using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteNews.Models;

namespace WebsiteNews.Controllers
{
    public class CacLoaiTinController : Controller
    {
        DataNewsEntities db = new DataNewsEntities();
        // GET: CacLoaiTin
        public PartialViewResult CacLoaiTin()
        {
            return PartialView(db.tbLoaiTinTucs.ToList());
        }
    }
}