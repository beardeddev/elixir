using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TIL.Web.Mvc.Html
{
    public static class StringExtensions
    {
        public static MvcHtmlString ToMvcHtmlString(this string value)
        {
            return new MvcHtmlString(value);
        }

        public static MvcHtmlString ToMvcHtmlString(string format, params object[] args)
        {
            return new MvcHtmlString(string.Format(format, args));
        }
    }
}
