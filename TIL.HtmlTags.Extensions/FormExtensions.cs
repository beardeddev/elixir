using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.Mvc;

namespace TIL.Web.Mvc.Html
{
    using TIL.Data;

    public static class FormExtensions
    {
        public static MvcForm BeginFormFor<TKey>(this HtmlHelper htmlHelper, IEntity<TKey> model)
        {
            RouteValueDictionary routeValues = htmlHelper.ViewContext.RequestContext.RouteData.Values;
            string action = routeValues["action"].ToString().ToLower() == "new" ? "create" : "update";
            string controller = routeValues["controller"].ToString().ToLower();
            string name = model.GetType().Name.ToLower();
            string id = string.Format("{0}_{1}", action, name);
            return htmlHelper.BeginForm(action, controller, FormMethod.Post, new { @id = id, @name = name, @class = "widget-content" });
        }
    }
}
