using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dostigator.Models;
using System.Data.Entity;


namespace Dostigator.Controllers
{
    public class ProfileController : Controller
    {         

        // GET: Profile
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.Where(x => x.Email.Contains(User.Identity.Name)).FirstOrDefault();
                    
                }

                IEnumerable<Aim> aim = null;
                using (UserContext db = new UserContext())
                {
                    aim = db.Aims.Include(y => y.User).ToList().Where(z => z.UserId == user.Id);
                } 
                
                ViewBag.Aims = aim;
                return View(user);
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
            
        }

        public ActionResult Aims()
        {
            if (User.Identity.IsAuthenticated)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.Where(x => x.Email.Contains(User.Identity.Name)).FirstOrDefault();

                }

                IEnumerable<Aim> aim = null;
                using (UserContext db = new UserContext())
                {
                    aim = db.Aims.Include(y => y.User).ToList().Where(z => z.UserId == user.Id);
                }

                ViewBag.Aims = aim;
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        
    }
}