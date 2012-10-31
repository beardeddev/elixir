using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Unicorn.Web.Mvc.ModelBinding
{
    using Unicorn.Data.Common;

    /// <summary>
    /// Provides methods to bind entity filters.
    /// </summary>
    public class FilterModelBinder : DefaultModelBinder
    {
        /// <summary>
        /// Creates the specified model type by using the specified controller context and binding context.
        /// </summary>
        /// <param name="controllerContext">The context within which the controller operates. The context information includes the controller, HTTP content, request context, and route data.</param>
        /// <param name="bindingContext">The context within which the model is bound. The context includes information such as the model object, model name, model type, property filter, and value provider.</param>
        /// <param name="modelType">The type of the model object to return.</param>
        /// <returns>
        /// A data object of the specified type.
        /// </returns>
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (modelType.IsInterface && modelType.IsGenericType)
            {
                Type[] genericArguments = modelType.GetGenericArguments();
                Type generic = Type.GetType(typeof(Filter<,>).AssemblyQualifiedName).MakeGenericType(genericArguments);
                return Activator.CreateInstance(generic);
            }
            else
            {
                return base.CreateModel(controllerContext, bindingContext, modelType);
            }
        }
    }
}
