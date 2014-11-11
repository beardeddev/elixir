using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Fuse.Web.Mvc.Html
{
    using System.Web.Mvc;
    using Fuse.Resources;

    public static class ResourceExtensions
    {
        private static string GetResourceString(HttpContextBase httpContext, string classKey, string resourceKey)
        {
            string value = httpContext.GetGlobalResourceObject(classKey, resourceKey) as string;

            if (string.IsNullOrEmpty(value))
            {
                string message = string.Format("Translation missing for key '{0}' in bundle '{1}' for culture '{2}'.", resourceKey, classKey, Thread.CurrentThread.CurrentCulture);
                throw new ResourceNotFoundException(message);
            }
            
            return value;
        }

        internal static string ResourceString(HttpContextBase httpContext, string classKey, string resourceKey)
        {
            try
            {
                return ResourceExtensions.GetResourceString(httpContext, classKey, resourceKey);
            }
            catch(Exception ex)
            {
                TagBuilder tagBuilder = new TagBuilder("span");
                tagBuilder.AddCssClass("help-inline translation-missing alert alert-warning");
                tagBuilder.InnerHtml = ex.Message;
                return tagBuilder.ToString();
            }
        }

        /// <summary>
        /// Resources the specified helper.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="classKey">The class key.</param>
        /// <param name="resourceKey">The resource key.</param>
        /// <returns></returns>
        public static MvcHtmlString Resource(this HtmlHelper helper, string classKey, string resourceKey)
        {
            return ResourceExtensions.ResourceString(helper.ViewContext.HttpContext, classKey, resourceKey).ToMvcHtmlString();            
        }

        /// <summary>
        /// Resources the specified helper.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="classKey">The class key.</param>
        /// <param name="resourceKey">The resource key.</param>
        /// <returns></returns>
        public static MvcHtmlString Resource(this HtmlHelper helper, string classKey, params string[] resourceKey)
        {
            return ResourceExtensions.ResourceString(helper.ViewContext.HttpContext, classKey, string.Join("_", resourceKey)).ToMvcHtmlString();
        }

        /// <summary>
        /// Renders the resource.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="classKey">The class key.</param>
        /// <param name="resourceKey">The resource key.</param>
        public static void RenderResource(this HtmlHelper helper, string classKey, string resourceKey)
        {
            string value = ResourceExtensions.ResourceString(helper.ViewContext.HttpContext, classKey, resourceKey);
            helper.ViewContext.Writer.WriteLine(value);
        }
    }
}