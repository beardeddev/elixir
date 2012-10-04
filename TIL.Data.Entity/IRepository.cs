using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIL.Data.Entity
{
    public interface IRepository<TEntity, TKey> : IDisposable
        where TEntity : class, IEntity<TKey>, new()
    {
        TEntity GetById(TKey id);
        IList<TEntity> GetAll();
        IPagedCollection<TEntity> GetPaged(IFilter<TEntity, TKey> filter);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        void BeginTransaction();
        void CommitTransaction();
    }
}
