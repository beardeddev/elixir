using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using HtmlTags;

namespace TIL.HtmlTags
{
    public static class DropDownExtensions
    {
        public static HtmlTag DropdownMenu(this HtmlHelper htmlHelper)
        {
            return new HtmlTag("ul")
                .AddClass("dropdown-menu");
        }

        public static HtmlTag Divider(this HtmlHelper htmlHelper)
        {
            return new HtmlTag("li")
                .AddClass("divider");
        }
    }
}
