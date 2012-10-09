using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using HtmlTags;

namespace TIL.HtmlTags
{
    using TIL.Data;
    using TIL.Resources;
    
    public static class LinkExtensions
    {
        private static UrlHelper Url(this HtmlHelper htmlHelper)
        {
            UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            return urlHelper;
        }

        public static HtmlTag ActionLinkToEdit<TKey>(this HtmlHelper htmlHelper, IEntity<TKey> model)
        {
            string url = htmlHelper.Url().Edit<TKey>(model);

            return new HtmlTag("a")
                .Attr("href", url)
                .Attr("title", Labels.Edit)
                .AppendHtml("<i class=\"icon-edit\"></i>&nbsp;")
                .AppendHtml(Labels.Edit)
                .Data("action", "edit");
        }

        public static HtmlTag ActionLinkToDetails<TKey>(this HtmlHelper htmlHelper, IEntity<TKey> model)
        {
            string url = htmlHelper.Url().Show<TKey>(model);

            return new HtmlTag("a")
                .Attr("href", url)
                .Attr("title", Labels.View)
                .AppendHtml("<i class=\"icon-search\"></i>&nbsp;")
                .AppendHtml(Labels.View)
                .Data("action", "view");
        }

        public static HtmlTag ActionLinkToDestroy<TKey>(this HtmlHelper htmlHelper, IEntity<TKey> model)
        {
            string url = htmlHelper.Url().Destroy<TKey>(model);

            return new HtmlTag("a")
                .Attr("href", url)
                .Attr("title", Labels.Destroy)
                .AppendHtml("<i class=\"icon-trash\"></i>&nbsp;")
                .AppendHtml(Labels.Destroy)
                .Data("action", "destroy");
        }

        public static HtmlTag ActionLinkToSelectAll(this HtmlHelper htmlHelper)
        {
            return new HtmlTag("a")
                .Attr("title", Labels.SelectAll)
                .AppendHtml("<i class=\"icon-ok-sign\"></i>&nbsp;")
                .AppendHtml(Labels.SelectAll)
                .Data("action", "select-all");
        }

        public static HtmlTag ActionLinkToDestroySelected(this HtmlHelper htmlHelper)
        {
            string url = htmlHelper.Url().Destroy();

            return new HtmlTag("a")
                .Attr("href", url)
                .Attr("title", Labels.DestroySelected)
                .AppendHtml("<i class=\"icon-remove-sign\"></i>&nbsp;")
                .AppendHtml(Labels.DestroySelected)
                .Data("action", "destroy-selected");
        }

        public static HtmlTag ActionLinkToCreateRecord(this HtmlHelper htmlHelper)
        {
            string url = htmlHelper.Url().New();

            return new HtmlTag("a")
                .Attr("href", url)
                .Attr("title", Labels.New)
                .AppendHtml("<i class=\"icon-plus-sign\"></i>&nbsp;")
                .AppendHtml(Labels.New)
                .Data("action", "create");
        }

        public static HtmlTag GridActionLinksDropdown<TKey>(this HtmlHelper htmlHelper, IEntity<TKey> model)
        {
            List<HtmlTag> linksList = new List<HtmlTag>
            {
                new HtmlTag("li").Append(htmlHelper.ActionLinkToEdit(model)),
                new HtmlTag("li").Append(htmlHelper.ActionLinkToDetails(model)),
                new HtmlTag("li").Append(htmlHelper.ActionLinkToDestroy(model)),
            };

            return htmlHelper.ButtonGroup()
                .Append(
                    htmlHelper.Button()
                        .Text(Labels.Actions)
                    )
                .Append(htmlHelper.ButtonDropdownToggle()
                    )
                .Append(htmlHelper.DropdownMenu()
                        .Append(linksList)
                    )
                .AddClass("pull-right");
        }
    }
}
