using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Unicorn.Web.Mvc.Html
{
    internal static class HtmlHelperExtensions
    {
        public static IApplicationController Controller(this HtmlHelper htmlHelper)
        {
            return (IApplicationController)htmlHelper.ViewContext.Controller;
        }

        public static UrlHelper Url(this HtmlHelper htmlHelper)
        {
            return new UrlHelper(htmlHelper.ViewContext.RequestContext);
        }
    }
}
