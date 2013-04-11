using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Resources;
using System.Web;

namespace Elixir.Web.Mvc.Html
{
    using Elixir.Web.Mvc.Extensions;
            
    public static class ResourceManagementExtensions
    {
        public static IHtmlString GetHtmlString(this ResourceManager resourceManager, string key)
        {
            try
            {
                return resourceManager.GetResourceString(key).ToMvcHtmlString();
            }
            catch(ResourceNotFoundException ex)
            {
                TagBuilder tagBuilder = new TagBuilder("span");
                tagBuilder.AddCssClass("help-inline translation-missing error");
                tagBuilder.InnerHtml = ex.Message;
                return tagBuilder.ToMvcHtmlString();
            }
        }
    }
}
