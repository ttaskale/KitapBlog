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
    public class KategoriController : Controller
    {

        private KategoriRep kRep = new KategoriRep();
       

        
        public ActionResult Index()
        {
            return View(kRep.List());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = kRep.Find(x=>x.KategoriID==id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                kRep.Insert(kategori);
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

      
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = kRep.Find(x=>x.KategoriID==id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                Kategori kat = kRep.Find(x => x.KategoriID == kategori.KategoriID);
                kat.Baslik = kategori.Baslik;
                kat.Tanitim = kategori.Tanitim;
                kRep.Update(kat);
               
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = kRep.Find(x=>x.KategoriID==id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategori kategori =kRep.Find(x=>x.KategoriID==id);
            kRep.Delete(id);
          
            return RedirectToAction("Index");
        }

       
    }
}
