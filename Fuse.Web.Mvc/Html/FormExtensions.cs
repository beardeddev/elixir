using Fuse.Data;
using RestfulRouting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Fuse.Web.Mvc.Html
{
    /// <summary>
    /// Provides methods for building form for resources.
    /// </summary>
    public static class FormExtensions
    {
        /// <summary>
        /// Writes an opening <form> tag to the response. When the user submits the form, the request will be processed by an actionName method.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="model">The model to built form for.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening &lt;form&gt; tag. </returns>
        public static MvcForm BeginResourceForm<TModel>(this HtmlHelper<TModel> htmlHelper, IDictionary<string, object> htmlAttributes)
            where TModel : IEntity
        {
            RouteNames routeNames = htmlHelper.ViewContext.HttpContext.Request.GetRouteNames();
            UrlHelper url = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            string actionName = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            bool isNewAction = actionName.Equals(routeNames.NewName, StringComparison.InvariantCultureIgnoreCase);
            string targetActionName = isNewAction ? routeNames.CreateName : routeNames.UpdateName;
            string formName = htmlHelper.ViewData.Model.GetType().Name.ToLower();
            string formId = string.Format("{0}_{1}", targetActionName, formName);
            string formAction = url.Action(targetActionName, htmlHelper.ViewContext.RequestContext.RouteData.Values);


            TagBuilder tagBuilder = new TagBuilder("form");
            tagBuilder.MergeAttributes<string, object>(htmlAttributes);
            tagBuilder.MergeAttribute("id", formId);
            tagBuilder.MergeAttribute("name", formName);
            tagBuilder.MergeAttribute("action", formAction);
            tagBuilder.MergeAttribute("method", HtmlHelper.GetFormMethodString(FormMethod.Post));
            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            if (!isNewAction)
            {
                htmlHelper.ViewContext.Writer.Write(htmlHelper.HttpMethodOverride(HttpVerbs.Put).ToHtmlString());
            }

            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            return new MvcForm(htmlHelper.ViewContext);
        }

        /// <summary>
        /// Writes an opening <form> tag to the response. When the user submits the form, the request will be processed by an actionName method.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="model">The model.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>An opening &lt;form&gt; tag. </returns>
        public static MvcForm BeginResourceForm<TModel>(this HtmlHelper<TModel> htmlHelper, object htmlAttributes)
            where TModel : IEntity
        {
            return BeginResourceForm(htmlHelper, (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Writes an opening <form> tag to the response. When the user submits the form, the request will be processed by an actionName method.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="model">The model.</param>
        /// <returns>An opening &lt;form&gt; tag. </returns>
        public static MvcForm BeginResourceForm<TModel>(this HtmlHelper<TModel> htmlHelper, IEntity model)
            where TModel : IEntity
        {
            return BeginResourceForm(htmlHelper, new Dictionary<string, object>());
        }
    }
}