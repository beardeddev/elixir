using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Net;
using System.Collections;
using System.Data.SqlClient;

namespace Elixir.Common
{
    public static class ConvertExtensions
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <returns></returns>
        public static object GetValue(this object value, Type targetType)
        {            
            return Convert.ChangeType(value, targetType);
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T">The type of a value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T GetValue<T>(this object value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static T GetValueOrDefault<T>(this object value, T @default = default(T))
        {
            try
            {
                return value.GetValue<T>();
            }
            catch
            {
                return @default;
            }
        }

        public static Dictionary<string, object> ToDictionary(this object value)
        {
            if (value == null)
                return new Dictionary<string, object>();

            return value.GetType()
                .GetProperties()
                .ToDictionary(x => x.Name, x => x.GetValue(value, null));
        }

        public static NameValueCollection ToNameValueCollection(this IDictionary dictionary)
        {
            NameValueCollection collection = new NameValueCollection();
            foreach (string key in dictionary.Keys)
                collection.Add(key, collection[key].ToString());
            return collection;
        }

        public static long IpToLong(this IPAddress ipAddress)
        {
            byte[] bytes = ipAddress.GetAddressBytes();
#pragma warning disable 0675
            return (long)(((long)bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3]);
#pragma warning restore 0675
        }

        public static long IpToLong(this string ipString)
        {
            IPAddress ipAddress = IPAddress.None;
            if (string.IsNullOrEmpty(ipString))
                return ipAddress.IpToLong();

            if (IPAddress.TryParse(ipString, out ipAddress))
            {
                return ipAddress.IpToLong();
            }

            return ipAddress.IpToLong();
        }

        public static string LongToIp(long ipLong)
        {
            try
            {
                return IPAddress.NetworkToHostOrder(ipLong).ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static SqlParameter[] ToSqlParameterCollection(this object value)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();

            if (value == null)
                return parameters.ToArray();

            Dictionary<string, object> dic = value.ToDictionary();
            foreach (string paramName in dic.Keys)
            {
                parameters.Add(new SqlParameter(paramName, dic[paramName]));
            }

            return parameters.ToArray();
        }

        public static string[] ToArray(this string value, params char[] separator)
        {
            if (value == null)
                return new string[0];

            return value.Split(separator);
        }

        public static T[] ToArray<T>(this string value, params char[] separator)
            where T : struct
        {
            if (value == null)
                return new T[0];

            string[] array = value.Split(separator);

            List<T> list = new List<T>(array.Length);

            foreach (string val in array)
            {
                list.Add(val.GetValue<T>());
            }

            return list.ToArray<T>();
        }
    }
}
