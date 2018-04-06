using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dostigator.Models;

namespace Dostigator.Controllers
{
    public class AimController : Controller
    {
        // GET: Aim
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aim model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.Where(x => x.Email.Contains(User.Identity.Name)).FirstOrDefault();
                }

                Aim aim = new Aim { Name = model.Name, Text = model.Text, FinishDate = model.FinishDate, Img = model.Img, Group = model.Group, UserId = user.Id  };
                // создаем нового пользователя
                using (UserContext db = new UserContext())
                {
                    db.Aims.Add(aim);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Profile"); 
            }

            return View(model);
        }
    }
}