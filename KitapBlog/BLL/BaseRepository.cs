using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class BaseRepository
    {
        private static BlogContext db;
        public static BlogContext ContextOlustur()
        {
            if (db==null)
            {
                db = new BlogContext();
            }
            return db; 
        }
        protected BaseRepository()
        {
            ContextOlustur();
        }
    }
}
