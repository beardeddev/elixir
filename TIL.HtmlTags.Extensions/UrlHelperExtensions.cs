using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TIL.HtmlTags
{
    using TIL.Data;

    internal static class UrlHelperExtensions
    {
        public static string New(this UrlHelper url)
        {
            return url.Action("New");
        }

        public static string Create<TKey>(this UrlHelper url, IEntity<TKey> model)
        {
            return url.Action("Create", new { @id = model.Id });
        }

        public static string Destroy(this UrlHelper url)
        {
            return url.Action("Destroy");
        }

        public static string Index(this UrlHelper url)
        {
            return url.Action("Index");
        }

        public static string Show<TKey>(this UrlHelper url, IEntity<TKey> model)
        {
            return url.Action("Show", new { @id = model.Id });
        }

        public static string Edit<TKey>(this UrlHelper url, IEntity<TKey> model)
        {
            return url.Action("Edit", new { @id = model.Id });
        }

        public static string Update<TKey>(this UrlHelper url, IEntity<TKey> model)
        {
            return url.Action("Update", new { @id = model.Id });
        }

        public static string Destroy<TKey>(this UrlHelper url, IEntity<TKey> model)
        {
            return url.Action("Destroy", new { @id = model.Id });
        }
    }
}
