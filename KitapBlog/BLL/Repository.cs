using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Repository<T>:BaseRepository where T:class
    {
        private BlogContext db;
        public Repository()
        {
            db = BaseRepository.ContextOlustur();
        }
        public List<T> List()
        {
            List<T> liste = db.Set<T>().ToList();
            return liste;
        }
        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void Insert (T obj)
        {
            db.Set<T>().Add(obj);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.Set<T>().Find(id);
            db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
        public void Update(T obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}
