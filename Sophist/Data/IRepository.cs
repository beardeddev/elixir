using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.Data
{
    public interface IRepository<T, TKey> : IDisposable
        where T : class, IEntity<TKey>
    {
        T GetById(TKey id);
        IPagedCollection<T> GetPaged(IFilter<T> filter);
        T Insert(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}