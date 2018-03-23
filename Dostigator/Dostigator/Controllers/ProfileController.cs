using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dostigator.Models;

namespace Dostigator.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<User> user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.Where(x => x.Email.Contains(User.Identity.Name)).ToList();
                }

                ViewBag.Hello = user;
                return View();
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
            
        }
    }
}