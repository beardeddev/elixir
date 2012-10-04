using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TIL.Extensions
{
    /// <summary>
    /// Represents a class that extends string manipulation methods.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Generate random string.
        /// </summary>
        /// <returns>The random generated string.</returns>
        public static string GetRandomString()
        {
            return GetRandomString(int.MaxValue);
        }

        /// <summary>
        /// Generate random string of given length.
        /// </summary>
        /// <param name="length">The length of string to be generated</param>
        /// <returns>The random generated string with length of length parameter.</returns>
        public static string GetRandomString(int length)
        {
            string str = Path.GetRandomFileName().Replace(".", "");
            if (str.Length > length)
                return str.Substring(0, length);

            return str;
        }

        /// <summary>
        /// Syntactic sugar for string.IsNullOrEmpty
        /// </summary>
        /// <param name="value">Value for test</param>
        /// <returns>True if string is null of has '' value</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
