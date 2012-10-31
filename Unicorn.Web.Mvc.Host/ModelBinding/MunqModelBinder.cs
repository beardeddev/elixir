using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Munq;
using Munq.MVC3;

namespace Unicorn.Web.Mvc.Host.ModelBinding
{
    using Unicorn.Web.Mvc.ModelBinding;
        
    /// <summary>
    /// Maps a browser request to a value object. 
    /// This class provides a selection of implementation of a model binder based on IOC configuration. 
    /// </summary>
    public class MunqModelBinder : EntityModelBinder
    {
        private IocContainer ioc = MunqDependencyResolver.Container;

        /// <summary>
        /// Binds the model to a value by using the specified controller context and binding context.
        /// If model binder for the model can be resolved by IOC it will be used for binding the model;
        /// otherwise will be used default model binder.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>The bound value.</returns>
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (ioc.CanResolve<IModelBinder>(bindingContext.ModelType.Name))
            {
                IModelBinder binder = ioc.Resolve<IModelBinder>(bindingContext.ModelType.Name);
                return binder.BindModel(controllerContext, bindingContext);
            }

            if (ioc.CanResolve<IModelBinder>())
            {
                IModelBinder binder = ioc.Resolve<IModelBinder>();
                return binder.BindModel(controllerContext, bindingContext);
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}
