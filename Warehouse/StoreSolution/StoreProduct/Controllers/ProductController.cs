using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace StoreProduct.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ShowProducts(string id)
        {
            Repository db = new Repository();
            ViewBag.Store = id;
            return View(db.GetStoreProducts(id));
        }
    }
}