using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{  [Table("Begeniler")]
   public class Begeni
    {
        [Key]
        public int BegeniID { get; set; }
        public virtual Not Notlar { get; set; }
        public virtual Kullanıcı Kullanicilar { get; set; }
    }
}
