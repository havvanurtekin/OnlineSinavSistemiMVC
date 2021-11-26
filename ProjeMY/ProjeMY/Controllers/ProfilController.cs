using ProjeMY.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeMY.Controllers
{
    public class ProfilController : Controller
    {
        // GET: ProfilPage
        OnlineSinavSistemiEntities1 db = new OnlineSinavSistemiEntities1();
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {

                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            if (Session["User"] != null)
            {
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("Login", "Users");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var usr = db.User.FirstOrDefault(x => x.UserId == id);
            return View(usr);
        }

        [HttpPost]
        public ActionResult Guncelle(User model)
        {
            if (ModelState.IsValid)
            {
                var usr = db.User.FirstOrDefault(x => x.UserId == model.UserId);
                

                usr.UserName = model.UserName;
                usr.FirstName = model.FirstName;
                usr.Surname = model.Surname;
                usr.Password = model.Password;
                usr.ConfirmPassword = model.ConfirmPassword;
               
                if (Session["User"] == null)
                {

                    return RedirectToAction("Login", "Users");
                }
                if (db.SaveChanges() > 0)
                {

                    if (Session["User"] != null)
                    {
                        Session.Clear();
                        Session.Abandon();
                        return RedirectToAction("Login", "Users");
                    }
                    return RedirectToAction("Login","Users");
                }
                else
                {
                    RedirectToAction("Index");
                }
              
            }
            

            return View(model);
        }
    }
}