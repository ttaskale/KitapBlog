using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entity.KullaniciYonetim
{
    public class GirisView
    {   [Required(ErrorMessage ="Kullanıcı adı boş geçilemez.")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez."),DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}