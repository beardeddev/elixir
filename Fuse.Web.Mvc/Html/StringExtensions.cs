using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fuse.Web.Mvc.Html
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts System.String to the MVC HTML string.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <returns></returns>
        internal static MvcHtmlString ToMvcHtmlString(this string value)
        {
            return MvcHtmlString.Create(value);
        }
    }
}