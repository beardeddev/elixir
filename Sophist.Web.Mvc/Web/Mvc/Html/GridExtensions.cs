using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections;

namespace Sophist.Web.Mvc.Html
{
    using Sophist.Data;
    using Sophist.Web.Mvc.UI;
    
    public static class GridExtensions
    {
        public static Grid Grid(this HtmlHelper htmlHelper, IEnumerable model, IDictionary<string, object> htmlAttributes)
        {
            return new Grid(model, htmlHelper.ViewContext, htmlAttributes);
        }

        public static Grid Grid(this HtmlHelper htmlHelper, IEnumerable model)
        {
            return GridExtensions.Grid(htmlHelper, model, null);
        }
    }
}
