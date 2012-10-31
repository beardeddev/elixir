using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Resources;

namespace Unicorn.Web.Mvc.ViewModels
{
    using Unicorn.Web.Mvc.Extensions;

    /// <summary>
    /// Contains methods and properties that describe the currently executing web page.
    /// </summary>
    public class RequestPageInfo
    {
        private RequestContext requestContext;
        private ResourceManager resourceManager;

        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }

        public RequestPageInfo(ResourceManager resourceManager, RequestContext requestContext)
        {
            this.requestContext = requestContext;
            this.resourceManager = resourceManager;
            this.resourceManager.IgnoreCase = true;

            Area = requestContext.RouteData.DataTokens["area"] as string;
            Controller = requestContext.RouteData.Values["controller"] as string;
            Action = requestContext.RouteData.Values["action"] as string;

            var areaName = this.resourceManager.GetHtmlString(Area);
            var controllerName = this.resourceManager.GetHtmlString(Controller);
            var actionName = this.resourceManager.GetHtmlString(Action);

            Description = string.Format("{0} :: {1}", controllerName, actionName);

            if (!string.IsNullOrEmpty(Area))
            {
                Title = string.Format("{0} :: {1} :: {2} | {3}",
                    areaName,
                    controllerName,
                    actionName,
                    requestContext.HttpContext.Request.Url.Host);
            }
            else
            {
                Title = string.Format("{0} :: {1} | {2}",
                    controllerName,
                    actionName,
                    requestContext.HttpContext.Request.Url.Host);
            }
        }
    }
}
