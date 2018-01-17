using Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class BlogContext: IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Begeni> Begeniler { get; set; }
        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<Kullanıcı> Kullanicilar { get; set; }
        public virtual DbSet<Not> Notlar { get; set; }
        public virtual DbSet<Yorum> Yorumlar { get; set; }
    }
}
