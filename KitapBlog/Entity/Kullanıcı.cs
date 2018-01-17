using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{  [Table("Kullanicilar")]
   public class Kullanıcı
    {   [Key]
        public int KullanıcıID { get; set; }
        [StringLength(25)]
        public string Ad { get; set; }
        [StringLength(25)]
        public string Soyad { get; set; }
        [Required, StringLength(25)]
        public string KullaniciAdi { get; set; }
        [Required, StringLength(70)]
        public string Email { get; set; }
        [Required, StringLength(25)]
        public string Sifre { get; set; }
       

        public bool AdminMi { get; set; }

        public virtual List<Not> Notlar { get; set; }
        public virtual List<Yorum> Yorumlar { get; set; }
        public virtual List<Begeni> Begeniler { get; set; }
        
    }
}
