using Fuse.Data.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Data.EntityFramework
{
    public class Repository<T, TKey> : Fuse.Data.IRepository<T, TKey>
        where T : class, IEntity<TKey>
    {
        private bool disposed;

        protected DbContext DbContext { get; private set; }

        protected IDbSet<T> DbSet
        {
            get
            {
                return this.DbContext.Set<T>();
            }
        }

        public Repository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.DbContext = context;
        }

        public virtual T GetById(TKey id)
        {
            return this.DbSet.Find(id);
        }

        public virtual IPagedCollection GetPaged(IFilter<T, TKey> filter)
        {
            T[] entities = this.DbSet
                .OrderBy(filter.OrderBy)
                .Where(filter.Where)
                .Skip(filter.PageIndex - 1 * filter.PageSize)
                .Take(filter.PageSize)
                .ToArray();

            int totalCount = this.DbSet.Count(filter.Where);

            return new PagedCollection<T>(entities, filter.PageIndex, filter.PageSize, totalCount);

        }

        public virtual T Insert(T entity)
        {
            this.DbSet.Add(entity);
            this.DbContext.SaveChanges();
            return entity;
        }

        public virtual T Update(T entity)
        {
            this.DbSet.Attach(entity);
            this.DbContext.Entry(entity).State = EntityState.Modified;
            this.DbContext.SaveChanges();
            return entity;
        }

        public virtual T Delete(T entity)
        {
            this.DbSet.Remove(entity);
            this.DbContext.SaveChanges();
            return entity;
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
                    if (this.DbContext != null)
                    {
                        this.DbContext.Dispose();
                    }
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="RepositoryBase"/> is reclaimed by garbage collection.
        /// </summary>
        ~Repository()
        {
            Dispose(false);
        }
    }
}
