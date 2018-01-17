using Entity;
using Entity.KullaniciYonetim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class KullaniciYonetimi
    {
        private KullaniciRep kRep = new KullaniciRep();
        public Kullanıcı KullaniciYonetim(KayıtView data)
        {
            Kullanıcı kul = kRep.Find(x => x.KullaniciAdi == data.KullaniciAdi || x.Email == data.Email);
            if (kul != null)
            {
                throw new Exception("Kayıtlı kullanıcı adı veya eposta adresi");
            }
            else
            {
                kRep.Insert(new Kullanıcı()
                {
                    KullaniciAdi = data.KullaniciAdi,
                    Email = data.Email,
                    Sifre = data.Sifre,
                    Ad=data.Ad,
                    Soyad=data.Soyad,
                    AdminMi=false
                });
            }
            return kul;
        }
        public Kullanıcı KullaniciGiris(GirisView data)
        {
            Kullanıcı kul = kRep.Find(x => x.KullaniciAdi == data.KullaniciAdi || x.Sifre == data.Sifre);
            if (kul!=null)
            {
                return kul;
            }
            else
            {
                throw new Exception("Kullanıcı adı veya şifre uyuşmuyor.");
            }

        }
    }
}
