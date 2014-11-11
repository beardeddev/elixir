using Fuse.Data.Common;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Data.RavenDb
{
    public class Repository<T> : IRepository<T>
     where T : Document
    {        
        private bool disposed;

        /// <summary>
        /// Gets the session.
        /// </summary>
        /// <value>
        /// The session.
        /// </value>
        protected IDocumentSession Session { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T, TKey}"/> class.
        /// </summary>
        /// <param name="Session">The Session.</param>
        public Repository(IDocumentSessionFactory sessionFactory)
        {
            this.Session = sessionFactory.GetSession();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public T Delete(T entity)
        {
            this.Session.Delete(entity);
            return entity;
        }

        /// <summary>
        /// Gets the document by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return this.Session.Load<T>(id);
        }

        /// <summary>
        /// Gets a page of document from the DataSource.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Returns a Paged Collection of Document objects.</returns>
        public IPagedCollection GetPaged(IFilter<T, int> filter)
        {
            T[] entities = this.Session.Query<T>()
               .OrderBy(filter.OrderBy)
               .Where(filter.Where)
               .Skip((filter.PageIndex - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToArray();

            int totalCount = this.Session.Query<T>().Count(filter.Where);

            return new PagedCollection<T>(entities, filter.PageIndex, filter.PageSize, totalCount);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public T Insert(T entity)
        {
            this.Session.Store(entity);
            return entity;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public T Update(T entity)
        {
            this.Session.Store(entity);
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
                    if (this.Session != null)
                    {
                        this.Session.SaveChanges();
                        this.Session.Dispose();
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
