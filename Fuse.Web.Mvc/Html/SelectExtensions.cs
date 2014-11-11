using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Fuse.Web.Mvc.Html
{
    public static class SelectExtensions
    {
        public static MvcHtmlString BooleanDropDownList(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
        {
            bool? value = null;
            bool isNewAction = true; //TODO: Fix to use routenames

            if (htmlHelper.ViewData.Model != null)
            {
                value = Convert.ToBoolean(htmlHelper.ViewData.Model, System.Globalization.CultureInfo.InvariantCulture);
            }

            List<SelectListItem> TriStateValues = new List<SelectListItem> 
            {
                new SelectListItem { Text = "NotSet", //TODO: get from resources
                                        Value = String.Empty,
                                        Selected = isNewAction },
                new SelectListItem { Text = "True",
                                        Value = "true",
                                        Selected = (value.HasValue && value.Value) && !isNewAction },
                new SelectListItem { Text = "False",
                                        Value = "false",
                                        Selected = (value.HasValue && !value.Value) && isNewAction },
            };

            return htmlHelper.DropDownList(name, TriStateValues, htmlAttributes);
        }

        public static MvcHtmlString BooleanDropDownList(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return SelectExtensions.BooleanDropDownList(htmlHelper, name, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
    }
}