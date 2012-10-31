using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace Unicorn.Web.Mvc.Component
{
    using Unicorn.Extensions;

    public class Flash : DynamicObject
    {
        private string cssClass = "message flash alert";
        private const string _KeyPrefix = "Flash:";
        private IDictionary<string, object> _FlashBag;

        private static string GetKey(string key)
        {
            return string.Format("{0}{1}", _KeyPrefix, key);
        }

        public string CssClass
        {
            get { return cssClass; }
            set { cssClass = value; }
        }

        public Flash(IDictionary<string, object> flashBag)
        {
            this._FlashBag = flashBag;
        }

        public Flash(IDictionary<string, object> flashBag, string cssClass)
            : this(flashBag)
        {
            this.cssClass = cssClass;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this[binder.Name] = value.ToString();
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];
            return true;
        }

        public string this[string key]
        {
            get
            {
                string flashKey = GetKey(key);
                if (this._FlashBag[flashKey] != null)
                {
                    return this._FlashBag[flashKey] as string;
                }
                return string.Empty;
            }
            set
            {
                string flashKey = GetKey(key);
                this._FlashBag[flashKey] = value;
            }
        }

        public KeyValuePair<string, object>[] Messages
        {
            get
            {
                return this._FlashBag
                    .Where(x => x.Key.StartsWith(_KeyPrefix))
                    .Select(x => new KeyValuePair<string, object>(x.Key.TrimStart(_KeyPrefix.ToCharArray()).ToLower(), this._FlashBag[x.Key]))
                    .ToArray();

            }
        }

        public bool ContainsKey(string key)
        {
            string flashKey = GetKey(key);
            return this._FlashBag.ContainsKey(flashKey);
        }

        public void Push(object message)
        {
            this.Push(message.ToDictionary().First());
        }

        public void Push(KeyValuePair<string, object> message)
        {
            this.Push(message.Key, message.Value.ToString());
        }

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
    }
}
