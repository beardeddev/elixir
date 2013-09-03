using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sophist.Web.Mvc
{
    public class FlashMessagesDictionary : TempDataDictionary
    {
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

    }
}
