using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fuse.Data;
using RestfulRouting;

namespace Fuse.Web.Mvc.Html
{
    public static class UrlHelperExtensions
    {
        public static string Edit(this UrlHelper urlHelper, IEntity model)
        {
            RouteNames routeNames = urlHelper.RequestContext.HttpContext.Request.GetRouteNames();
            return urlHelper.Action(routeNames.EditName, new { @id = model.Id });
        }

        public static string Show(this UrlHelper urlHelper, IEntity model)
        {
            RouteNames routeNames = urlHelper.RequestContext.HttpContext.Request.GetRouteNames();
            return urlHelper.Action(routeNames.ShowName, new { @id = model.Id });
        }

        public static string Delete(this UrlHelper urlHelper, IEntity model)
        {
            RouteNames routeNames = urlHelper.RequestContext.HttpContext.Request.GetRouteNames();
            return urlHelper.Action(routeNames.DeleteName, new { @id = model.Id });
        }

        public static string New(this UrlHelper urlHelper)
        {
            RouteNames routeNames = urlHelper.RequestContext.HttpContext.Request.GetRouteNames();
            return urlHelper.Action(routeNames.NewName);
        }

        public static string Index(this UrlHelper urlHelper)
        {
            RouteNames routeNames = urlHelper.RequestContext.HttpContext.Request.GetRouteNames();
            return urlHelper.Action(routeNames.IndexName);
        }

        public static string Destroy(this UrlHelper urlHelper)
        {
            RouteNames routeNames = urlHelper.RequestContext.HttpContext.Request.GetRouteNames();
            return urlHelper.Action(routeNames.DestroyName);
        }
    }
}