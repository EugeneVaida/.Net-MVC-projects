using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dostigator.Models;
using System.Data.Entity;
using System.Net;


namespace Dostigator.Controllers
{
    public class ProfileController : Controller
    {
        private UserContext db = new UserContext();       

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


        // GET: Aims/Details/5
        public ActionResult AimDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aim aim = db.Aims.Find(id);
            if (aim == null)
            {
                return HttpNotFound();
            }
            return View(aim);
        }


        public ActionResult CreateAim()
        {
            if (User.Identity.IsAuthenticated)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.Where(x => x.Email.Contains(User.Identity.Name)).FirstOrDefault();
                }

                ViewBag.UserId = user.Id;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAim([Bind(Include = "Id,Name,Text,Date,Img,Group,UserId")] Aim aim)
        {
            if (ModelState.IsValid)
            {
                /*User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.Where(x => x.Email.Contains(User.Identity.Name)).FirstOrDefault();
                }

                aim.UserId = user.Id;*/
                db.Aims.Add(aim);
                db.SaveChanges();
                return RedirectToAction("Index", "Profile");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", aim.UserId);
            return View(aim);
        }

        
        public ActionResult EditAim(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aim aim = db.Aims.Find(id);
            if (aim == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = aim.UserId;
            return View(aim);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAim([Bind(Include = "Id,Name,Text,Date,Img,Group,UserId")] Aim aim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", aim.UserId);
            return View(aim);
        }

        
        public ActionResult DeleteAim(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aim aim = db.Aims.Find(id);
            if (aim == null)
            {
                return HttpNotFound();
            }
            return View(aim);
        }

        
        [HttpPost, ActionName("DeleteAim")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aim aim = db.Aims.Find(id);
            db.Aims.Remove(aim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}