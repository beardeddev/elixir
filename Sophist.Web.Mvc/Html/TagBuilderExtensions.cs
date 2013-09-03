using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sophist.Web.Mvc.Html
{
    internal static class TagBuilderExtensions
    {
        internal static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode = TagRenderMode.Normal)
        {
            return new MvcHtmlString(tagBuilder.ToString(renderMode));
        }

        internal static MvcHtmlString ToMvcHtmlString(this string value)
        {
            return new MvcHtmlString(value);
        }
    }
}
