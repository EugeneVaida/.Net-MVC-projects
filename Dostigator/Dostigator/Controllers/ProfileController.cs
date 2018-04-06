using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dostigator.Models;
using System.Data.Entity;
using System.Net;
using System.IO;


namespace Dostigator.Controllers
{
    public class ProfileController : Controller
    {
        private UserContext db = new UserContext();
        DateTime thisDay = DateTime.Today;

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
                ViewBag.User = user;
                return View();
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

                ViewBag.User = user;
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
            User user = null;
            using (UserContext db = new UserContext())
            {
                user = db.Users.Where(x => x.Email.Contains(User.Identity.Name)).FirstOrDefault();
            }

            ViewBag.User = user;
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

                ViewBag.User = user;
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
        public ActionResult CreateAim([Bind(Include = "Id,Name,PreviewText,Text,FinishDate,Group,UserId")] Aim aim, HttpPostedFileBase Img)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов                
                using (var binaryReader = new BinaryReader(Img.InputStream))
                {
                    imageData = binaryReader.ReadBytes(Img.ContentLength);
                }
                aim.Img = imageData;
                aim.StartDate = thisDay.ToString("d");
                db.Aims.Add(aim);
                db.SaveChanges();
                return RedirectToAction("Index", "Profile");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", aim.UserId);
            return View(aim);
        }

        
        public ActionResult EditAim(int? id)
        {
            User user = null;
            using (UserContext db = new UserContext())
            {
                user = db.Users.Where(x => x.Email.Contains(User.Identity.Name)).FirstOrDefault();
            }
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aim aim = db.Aims.Find(id);
            if (aim == null)
            {
                return HttpNotFound();
            }
            ViewBag.Img = aim.Img;
            aim.Img = null;
            ViewBag.User = user;
            ViewBag.UserId = aim.UserId;
            return View(aim);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAim([Bind(Include = "Id,Name,PreviewText,Text,FinishDate,Group,UserId")] Aim aim, HttpPostedFileBase Img)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов                
                using (var binaryReader = new BinaryReader(Img.InputStream))
                {
                    imageData = binaryReader.ReadBytes(Img.ContentLength);
                }
                aim.Img = imageData;
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