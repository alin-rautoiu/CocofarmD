using CocoFarm.Model;
using System;
using System.Collections.Generic;

namespace CocoFarm.DataAccess
{
    public interface IDataStore<T>
        where T : IEntityWithId
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Create(T entity);
        T Update(T entity);
        void Delete(Guid id);
    }
}
