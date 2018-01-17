using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{  [Table("Yorumlar")]
   public class Yorum
    {   [Key]
        public int YorumID { get; set; }
        [Required, StringLength(300)]
        public string Icerik { get; set; }
       
        public virtual Not Notlar { get; set; }
        public virtual Kullanıcı Kullanicilar { get; set; }
    }
}
