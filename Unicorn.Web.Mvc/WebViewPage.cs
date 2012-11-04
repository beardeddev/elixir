using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Web.Mvc;

namespace Unicorn.Web.Mvc
{
    using Unicorn.Web.Mvc.Extensions;
    using Unicorn.Web.Mvc.ViewModels;
    using Unicorn.Web.Mvc.Component;
    using Unicorn.Data.Contracts;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        /// <summary>
        /// Gets the controller.
        /// </summary>
        protected ApplicationController Controller { get; private set; }

        /// <summary>
        /// Gets the resource manager.
        /// </summary>
        protected ResourceManager ResourceManager { get; private set; }

        /// <summary>
        /// Information about the currently executing page.
        /// </summary>
        protected RequestPageInfo PageInfo { get; private set; }

        /// <summary>
        /// Gets or sets the flash.
        /// </summary>
        /// <value>
        /// The flash.
        /// </value>
        protected Flash Flash { get; set; }

        /// <summary>
        /// Initializes the helpers.
        /// </summary>
        public override void InitHelpers()
        {
            base.InitHelpers();
            this.Controller = (ApplicationController)this.ViewContext.Controller;
            this.ResourceManager = Controller.ResourceManager;
            this.PageInfo = this.ViewBag.PageInfo as RequestPageInfo;
            this.Flash = new Flash(this.TempData);
        }       

        /// <summary>
        /// Gets the translation of the resource with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Translated resource.</returns>
        public MvcHtmlString _(string name)
        {
            return (MvcHtmlString)this.ResourceManager.GetHtmlString(name);
        }

        /// <summary>
        /// Returns edit path for given model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public string EditModelPath(IEntity entity)            
        {
            return Url.Action(Controller.RouteNames.EditName, new { @id = entity.Id });
        }

        /// <summary>
        /// Return details path for given model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public string ShowModelPath(IEntity entity)
        {
            return Url.Action(Controller.RouteNames.ShowName, new { @id = entity.Id });
        }

        /// <summary>
        /// Return destroy path for given model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public string DeleteModelPath(IEntity entity)
        {
            return Url.Action(Controller.RouteNames.DeleteName, new { @id = entity.Id });
        }
    }
}
