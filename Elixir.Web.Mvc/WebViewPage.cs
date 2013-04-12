using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elixir.Data.Contracts;
using System.Web.Mvc;
using System.Resources;

namespace Elixir.Web.Mvc
{
    using Elixir.Web.Mvc.Html;
    using Elixir.Web.Mvc.Factories;
    using Elixir.Web.Mvc.Components;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        /// <summary>
        /// Gets the page meta.
        /// </summary>
        /// <value>
        /// The page meta.
        /// </value>
        protected PageMeta Meta { get; private set; }

        /// <summary>
        /// Gets the flash.
        /// </summary>
        protected Flash Flash { get; private set; }

        private IResourceManagerFactory resourceManagerFactory;
        /// <summary>
        /// Gets the resource manager factory.
        /// </summary>
        /// <value>
        /// The resource manager factory.
        /// </value>        
        public IResourceManagerFactory ResourceManagerFactory
        {
            get 
            { 
                //TODO: Remove when Autofac will fix issue with property injection into layout pages.
                if(resourceManagerFactory == null)
                    resourceManagerFactory = DependencyResolver.Current.GetService<IResourceManagerFactory>();

                return resourceManagerFactory; 
            }
            set 
            { 
                resourceManagerFactory = value; 
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebViewPage{TModel}" /> class.
        /// </summary>
        public WebViewPage()
        {
            this.Flash = new Flash(this.TempData);
        }

        /// <summary>
        /// Initializes the helpers.
        /// </summary>
        public override void InitHelpers()
        {
            base.InitHelpers();

            if(this.ViewContext.Controller is ApplicationController)
            {
                this.Meta = new PageMeta(this.ResourceManagerFactory.GetResourceManager(), Request.RequestContext, ((ApplicationController)this.ViewContext.Controller).RouteNames);
            }
            else
            {
                this.Meta = new PageMeta(this.ResourceManagerFactory.GetResourceManager(), Request.RequestContext, new RestfulRouting.RouteNames());
            }
        }

        /// <summary>
        /// Gets the translation of the resource with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Translated resource.</returns>
        public MvcHtmlString _(string name)
        {
            return (MvcHtmlString)this.ResourceManagerFactory.GetResourceManager().GetHtmlString(name);
        }

        /// <summary>
        /// Gets the translation of the resource with the specified name according to condition.
        /// </summary>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="trueKey">The true key.</param>
        /// <param name="falseKey">The false key.</param>
        /// <returns>Translated resource.</returns>
        public MvcHtmlString _(bool condition, string trueKey, string falseKey)
        {
            return condition ? _(trueKey) : _(falseKey);
        }

        /// <summary>
        /// Returns edit path for given model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public string EditModelUrl(IEntity entity)
        {
            return Url.Action(Meta.RouteNames.EditName, new { @id = entity.Id });
        }

        /// <summary>
        /// Return details path for given model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public string ShowModelUrl(IEntity entity)
        {
            return Url.Action(Meta.RouteNames.ShowName, new { @id = entity.Id });
        }

        /// <summary>
        /// Return destroy path for given model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public string DestroyModelUrl(IEntity entity)
        {
            return Url.Action(Meta.RouteNames.DeleteName, new { @id = entity.Id });
        }
    }
}
