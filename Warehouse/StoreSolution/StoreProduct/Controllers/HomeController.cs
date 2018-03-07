using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using Domain;

namespace StoreProduct.Controllers
{
    public class HomeController : Controller
    {
        Repository db = new Repository();

        public ActionResult Index()
        { 
            return View(db.GetStores());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница описания";

            return View();
        }

        
    }
}