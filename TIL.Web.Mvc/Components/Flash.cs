using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Dynamic;

namespace TIL.Web.Mvc.Components
{
    public class Flash : DynamicObject
    {
        private string cssClass = "message flash";
        private string exceptionFormat = "<b>{0}<b><br/><p>{1}</p>";
        private const string _KeyPrefix = "Flash";
        private IDictionary<string, object> _FlashBag;

        private static string GetKey(string key)
        {
            return string.Format("{0}:{1}", _KeyPrefix, key);
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

        public string[] Messages
        {
            get
            {
                ArrayList messages = new ArrayList();
                string flashKey = string.Empty;
                foreach (var key in this._FlashBag.Keys)
                {
                    flashKey = key.ToString();
                    if (flashKey.StartsWith(_KeyPrefix))
                    {
                        messages.Add(this._FlashBag[flashKey]);
                    }
                }
                return (string[])messages.ToArray();
            }
        }

        public KeyValuePair<string, object>[] MessagesWithCategories
        {
            get
            {
                List<KeyValuePair<string, object>> messages = new List<KeyValuePair<string, object>>();
                foreach (var key in this._FlashBag.Keys)
                {
                    if (key.StartsWith(_KeyPrefix))
                    {
                        messages.Add(
                            new KeyValuePair<string, object>(key.Replace(_KeyPrefix + ":", string.Empty).ToLower()
                                , this._FlashBag[key])
                            );
                    }
                }
                return messages.ToArray();
            }
        }

        public bool ContainsKey(string key)
        {
            string flashKey = GetKey(key);
            return this._FlashBag.ContainsKey(flashKey);
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

        public void Error(Exception ex)
        {
            this.Error(this.exceptionFormat, ex.Message, ex.StackTrace);
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
