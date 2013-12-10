using CocoFarm.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocoFarm.DataAccess
{
    public class EFDataStore<T> : IDataStore<T> where T : class, IEntityWithId
    {
        readonly CocoFarmContext context = new CocoFarmContext();

        public IEnumerable<T> GetAll()
        {
            var q = context.Set<T>();
            return q.AsEnumerable<T>();
        }

        public T GetById(Guid id)
        {
            return context.Set<T>().Where(x => x.Id == id).FirstOrDefault();
        }

        public T Create(T entity)
        {
            var ent = context.Set<T>();
            ent.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public T Update(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var cont = context.Set<T>();
            var item = cont.Where(x => x.Id == id).FirstOrDefault<T>();
            cont.Remove(item);
            context.SaveChanges();
        }
    }
}
