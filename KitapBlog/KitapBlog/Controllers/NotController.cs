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
    public class NotController : Controller
    {

        private NotRep nRep = new NotRep();
        private BegeniRep bRep = new BegeniRep();
        
        public ActionResult Index()
        {
         

            Kullanıcı kul;
            kul = Session["kullanici"] as Kullanıcı;
            var notlar = nRep.List().Where(x => x.Kullanicilar == kul).OrderByDescending(x=>x.Tarih);
            return View(notlar.ToList());
        }

        public ActionResult FavoriNotlar()
        {
            Kullanıcı kul;
            kul = Session["kullanici"] as Kullanıcı;
           var notlar= bRep.List().Where(x => x.Kullanicilar == kul).Select(x => x.Notlar).OrderByDescending(x=>x.Tarih);
            return View("Index",notlar.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = nRep.Find(x => x.NotID == id.Value);
            if (not == null)
            {
                return HttpNotFound();
            }
            return View(not);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Not not)
        {
            if (ModelState.IsValid)
            {
                Kullanıcı kul;
                kul = Session["kullanici"] as Kullanıcı;
                not.Kullanicilar=kul;
                nRep.Insert(not);
                return RedirectToAction("Index");
            }

            return View(not);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = nRep.Find(x => x.NotID == id.Value);
            if (not == null)
            {
                return HttpNotFound();
            }
            return View(not);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Not not)
        {
            if (ModelState.IsValid)
            {
                Not Not = nRep.Find(x => x.NotID ==not.NotID);
                Not.Kategoriler = not.Kategoriler;
                Not.Baslik = not.Baslik;
                Not.Icerik = not.Icerik;
                nRep.Update(Not);
                return RedirectToAction("Index");
            }
            return View(not);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = nRep.Find(x => x.NotID == id.Value);
            if (not == null)
            {
                return HttpNotFound();
            }
            return View(not);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Not not = nRep.Find(x => x.NotID == id);
            nRep.Delete(id);
            return RedirectToAction("Index");
        }

        public JsonResult NotOy(int oy, int id)
        {
            Kullanıcı kul;
            kul = Session["kullanici"] as Kullanıcı;
            try
            {
                if (Session["HasVoted_" + id] == null || (bool)Session["HasVoted_" + id] != true)
                {                  
                    Begeni b = new Begeni();
                    Not secilen = nRep.GetById(id);
                    string isim = kul.KullaniciAdi;
                    if (secilen.BegeniSayisi.HasValue)
                    {
                        secilen.BegeniSayisi = secilen.BegeniSayisi.Value + oy;
                        //b.Notlar.Baslik = secilen.Baslik;
                        //b.Notlar.BegeniSayisi = oy;
                       
                        bRep.Insert(b);
                    }
                    else
                    {
                        secilen.BegeniSayisi = oy;
                        //b.Notlar.Baslik = secilen.Baslik;
                        //b.Notlar.BegeniSayisi = oy;
                        
                        bRep.Insert(b);
                    }
                    nRep.Update(secilen);
                    Session["Hasvoted_" + id] = true;
                    return Json("Oy verdiğiniz için teşekkürler.");
                }
                else
                    return Json("Tekrar oy veremezsiniz.");
            }
            catch (Exception ex)
            {

                return Json("Bir hata oluştu." + ex.Message);
            }
        }

        public ActionResult Goster(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = nRep.Find(x => x.NotID == id.Value);
            if (not == null)
            {
                return HttpNotFound();
            }
            return PartialView("_PartialNot",not);
        }
        
    }
}
