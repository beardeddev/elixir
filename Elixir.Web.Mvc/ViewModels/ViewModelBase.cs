using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Elixir.Web.Mvc.ViewModels
{
    public abstract class ViewModelBase : Elixir.Web.Mvc.ViewModels.IViewModel
    {
        public IDictionary<string, object> HtmlAttributes { get; private set; }

        private ViewModelBase()
        {
        }

        public ViewModelBase(ViewContext viewContext)
        {
        }
    }
}
