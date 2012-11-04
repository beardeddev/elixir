using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc.Html;
using System.Web.Mvc;
using System.Web.Routing;

namespace Unicorn.Web.Mvc.Html
{
    using Unicorn.Data.Contracts;

    /// <summary>
    /// Provides methods for building form for resources.
    /// </summary>
    public static class FormExtensions
    {
        /// <summary>
        /// Writes an opening <form> tag to the response. When the user submits the form, the request will be processed by an action method.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="model">The model to built form for.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening &lt;form&gt; tag. </returns>
        public static MvcForm BeginFormForModel(this HtmlHelper htmlHelper, IEntity model, IDictionary<string, object> htmlAttributes)
        {
            UrlHelper url = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            IApplicationController controller = (IApplicationController)htmlHelper.ViewContext.Controller;
            string actionName = model.IsNew ? controller.RouteNames.CreateName : controller.RouteNames.UpdateName;
            
            string formName = model.GetType().Name.ToLower();
            string formId = string.Format("{0}_{1}", actionName, formName);
            string formAction = url.Action(actionName, htmlHelper.ViewContext.RequestContext.RouteData.Values);

            TagBuilder tagBuilder = new TagBuilder("form");
            tagBuilder.MergeAttributes<string, object>(htmlAttributes);
            tagBuilder.MergeAttribute("id", formId);
            tagBuilder.MergeAttribute("name", formName);
            tagBuilder.MergeAttribute("action", formAction);
            tagBuilder.MergeAttribute("method", HtmlHelper.GetFormMethodString(FormMethod.Post));
            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            if (!model.IsNew)
            {
                htmlHelper.ViewContext.Writer.Write(htmlHelper.HttpMethodOverride(HttpVerbs.Put).ToHtmlString());
            }

            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            return new MvcForm(htmlHelper.ViewContext);
        }

        public static MvcForm BeginFormForModel(this HtmlHelper htmlHelper, IEntity model, object htmlAttributes)
        {
            return BeginFormForModel(htmlHelper, model, (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcForm BeginFormForModel(this HtmlHelper htmlHelper, IEntity model)
        {
            return BeginFormForModel(htmlHelper, model, new Dictionary<string, object>());
        }
    }
}
