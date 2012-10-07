using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TIL.Web.Mvc.Html
{
    using TIL.Data;

    public static class InputExtensions
    {
        public static MvcHtmlString CheckAll(this HtmlHelper htmlHelper)
        {
            return htmlHelper.CheckBox("check-all", false,
                        new Dictionary<string, object>{ 
                                {"data-action", "check-all"}
                        }
                    );
        }

        public static MvcHtmlString CheckBox<TKey>(this HtmlHelper htmlHelper, IEntity<TKey> entity)
        {
            return htmlHelper.CheckBox("id", false,
                        new Dictionary<string, object>{ 
                            { "data-action", "check-id" },
                            { "value", entity.Id}
                        }
                    );
        }
    }
}
