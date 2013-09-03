using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.Data.EntityFramework
{
    public class Repository<T, TKey> : IRepository<T, TKey>
        where T : class, IEntity<TKey>
    {
        private bool disposed = false;
        private DbContext dbContext;

        public Repository(IDbContextFactory factory)
        {
            this.dbContext = factory.GetDbContext();
        }

        protected virtual IDbSet<T> DbSet
        {
            get
            {
                return this.dbContext.Set<T>();
            }
        }

        public virtual T GetById(TKey id)
        {
            return this.dbContext.Set<T>().Find(id);
        }

        public virtual IPagedCollection<T> GetPaged(IFilter<T> filter)
        {
            T[] entities = this.DbSet
                .OrderBy(filter.OrderBy)
                .Where(filter.Where)
                .Skip((filter.PageIndex - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToArray();

            int totalCount = this.DbSet.Count(filter.Where);

            return new PagedCollection<T>(entities, filter.PageIndex, filter.PageSize, totalCount);

        }

        public virtual T Insert(T entity)
        {
            T inserted = this.DbSet.Add(entity);
            this.dbContext.SaveChanges();
            return inserted;
        }

        public virtual T Update(T entity)
        {
            this.DbSet.Attach(entity);
            this.dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual T Delete(T entity)
        {
            return this.DbSet.Remove(entity);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (this.dbContext != null)
                    {
                        this.dbContext.Dispose();
                    }
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Repository{T}"/> is reclaimed by garbage collection.
        /// </summary>
        ~Repository()
        {
            Dispose(false);
        }
    }
}
