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
    public class TimeLinesController : Controller
    {
        private UserContext db = new UserContext();

        // GET: TimeLines
        public ActionResult Index()
        {
            var timeLines = db.TimeLines.Include(t => t.Aim);
            return View(timeLines.ToList());
        }

        // GET: TimeLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeLine timeLine = db.TimeLines.Find(id);
            if (timeLine == null)
            {
                return HttpNotFound();
            }
            return View(timeLine);
        }

        // GET: TimeLines/Create
        public ActionResult Create()
        {
            ViewBag.AimId = new SelectList(db.Aims, "Id", "Name");
            return View();
        }

        // POST: TimeLines/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Text,PreviewText,Date,AimId")] TimeLine timeLine)
        {
            if (ModelState.IsValid)
            {
                db.TimeLines.Add(timeLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AimId = new SelectList(db.Aims, "Id", "Name", timeLine.AimId);
            return View(timeLine);
        }

        // GET: TimeLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeLine timeLine = db.TimeLines.Find(id);
            if (timeLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.AimId = new SelectList(db.Aims, "Id", "Name", timeLine.AimId);
            return View(timeLine);
        }

        // POST: TimeLines/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Text,PreviewText,Date,AimId")] TimeLine timeLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AimId = new SelectList(db.Aims, "Id", "Name", timeLine.AimId);
            return View(timeLine);
        }

        // GET: TimeLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeLine timeLine = db.TimeLines.Find(id);
            if (timeLine == null)
            {
                return HttpNotFound();
            }
            return View(timeLine);
        }

        // POST: TimeLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeLine timeLine = db.TimeLines.Find(id);
            db.TimeLines.Remove(timeLine);
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
