using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sophist.Resources
{
    using Sophist.Web.Mvc.Html;

    public static class ResourceManagerExtensions
    {
        private static string GetResourceString(this ResourceManager resourceManager, string key)
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

        public static IHtmlString GetHtmlString(this ResourceManager resourceManager, string key)
        {
            try
            {
                return MvcHtmlString.Create(resourceManager.GetResourceString(key));
            }
            catch (ResourceNotFoundException ex)
            {
                TagBuilder tagBuilder = new TagBuilder("span");
                tagBuilder.AddCssClass("help-inline translation-missing error");
                tagBuilder.InnerHtml = ex.Message;
                return tagBuilder.ToMvcHtmlString();
            }
        }
    }
}
