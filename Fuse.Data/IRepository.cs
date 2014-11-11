using System;
namespace Fuse.Data
{
    public interface IRepository<T, TKey> : IDisposable
     where T : IEntity<TKey>
    {
        T Delete(T entity);
        T GetById(TKey id);
        /// <summary>
        /// Gets a page of rows from the DataSource.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Returns a paged collection of Entity objects.</returns>
        IPagedCollection GetPaged(IFilter<T, TKey> filter);
        T Insert(T entity);
        T Update(T entity);
    }
}
