using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using BLToolkit.Data;
using BLToolkit.Data.Linq;
using BLToolkit.DataAccess;

namespace Unicorn.Data.BLToolkit
{
    using Unicorn.Extensions;
    using Unicorn.Data.Contracts;
    using Unicorn.Data.Common;
        
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        private bool disposed = false;
        private DbManager dbManager;

        public Repository(IDbManagerFactory factory)
        {
            this.dbManager = factory.GetDbManager();
        }

        public Repository(IDbConnection connection)
        {
            this.dbManager = new DbManager(connection);
        }

        protected Table<TEntity> Table
        {
            get
            {
                return this.dbManager.GetTable<TEntity>();
            }
        }

        protected SqlQuery<TEntity> Query
        {
            get
            {
                return new SqlQuery<TEntity>(this.dbManager);
            }
        }

        public TEntity GetById(TKey id)
        {
            return this.Query.SelectByKey(id);
        }

        public List<TEntity> GetAll()
        {
            return this.Query.SelectAll();
        }

        public IPagedCollection<TEntity> GetPaged(IFilter<TEntity, TKey> filter)
        {
            TEntity[] slice = this.Table.Where(filter.Where)
                .OrderBy(filter.OrderBy)
                .Skip((filter.PageIndex - 1) * filter.PageSize)
                .Take(filter.PageSize).ToArray();

            int totalCount = this.Table.Count(filter.Where);

            return new PagedCollection<TEntity>(slice, filter.PageIndex, filter.PageSize, totalCount);
        }

        public TEntity Insert(TEntity entity)
        {
            TKey id = this.dbManager.InsertWithIdentity(entity).GetValue<TKey>();
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
            this.dbManager.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this.dbManager.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            this.dbManager.RollbackTransaction();
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
                    if (this.dbManager != null)
                    {
                        this.dbManager.Dispose();
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
