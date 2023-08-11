using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        //_object için sınıf ataması yapan constructor
        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T p)
        {
            var DeletedEntity = c.Entry(p);
            DeletedEntity.State = EntityState.Deleted;
            // _object.Remove(p);
            c.SaveChanges();
        }
        
        public void Insert(T p)
        {
            var AddedEntity = c.Entry(p);
            AddedEntity.State = EntityState.Added;
            //_object.Add(p);
            c.SaveChanges();
        }
        public void Update(T p)
        {
            var UpdatedEntity = c.Entry(p);
            UpdatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }



        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

       
    }
}
