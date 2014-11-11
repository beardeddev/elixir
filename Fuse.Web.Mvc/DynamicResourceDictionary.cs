using Fuse.Resources;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Fuse.Web.Mvc
{
    public class DynamicResourceDictionary : DynamicObject
    {
        private HttpContextBase httpContext;
        private string classKey;

        public DynamicResourceDictionary(HttpContextBase httpContext, string classKey)
        {
            if(httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            if (classKey == null)
            {
                throw new ArgumentNullException("classKey");
            }

            this.httpContext = httpContext;
            this.classKey = classKey;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string value = this.httpContext.GetGlobalResourceObject(classKey, binder.Name) as string;

            if (string.IsNullOrEmpty(value))
            {
                string message = string.Format("Translation missing for key '{0}' in bundle '{1}' for culture '{2}'.", classKey, binder.Name, Thread.CurrentThread.CurrentCulture);
                throw new ResourceNotFoundException(message);
            }
            else
            {
                result = value;
            }

            return true;
        }
    }
}
