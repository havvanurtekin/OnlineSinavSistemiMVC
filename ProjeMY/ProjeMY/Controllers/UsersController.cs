using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeMY.Model;
using ProjeMY.Models.Entity;

namespace ProjeMY.Controllers
{
    public class UsersController : Controller
    {
        
        // GET: Users
        OnlineSinavSistemiEntities1 db = new OnlineSinavSistemiEntities1();
        public ActionResult Index()
        {

            if (Session["User"] == null)
            {

                return RedirectToAction("Login", "Users");
            }
            var u = db.User.ToList();

                return View(u);
          
        }

        public ActionResult Sil(int id)
        {
            List<tblDersler> drs = new List<tblDersler>();
            if (Session["User"] == null)
            {

                return RedirectToAction("Login", "Users");
            }
            var usr = db.User.Find(id);
            
            foreach(var a in drs)
            {
                if(a.UserId == id)
                {
                    db.tblDersler.Remove(a);
                }
            }

            db.User.Remove(usr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User u1)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.User.Add(u1);
            db.SaveChanges();
            TempData["Message"] = "Registered Successfully";
            TempData["Message2"] = "You can enter the system by: " + u1.UserId.ToString();
            return View();
            
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {

            OnlineSinavSistemiEntities1 db = new OnlineSinavSistemiEntities1();

            var sorgu = db.User.FirstOrDefault(x => x.UserId == user.UserId && x.Password == user.Password);
            if (sorgu != null)
            {
                Session["User"] = sorgu;


                return RedirectToAction("AnaSayfa", "Users");
            }
            else
            {
                ModelState.AddModelError("", "User Id or Password is wrong.");
            }

            return View();
        }
        public ActionResult SelectStatu()
        {

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Öğrenci", Value = "ogrenci", Selected = true });

            items.Add(new SelectListItem { Text = "Öğretmen", Value = "ogretmen" });

            ViewBag.Statu = items;

            return View();

        }

        
        public ActionResult AnaSayfa()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

       [CheckSessionTimeOut]
        public ActionResult LogOut()
        {
            if (Session["User"] != null)
            {
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("Login", "Users");
            }
            return RedirectToAction("Login", "Users");
        }

        public ActionResult Dersler()
        {
            if (Session["User"] == null)
            {                
                return RedirectToAction("Login", "Users");
            }
            var u = db.tblDersler.ToList();
            return View(u);
        }

    }
}