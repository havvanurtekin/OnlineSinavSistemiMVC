using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeMY.Models.Entity;


namespace ProjeMY.Controllers
{
    public class DerslerController : Controller
    {
        // GET: Dersler
        OnlineSinavSistemiEntities1 db = new OnlineSinavSistemiEntities1();

        public ActionResult Sil(int id)
        {
            if (Session["User"] == null)
            {

                return RedirectToAction("Login", "Users");
            }
            var drs = db.tblDersler.Find(id);
            db.tblDersler.Remove(drs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var d = db.tblDersler.ToList();
            if (Session["User"] == null)
            {

                return RedirectToAction("Login", "Users");
            }
            return View(d);
        }

        [HttpGet]
        public ActionResult DersEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DersEkle(tblDersler drs)
        {
            
            if (!ModelState.IsValid)
            {
                return RedirectToAction("DersEkle", "Dersler");
            }
         
            if (drs.Sinav1.Equals(null))
            {
                drs.Sinav1 = 0;
            }
            else if (drs.Sinav2.Equals(null))
            {
                drs.Sinav2 = 0;
            }
            else if (drs.Sinav3.Equals(null))
            {
                drs.Sinav3 = 0;
            }
           
           
            float ort = (float)((drs.Sinav1 + drs.Sinav2 + drs.Sinav3) / 3);

            drs.Ortalama = ort;
            if (drs.Ortalama > 60)
            {
                drs.Basari = "Geçti";
            }
            else
            {
                drs.Basari = "Kaldı";
            }
            if (Session["User"] == null)
            {

                return RedirectToAction("Login", "Users");
            }
            var u = db.User.FirstOrDefault(x => x.UserId == drs.UserId);
            if (u != null)
            {
             db.tblDersler.Add(drs);
            db.SaveChanges();
            TempData["Message"] = "Ders Başarıyla Eklendi!";
            
            return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "Kullanıcı Bulunamadı!";
                return View();
            }
        }

        public ActionResult SelectDers()
        {

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Fen Bilgisi", Value = "fen", Selected = true });

            items.Add(new SelectListItem { Text = "Türkçe", Value = "turkce" });

            items.Add(new SelectListItem { Text = "Matematik", Value = "mat" });

            ViewBag.DersAdi = items;

            return View();

        }
      
        public ActionResult Getir(int id)
        {
            var drs = db.tblDersler.FirstOrDefault(x => x.DersId == id);
            return View(drs);
        }
        [HttpPost]
        public ActionResult Getir(tblDersler model)
        {
            
           
            if (ModelState.IsValid)
            {
                var drs = db.tblDersler.FirstOrDefault(x => x.DersId == model.DersId);

                drs.Sinav1 = model.Sinav1;
                drs.Sinav2 = model.Sinav2;
                drs.Sinav3 = model.Sinav3;

                if (drs.Sinav1.Equals(null))
                {
                    drs.Sinav1 = 0;
                }
                 if (drs.Sinav2.Equals(null))
                {
                    drs.Sinav2 = 0;
                }
                 if (drs.Sinav3.Equals(null))
                {
                    drs.Sinav3 = 0;
                }

                float ort = (float)((drs.Sinav1 + drs.Sinav2 + drs.Sinav3) / 3);

                drs.Ortalama = ort;
                if (drs.Ortalama > 60)
                {
                    drs.Basari = "Geçti";
                }
                else
                {
                    drs.Basari = "Kaldı";
                }
                if (Session["User"] == null)
                {

                    return RedirectToAction("Login", "Users");
                }
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
                if (db.SaveChanges() < 0)
                {
                    return RedirectToAction("Index");
                }
            }
           
            
            return View(model);
        }
      
    }
}