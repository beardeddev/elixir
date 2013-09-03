using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Sophist.Resources;

namespace Sophist.Web.Mvc
{    
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        private FlashMessagesDictionary flashMessages;
        private DynamicFlashMessagesDictionary flash;

        public ResourceManager ResourceManager { get; private set; }        
        
        public FlashMessagesDictionary FlashMessages
        {
            get
            {

                if (this.ViewContext.Controller is ApplicationController)
                {
                    this.flashMessages = ((ApplicationController)this.ViewContext.Controller).FlashMessages;
                }

                if (this.flashMessages == null)
                {
                    this.flashMessages = new FlashMessagesDictionary();
                }

                return this.flashMessages;
            }
        }

        public dynamic Flash
        {
            get
            {
                if (this.flash == null)
                    this.flash = new DynamicFlashMessagesDictionary((Func<FlashMessagesDictionary>)(() => this.FlashMessages));
                return (object)this.flash;
            }
        }

        public WebViewPage(IResourceManagerFactory resourceManagerFactory)
        {
            this.ResourceManager = resourceManagerFactory.GetResourceManager();
        }

        public virtual IHtmlString h(string value)
        {
            return this.Html.Raw(value);
        }
    }
}
