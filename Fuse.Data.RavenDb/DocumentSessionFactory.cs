using Raven.Client;
using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Data.RavenDb
{
    public class DocumentSessionFactory : IDocumentSessionFactory
    {
        private IDocumentStore documentStore;

        public DocumentSessionFactory(IDocumentStore documentStore)
        {
            if (documentStore == null)
            {
                throw new ArgumentNullException("documentStore");
            }

            this.documentStore = documentStore;
        }

        public IDocumentSession GetSession()
        {
            return documentStore.OpenSession();
        }
    }
}
