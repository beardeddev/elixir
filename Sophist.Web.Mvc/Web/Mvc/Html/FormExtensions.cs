using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using RestfulRouting;

namespace Sophist.Web.Mvc.Html
{
    using Sophist.Data;

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
        public static MvcForm BeginModelForm<TModel>(this HtmlHelper<TModel> htmlHelper, IDictionary<string, object> htmlAttributes)
            where TModel : IEntity
        {
            RouteNames routeNames = new RouteNames();
            if (htmlHelper.ViewContext.Controller is ApplicationController)
            {
                routeNames = ((ApplicationController)htmlHelper.ViewContext.Controller).RouteNames;
            }

            UrlHelper url = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            string actionName = htmlHelper.ViewData.Model.IsNew ? routeNames.CreateName : routeNames.UpdateName;

            string formName = htmlHelper.ViewData.Model.GetType().Name.ToLower();
            string formId = string.Format("{0}_{1}", actionName, formName);
            string formAction = url.Action(actionName, htmlHelper.ViewContext.RequestContext.RouteData.Values);

            TagBuilder tagBuilder = new TagBuilder("form");
            tagBuilder.MergeAttributes<string, object>(htmlAttributes);
            tagBuilder.MergeAttribute("id", formId);
            tagBuilder.MergeAttribute("name", formName);
            tagBuilder.MergeAttribute("action", formAction);
            tagBuilder.MergeAttribute("method", HtmlHelper.GetFormMethodString(FormMethod.Post));
            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            if (!htmlHelper.ViewData.Model.IsNew)
            {
                htmlHelper.ViewContext.Writer.Write(htmlHelper.HttpMethodOverride(HttpVerbs.Put).ToHtmlString());
            }

            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

            return new MvcForm(htmlHelper.ViewContext);
        }

        /// <summary>
        /// Writes an opening <form> tag to the response. When the user submits the form, the request will be processed by an action method.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="model">The model.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>An opening &lt;form&gt; tag. </returns>
        public static MvcForm BeginModelForm<TModel>(this HtmlHelper<TModel> htmlHelper, object htmlAttributes)
            where TModel : IEntity
        {
            return BeginModelForm(htmlHelper, (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Writes an opening <form> tag to the response. When the user submits the form, the request will be processed by an action method.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="model">The model.</param>
        /// <returns>An opening &lt;form&gt; tag. </returns>
        public static MvcForm BeginModelForm<TModel>(this HtmlHelper<TModel> htmlHelper, IEntity model)
            where TModel : IEntity
        {
            return BeginModelForm(htmlHelper, new Dictionary<string, object>());
        }
    }
}
