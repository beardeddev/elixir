using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.Mvc;
using System.Resources;
using System.Threading;

namespace TIL.Web.Mvc.ViewModels
{
    public class MvcPage
    {
        private RequestContext requestContext;
        private Type resourceType;

        public MvcPage(Type resourceType, RequestContext requestContext)
        {
            this.requestContext = requestContext;
            this.resourceType = resourceType;

            Area = requestContext.RouteData.DataTokens["area"] as string;
            Controller = requestContext.RouteData.Values["controller"] as string;
            Action = requestContext.RouteData.Values["action"] as string;

            var areaName = this.GetResourceString(Area);
            var controllerName = this.GetResourceString(Controller);
            var actionName = this.GetResourceString(Action); ;


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

        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }

        protected virtual string GetResourceString(string key)
        {
            if (resourceType == null)
            {
                throw new NullReferenceException("Resource type required  for translation is missing.");
            }

            try
            {
                ResourceManager resourceManager = new ResourceManager(resourceType);
                resourceManager.IgnoreCase = true;
                string value = resourceManager.GetString(key, Thread.CurrentThread.CurrentCulture);

                if (string.IsNullOrEmpty(value))
                {
                    return TranslationMissing(key);
                }
                return value;
            }
            catch
            {
                return TranslationMissing(key);
            }
        }

        protected virtual string TranslationMissing(string key)
        {
            TagBuilder tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("error translation-missing");
            tagBuilder.InnerHtml = string.Format("{0} {1}.{2}", "Translation Missing", resourceType.FullName, key);
            return tagBuilder.ToString();
        }
    }
}
