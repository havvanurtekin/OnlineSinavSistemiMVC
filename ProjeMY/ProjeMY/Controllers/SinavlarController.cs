using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeMY.Controllers
{
    public class SinavlarController : Controller
    {
        // GET: Sinavlar
     
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
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}