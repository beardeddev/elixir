using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLToolkit.Data;
using BLToolkit.Data.Linq;
using BLToolkit.DataAccess;

namespace TIL.Data.Entity
{
    using TIL.Extensions;

    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        private bool disposed = false;
        private DbManager context;

        public Repository(IDbManagerFactory factory)
        {
            this.context = factory.GetDbManager();
        }

        protected Table<TEntity> Table
        {
            get
            {
                return this.context.GetTable<TEntity>();
            }
        }

        protected SqlQuery<TEntity> Query
        {
            get
            {
                return new SqlQuery<TEntity>(this.context);
            }
        }

        public TEntity GetById(TKey id)
        {            
            return this.Query.SelectByKey(id);
        }

        public IList<TEntity> GetAll()
        {
            return this.Query.SelectAll();
        }

        public IPagedCollection<TEntity> GetPaged(IFilter<TEntity, TKey> filter)
        {
            TEntity[] slice = this.Table.Where(filter.Where)
                .OrderBy(filter.OrderBy)
                .Skip(filter.PageIndex * filter.PageSize)
                .Take(filter.PageSize).ToArray();

            int totalCount = this.Table.Count(filter.Where);

            return new PagedCollection<TEntity>(slice, filter.PageIndex + 1, filter.PageSize, totalCount);
        }

        public TEntity Insert(TEntity entity)
        {
            TKey id = this.context.InsertWithIdentity(entity).GetValue<TKey>();
            return this.GetById(id);
        }

        public TEntity Update(TEntity entity)
        {
            this.Query.Update(entity);
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            this.Query.Delete(entity);
            return entity;
        }

        public void BeginTransaction()
        {
            this.context.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this.context.CommitTransaction();
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
