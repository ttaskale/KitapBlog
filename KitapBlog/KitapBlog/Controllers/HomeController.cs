using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            NotRep nRep = new NotRep();
            return View(nRep.List().OrderByDescending(x=>x.Tarih).ToList());
        }
        public ActionResult Kategori(int? id)
        {
            KategoriRep kRep = new KategoriRep();
            Kategori kategori = kRep.GetById(id.Value);
            return View("Index",kategori.Notlar);
        }

        public ActionResult EnBegenilenler()
        {
            NotRep nRep = new NotRep();
            return View("Index",nRep.List().OrderByDescending(x => x.BegeniSayisi).ToList());
        }
        public ActionResult Hakkımızda()
        {
             
            return View();
        }
        public ActionResult Giris()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Giris(Entity.KullaniciYonetim.GirisView model)
        { 
            if (ModelState.IsValid)
            {
                KullaniciRep kRep = new KullaniciRep();
                Kullanıcı kul = kRep.Find(x => x.KullaniciAdi == model.KullaniciAdi);
                KullaniciYonetimi kYon = new KullaniciYonetimi();
                kYon.KullaniciGiris(model);
                Session["kullanici"] =kul;
               
                return RedirectToAction("Index");

            }
            return View(model);
        }
        public ActionResult Cikis()
        {
            Session.Clear();
            return RedirectToAction("Index");          
        }
        public ActionResult KayitOl()
        {

            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Entity.KullaniciYonetim.KayıtView model)
        {

            if (ModelState.IsValid)
            {
                KullaniciYonetimi kYon = new KullaniciYonetimi();
                kYon.KullaniciYonetim(model);
            }
            return View(model);
        }
    }
}