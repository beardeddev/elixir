using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using HtmlTags;

namespace TIL.HtmlTags
{
    using TIL.Data;

    public static class InputExtensions
    {
        public static HtmlTag CheckBoxForModel<TKey>(this HtmlHelper htmlHelper, IEntity<TKey> entity)
        {
            return new HtmlTag("input")
                .Attr("type", "checkbox")
                .Attr("value", entity.Id)
                .Data("action", "check-id");                
        }

        public static HtmlTag CheckBoxForCheckAll(this HtmlHelper htmlHelper)
        {
            return new HtmlTag("input")
                .Attr("type", "checkbox")
                .Data("action", "check-all");
        }
    }
}
