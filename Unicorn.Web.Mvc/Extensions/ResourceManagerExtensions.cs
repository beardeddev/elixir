using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Threading;
using System.Web.Mvc;
using System.Web;

namespace Unicorn.Web.Mvc.Extensions
{
    using Unicorn.Web.Mvc.Html;

    /// <summary>
    /// 
    /// </summary>
    public static class ResourceManagerExtensions
    {
        /// <summary>
        /// Gets the HTML string.
        /// </summary>
        /// <param name="resourceManager">The resource manager.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static IHtmlString GetHtmlString(this ResourceManager resourceManager, string key)
        {
            if (resourceManager == null)
            {
                throw new NullReferenceException("Resource type required  for translation is missing.");
            }

            string value = resourceManager.GetString(key, Thread.CurrentThread.CurrentCulture);

            if (string.IsNullOrEmpty(value))
            {
                TagBuilder tagBuilder = new TagBuilder("span");
                tagBuilder.AddCssClass("help-inline translation-missing");
                tagBuilder.InnerHtml = string.Format("Translation missing for key '{0}' in bundle '{1}' for culture '{2}'.", key, resourceManager.BaseName, Thread.CurrentThread.CurrentCulture);
                return tagBuilder.ToMvcHtmlString();
            }

            return MvcHtmlString.Create(value);
        }
    }
}
