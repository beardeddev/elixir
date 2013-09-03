using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sophist.Web.Mvc.Html
{
    using Sophist.Web.Mvc.Scaffolding;
    using Sophist.Web.Mvc.UI;
    using System.Collections;

    public static class GridExtensions
    {
        //public static Grid<T> Grid<T>(this HtmlHelper htmlHelper, IEnumerable<T> model, IDictionary<string, object> htmlAttributes)
        //    where T : class, IEntity
        //{
        //    return new Grid<T>(model, htmlHelper.ViewContext, htmlAttributes);
        //}

        public static Grid Grid(this HtmlHelper htmlHelper, IEnumerable model, IDictionary<string, object> htmlAttributes)
        {
            return new Grid(model, htmlHelper.ViewContext, htmlAttributes);
        }
    }
}
