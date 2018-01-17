using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{  [Table("Notlar")]
   public class Not
    {   [Key]
        public int NotID { get; set; }
        [Required, StringLength(60)]
        public string Baslik { get; set; }
        [Required, StringLength(2000)]
        public string Icerik { get; set; }
        
        public int? BegeniSayisi { get; set; }


        [Required]
        public DateTime Tarih { get; set; }
        



        public virtual Kullanıcı Kullanicilar { get; set; }
        public virtual List<Yorum> Yorumlar { get; set; }
        public virtual Kategori Kategoriler { get; set; }

        public virtual List<Begeni> Begeniler { get; set; }
        public Not()
        {
            Yorumlar = new List<Yorum>();
            Begeniler = new List<Begeni>();
            Tarih = DateTime.Now;
        }
    }
}
