using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Threading;

namespace Elixir.Web.Mvc.Extensions
{
    public static class ResourceManagerExtensions
    {
        public static string GetResourceString(this ResourceManager resourceManager, string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            if (key == string.Empty)
            {
                throw new ArgumentException("Parameter 'key' cannot be an empty string");
            }

            string value = resourceManager.GetString(key, Thread.CurrentThread.CurrentCulture);

            if (string.IsNullOrEmpty(value))
            {
                string message = string.Format("Translation missing for key '{0}' in bundle '{1}' for culture '{2}'.", key, resourceManager.BaseName, Thread.CurrentThread.CurrentCulture);
                throw new ResourceNotFoundException(message);
            }

            return value;
        }
    }
}
