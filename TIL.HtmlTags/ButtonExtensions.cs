using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using HtmlTags;

namespace TIL.HtmlTags
{
    public static class ButtonExtensions
    {
        public static HtmlTag Button(this HtmlHelper htmlHelper)
        {
            return new HtmlTag("button")
                .AddClass("btn");
        }

        public static HtmlTag ButtonGroup(this HtmlHelper htmlHelper)
        {
            return new HtmlTag("div")
                .AddClass("btn-group");
        }

        public static HtmlTag ButtonDropdownToggle(this HtmlHelper htmlHelper)
        {
            return htmlHelper.Button()
                .AddClass("dropdown-toggle")
                .Data("toggle", "dropdown")
                .AppendHtml("<span class=\"caret\"></span>");
        }
    }
}
