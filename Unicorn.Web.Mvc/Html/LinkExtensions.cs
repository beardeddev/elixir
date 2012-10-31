using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Unicorn.Web.Mvc.Html
{
    using Unicorn.Data.Contracts;

    public static class LinkExtensions
    {
        internal static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string actionName, string innerHtml, IDictionary<string, object> htmlAttributes)            
        {
            string linkHref = htmlHelper.Url().Action(actionName);

            TagBuilder actionLink = new TagBuilder("a");
            actionLink.MergeAttributes(htmlAttributes);
            actionLink.InnerHtml = innerHtml;
            return actionLink.ToMvcHtmlString();
        }

        #region edit links
        public static MvcHtmlString ActionLinkToEdit<TModel>(this HtmlHelper<TModel> htmlHelper, string innerHtml, IDictionary<string, object> htmlAttributes)
            where TModel : IEntity
        {
            string actionName = htmlHelper.Controller().RouteNames.EditName;
            htmlAttributes.Add("data-action", "edit");
            return LinkExtensions.ActionLink(htmlHelper, actionName, innerHtml, htmlAttributes);
        }

        public static MvcHtmlString ActionLinkToEdit<TModel>(this HtmlHelper<TModel> htmlHelper, string innerHtml)
            where TModel : IEntity
        {
            return LinkExtensions.ActionLinkToEdit(htmlHelper, innerHtml, new Dictionary<string, object>());
        }

        public static MvcHtmlString ActionLinkToSaveModel<TModel>(this HtmlHelper<TModel> htmlHelper, string innerHtml, object htmlAttributes)
            where TModel : IEntity
        {
            return LinkExtensions.ActionLinkToEdit(htmlHelper, innerHtml, (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        } 
        #endregion

        #region show links
        public static MvcHtmlString ActionLinkToShow<TModel>(this HtmlHelper<TModel> htmlHelper, string innerHtml, IDictionary<string, object> htmlAttributes)
            where TModel : IEntity
        {
            string actionName = htmlHelper.Controller().RouteNames.ShowName;
            htmlAttributes.Add("data-action", "show");
            return LinkExtensions.ActionLink(htmlHelper, actionName, innerHtml, htmlAttributes);
        }

        public static MvcHtmlString ActionLinkToShow<TModel>(this HtmlHelper<TModel> htmlHelper, string innerHtml)
            where TModel : IEntity
        {
            return LinkExtensions.ActionLinkToShow(htmlHelper, innerHtml, new Dictionary<string, object>());
        }

        public static MvcHtmlString ActionLinkToShow<TModel>(this HtmlHelper<TModel> htmlHelper, string innerHtml, object htmlAttributes)
            where TModel : IEntity
        {
            return LinkExtensions.ActionLinkToShow(htmlHelper, innerHtml, (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        } 
        #endregion

        #region delete links
        public static MvcHtmlString ActionLinkToDelete<TModel>(this HtmlHelper<TModel> htmlHelper, string innerHtml, IDictionary<string, object> htmlAttributes)
            where TModel : IEntity
        {
            string actionName = htmlHelper.Controller().RouteNames.DeleteName;
            htmlAttributes.Add("data-action", "delete");
            return LinkExtensions.ActionLink(htmlHelper, actionName, innerHtml, htmlAttributes);
        }

        public static MvcHtmlString ActionLinkToDelete<TModel>(this HtmlHelper<TModel> htmlHelper, string innerHtml)
            where TModel : IEntity
        {
            return LinkExtensions.ActionLinkToDelete(htmlHelper, innerHtml, new Dictionary<string, object>());
        }

        public static MvcHtmlString ActionLinkToDelete<TModel>(this HtmlHelper<TModel> htmlHelper, string innerHtml, object htmlAttributes)
            where TModel : IEntity
        {
            return LinkExtensions.ActionLinkToDelete(htmlHelper, innerHtml, (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        } 
        #endregion

        #region create links
        public static MvcHtmlString ActionLinkToCreate(this HtmlHelper htmlHelper, string innerHtml, IDictionary<string, object> htmlAttributes)
        {
            string actionName = htmlHelper.Controller().RouteNames.NewName;
            htmlAttributes.Add("data-action", "create");
            return LinkExtensions.ActionLink(htmlHelper, actionName, innerHtml, htmlAttributes);
        }

        public static MvcHtmlString ActionLinkToCreate(this HtmlHelper htmlHelper, string innerHtml)
        {
            return LinkExtensions.ActionLinkToCreate(htmlHelper, innerHtml, new Dictionary<string, object>());
        }

        public static MvcHtmlString ActionLinkToCreate(this HtmlHelper htmlHelper, string innerHtml, object htmlAttributes)
        {
            return LinkExtensions.ActionLinkToCreate(htmlHelper, innerHtml, (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        } 
        #endregion

        #region list links
        public static MvcHtmlString ActionLinkToList(this HtmlHelper htmlHelper, string innerHtml, IDictionary<string, object> htmlAttributes)
        {
            string actionName = htmlHelper.Controller().RouteNames.IndexName;
            htmlAttributes.Add("data-action", "back");
            return LinkExtensions.ActionLink(htmlHelper, actionName, innerHtml, htmlAttributes);
        }

        public static MvcHtmlString ActionLinkToList(this HtmlHelper htmlHelper, string innerHtml)
        {
            return LinkExtensions.ActionLinkToList(htmlHelper, innerHtml, new Dictionary<string, object>());
        }

        public static MvcHtmlString ActionLinkToList(this HtmlHelper htmlHelper, string innerHtml, object htmlAttributes)
        {
            return LinkExtensions.ActionLinkToList(htmlHelper, innerHtml, (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        } 
        #endregion        
    }
}
