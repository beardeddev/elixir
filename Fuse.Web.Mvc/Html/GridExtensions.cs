using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Fuse.Web.Mvc.Html
{
    public static class GridExtensions
    {
        public static MvcHtmlString Grid(this HtmlHelper htmlHelper, IEnumerable model, object htmlAttributes)
        {
            return GridExtensions.Grid(htmlHelper, model, (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Grid(this HtmlHelper htmlHelper, IEnumerable model, IDictionary<string, object> htmlAttributes)
        {   
            return htmlHelper.Partial("_Grid", model);
        }

        public static MvcHtmlString Grid(this HtmlHelper htmlHelper, IEnumerable model)
        {
            return GridExtensions.Grid(htmlHelper, model, null);
        }
    }
}