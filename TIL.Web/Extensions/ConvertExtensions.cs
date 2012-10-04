using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web;

namespace TIL.Extensions
{
    public static class ConvertExtensions
    {
        public static string ToQueryString(this NameValueCollection query)
        {
            if (query == null)
                return string.Empty;

            var httpQueryString = HttpUtility.ParseQueryString("");
            httpQueryString.Add(query);
            return httpQueryString.ToString();
        }

        public static string ToQueryString(this object value)
        {
            return value.ToDictionary().ToNameValueCollection().ToQueryString();
        }
    }
}
