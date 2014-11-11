using System;
namespace Fuse.Data.Core
{
    public interface IRepository<T, TKey> : IDisposable
     where T : class, IEntity<TKey>
    {
        T Delete(T entity);
        T GetById(TKey id);
        IPagedCollection GetPaged(IFilter<T, TKey> filter);
        T Insert(T entity);
        T Update(T entity);
    }
}
