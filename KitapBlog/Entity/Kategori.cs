using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{ [Table("Kategori")]
  public  class Kategori
    {   [Key]
        public int KategoriID { get; set; }
        [Required, StringLength(60)]
        public string Baslik { get; set; }
        [StringLength(200)]
        public string Tanitim { get; set; }
     

        public virtual List<Not> Notlar { get; set; }

        public Kategori()
        {
            Notlar = new List<Not>();
           
        }
    }
}
