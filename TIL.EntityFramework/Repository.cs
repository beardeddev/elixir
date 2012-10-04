using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace TIL.Data.Entity
{

    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        private bool disposed = false;
        private DbContext context;

        public Repository(IDbContextFactory factory)
        {
            this.context = factory.GetDbContext();
        }

        protected IDbSet<TEntity> DbSet
        {
            get
            {
                return this.context.Set<TEntity>();
            }
        }

        public TEntity GetById(TKey id)
        {
            return this.DbSet.Find(id);
        }

        public IList<TEntity> GetAll()
        {
            return this.DbSet.ToList();
        }

        public IPagedCollection<TEntity> GetPaged(IFilter<TEntity, TKey> filter)
        {
            TEntity[] slice = this.DbSet.Where(filter.Where)
                .OrderBy(filter.OrderBy)
                .Skip(filter.PageIndex * filter.PageSize)
                .Take(filter.PageSize).ToArray();

            int totalCount = this.DbSet.Count(filter.Where);

            return new PagedCollection<TEntity>(slice, filter.PageIndex + 1, filter.PageSize, totalCount);
        }

        public TEntity Insert(TEntity entity)
        {
            return this.DbSet.Add(entity);
        }

        public TEntity Update(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = System.Data.EntityState.Modified;
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            return this.DbSet.Remove(entity);
        }

        public void BeginTransaction()
        {
        }

        public void CommitTransaction()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (this.context != null)
                    {
                        this.context.Dispose();
                    }
                }
                disposed = true;
            }
        }

        ~Repository()
        {
            Dispose(false);
        }
    }
}
