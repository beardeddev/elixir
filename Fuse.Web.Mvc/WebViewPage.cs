using MvcFlash.Core;
using MvcFlash.Core.Extensions;
using RestfulRouting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fuse.Resources;
using Fuse.Web.Mvc.Html;

namespace Fuse.Web.Mvc
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        protected virtual IFlashMessenger Flash { get; private set; }

        protected RouteNames RouteNames { get; private set; }

        public bool IsListAction
        {
            get
            {
                return this.Request.RequestContext.RouteData.GetRequiredString("action").Equals(RouteNames.IndexName, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public string RouteName
        {
            get
            {
                NamedRoute route = this.Request.RequestContext.RouteData.Route as NamedRoute;
                if (route != null)
                {
                    return route.Name;
                }

                return string.Empty;
            }
        }

        protected override void InitializePage()
        {            
            base.InitializePage();
            this.RouteNames = Request.GetRouteNames();
            this.Flash = MvcFlash.Core.Flash.Instance;

            string controller = Request.RequestContext.RouteData.GetRequiredString("controller");
            string action = Request.RequestContext.RouteData.GetRequiredString("action");

            IHtmlString controllerName = new HtmlString(ResourceExtensions.ResourceString(Context, "Common", controller));
            IHtmlString actionName = new HtmlString(ResourceExtensions.ResourceString(Context, "Common", action));

            Page.Description = string.Format("{0} :: {1}", controllerName, actionName);

            object areaDataToken = null;
            if (Request.RequestContext.RouteData.DataTokens.TryGetValue("area", out areaDataToken))
            {
                IHtmlString areaName = new HtmlString(ResourceExtensions.ResourceString(Context, "Common", areaDataToken.ToString()));

                Page.Title = string.Format("{0} :: {1} :: {2} | {3}",
                    areaName,
                    controllerName,
                    actionName,
                    Context.Request.Url.Host);
            }
            else
            {
                Page.Title = string.Format("{0} :: {1} | {2}",
                    controllerName,
                    actionName,
                    Context.Request.Url.Host);
            }
        }

        public virtual IHtmlString Raw(string value)
        {
            return this.Html.Raw(value);
        }
    }
}