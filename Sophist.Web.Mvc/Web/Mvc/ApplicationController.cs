using System;
using System.Web;
using System.Web.Mvc;
using System.Resources;
using System.Linq;

using RestfulRouting.Format;
using RestfulRouting;

namespace Sophist.Web.Mvc
{
    using Sophist.Resources;
    
    public abstract class ApplicationController : Controller
    {
        private FlashMessagesDictionary flashMessages;
        private DynamicFlashMessagesDictionary flash;

        public virtual RouteNames RouteNames { get; private set; }

        public virtual ResourceManager ResourceManager { get; set; }
        
        public FlashMessagesDictionary FlashMessages
        {
            get
            {
                if (this.ControllerContext != null && this.ControllerContext.IsChildAction && this.ControllerContext.Controller is ApplicationController)
                {
                    return ((ApplicationController)this.ControllerContext.ParentActionViewContext.Controller).FlashMessages;
                }

                if (this.flashMessages == null)
                {
                    this.flashMessages = new FlashMessagesDictionary();
                }

                return this.flashMessages;
            }
            set
            {
                this.flashMessages = value;
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

        public ApplicationController(IResourceManagerFactory factory)
        {
            this.ResourceManager = factory.GetResourceManager();
            this.RouteNames = new RouteNames();            
        }

        protected ActionResult RespondTo(Action<FormatCollection> format)
        {
            return new FormatResult(format);
        }

        protected virtual ActionResult ObjectOr404(object entity)
        {
            return ObjectOr404(null, entity);
        }

        protected virtual ActionResult ObjectOr404(string viewName, object entity)
        {
            if (entity == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                return View(viewName, entity);
            }
        }
    }
}