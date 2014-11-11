using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fuse.Web.Mvc.Html
{
    internal static class TagBuilderExtensions
    {
        internal static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode = TagRenderMode.Normal)
        {
            return new MvcHtmlString(tagBuilder.ToString(renderMode));
        }
    }
}