using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections;

namespace Elixir.Web.Mvc.Components
{
    using Elixir.Common;

    /// <summary>
    /// 
    /// </summary>
    public class Flash : IEnumerable<KeyValuePair<string, object>>
    {
        private static readonly object flashKeyPrefix = new object();
        private IDictionary<string, object> flashBag;

        /// <summary>
        /// Initializes a new instance of the <see cref="Flash"/> class.
        /// </summary>
        /// <param name="flashBag">The flash bag.</param>
        public Flash(IDictionary<string, object> flashBag)
        {
            this.flashBag = flashBag;
        }

        /// <summary>
        /// Gets or sets the <see cref="System.String"/> with the specified key.
        /// </summary>
        public string this[string key]
        {
            get
            {
                string flashKey = GetKey(key);
                if (this.flashBag[flashKey] != null)
                {
                    return this.flashBag[flashKey] as string;
                }
                return string.Empty;
            }
            set
            {
                string flashKey = GetKey(key);
                this.flashBag[flashKey] = value;
            }
        }

        /// <summary>
        /// Pushes the specified category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The args.</param>
        public void Push(string category, string message, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                this[category] = string.Format(message, args);
            }
            else
            {
                this[category] = message;
            }
        }

        public void Error(string message, params object[] args)
        {
            this.Push("Error", message, args);
        }

        public void Error(string message)
        {
            this.Error(message, null);
        }

        public void Exception(Exception ex)
        {
            this.Error("{0}{2}{1}", ex.Message, ex.StackTrace, Environment.NewLine);
        }

        public void Success(string message, params object[] args)
        {
            this.Push("Success", message, args);
        }

        public void Success(string message)
        {
            this.Success(message, null);
        }

        public void Notice(string message, params object[] args)
        {
            this.Push("Notice", message, args);
        }

        public void Notice(string message)
        {
            this.Notice(message, null);
        }

        public void Warning(string message, params object[] args)
        {
            this.Push("Warning", message, args);
        }

        public void Warning(string message)
        {
            this.Warning(message, null);
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this.flashBag.ForEach(x => GetCategory(x.Key)).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private string GetKey(string key)
        {
            return string.Format("{0}.{1}", flashKeyPrefix, key);
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private string GetCategory(string key)
        {
            return key.Replace(flashKeyPrefix.ToString(), string.Empty);
        }
    }
}
