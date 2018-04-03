using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dostigator.Models;

namespace Dostigator.Controllers
{
    public class AimsController : Controller
    {
        private UserContext db = new UserContext();

        // GET: Aims
        public ActionResult Index()
        {
            var aims = db.Aims.Include(a => a.User);
            return View(aims.ToList());
        }

        // GET: Aims/Details/5
        public ActionResult Details(int? id)
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

        
        // GET: Aims/Create
        public ActionResult Create()
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

        // POST: Aims/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Text,Date,Img,Group,UserId")] Aim aim)
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
                return RedirectToAction("Index","Profile");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", aim.UserId);
            return View(aim);
        }

        // GET: Aims/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", aim.UserId);
            return View(aim);
        }

        // POST: Aims/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Text,Date,Img,Group,UserId")] Aim aim)
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

        // GET: Aims/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Aims/Delete/5
        [HttpPost, ActionName("Delete")]
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
