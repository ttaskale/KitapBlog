using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entity;
using KitapBlog.Models;
using BLL;

namespace KitapBlog.Controllers
{
    public class KullanıcıController : Controller
    {
        private KullaniciRep kRep = new KullaniciRep();

        // GET: Kullanıcı
        public ActionResult Index()
        {
            return View(kRep.List());
        }

        // GET: Kullanıcı/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcı kullanıcı = kRep.Find(x => x.KullanıcıID == id.Value);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                if (Session["kullanici"] == null)
                {
                    kRep.Insert(kullanıcı);
                    return RedirectToAction("Index");
                }            
            }

            return View(kullanıcı);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcı kullanıcı = kRep.Find(x => x.KullanıcıID == id.Value);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                Kullanıcı kul = kRep.Find(x => x.KullanıcıID == kullanıcı.KullanıcıID);
                kul.KullaniciAdi = kullanıcı.KullaniciAdi;
                kul.Ad = kullanıcı.Ad;
                kul.Sifre = kullanıcı.Sifre;
                kul.Soyad = kullanıcı.Soyad;
                kul.Email = kullanıcı.Email;
                kul.AdminMi = kullanıcı.AdminMi;
                kRep.Update(kul);
                return RedirectToAction("Index");
            }
            return View(kullanıcı);
        }

      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcı kullanıcı = kRep.Find(x => x.KullanıcıID == id.Value);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanıcı kullanıcı = kRep.Find(x => x.KullanıcıID == id);
            kRep.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
