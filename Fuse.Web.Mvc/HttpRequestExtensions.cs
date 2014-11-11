using Microsoft.Owin;
using RestfulRouting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fuse.Web.Mvc
{
    public static class HttpRequestExtensions
    {
        public static RouteNames GetRouteNames(this HttpRequestBase request)
        {
            IOwinContext context = request.GetOwinContext();
            return context.Environment.ContainsKey("RouteNames") ? context.Get<RouteNames>("RouteNames") : new RouteNames();
        }
    }
}
