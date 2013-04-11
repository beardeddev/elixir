using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Elixir.Web.Mvc.Html
{
    using Elixir.Data.Contracts;

    public static class InputExtensions
    {
        public static MvcHtmlString CheckBoxForList(this HtmlHelper htmlHelper)
        {
            return htmlHelper.CheckBox("check-all", false,
                        new Dictionary<string, object>{ 
                                {"data-action", "check-all"}
                        }
                    );
        }

        public static MvcHtmlString CheckBoxForModel(this HtmlHelper htmlHelper, IEntity entity)
        {
            return htmlHelper.CheckBox("ids", false,
                        new Dictionary<string, object>{ 
                            { "data-action", "check-id" },
                            { "value", entity.Id}
                        }
                    );
        }
    }
}
