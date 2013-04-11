using System;
namespace Elixir.Web.Mvc.ViewModels
{
    interface IViewModel
    {
        System.Collections.Generic.IDictionary<string, object> HtmlAttributes { get; }
    }
}
