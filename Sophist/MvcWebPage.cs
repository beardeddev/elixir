using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using RestfulRouting;

namespace Sophist.Web.Mvc
{
    using Sophist.Web.Mvc.Resources;

    public class MvcWebPage
    {
        private RequestContext requestContext;
        private ResourceManager resourceManager;
        
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }

        public RouteNames RouteNames { get; private set; }

        public bool IsCreateAction 
        {
            get
            {
                return string.Compare(this.Action, this.RouteNames.CreateName, true) == 0;
            }
        }

        public bool IsNewAction 
        {
            get
            {
                return string.Compare(this.Action, this.RouteNames.NewName, true) == 0;
            }
        }

        public MvcWebPage(ResourceManager resourceManager, RequestContext requestContext, RouteNames routeNames)
            : this(resourceManager, requestContext)
        {
            this.RouteNames = routeNames;
        }

        public MvcWebPage(ResourceManager resourceManager, RequestContext requestContext)
        {
            this.RouteNames = new RouteNames();
            this.requestContext = requestContext;
            this.resourceManager = resourceManager;
            this.resourceManager.IgnoreCase = true;

            Area = requestContext.RouteData.DataTokens["area"] as string;
            Controller = requestContext.RouteData.GetRequiredString("controller");
            Action = requestContext.RouteData.GetRequiredString("action") as string;
                        
            IHtmlString controllerName = this.resourceManager.GetHtmlString(Controller);
            IHtmlString actionName = this.resourceManager.GetHtmlString(Action);

            Description = string.Format("{0} :: {1}", controllerName, actionName);

            if (!string.IsNullOrEmpty(Area))
            {
                IHtmlString areaName = this.resourceManager.GetHtmlString(Area);

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
