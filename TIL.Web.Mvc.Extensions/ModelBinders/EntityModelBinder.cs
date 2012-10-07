using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel;

namespace TIL.Web.Mvc.ModelBinders
{
    using TIL.Data;
    using TIL.Data.Mapping;

    public abstract class EntityModelBinder : DefaultModelBinder
    {
        /// <summary>
        /// Binds the specified property by using the specified controller context and binding context and the specified property descriptor.
        /// </summary>
        /// <param name="controllerContext">The context within which the controller operates. The context information includes the controller, HTTP content, request context, and route data.</param>
        /// <param name="bindingContext">The context within which the model is bound. The context includes information such as the model object, model name, model type, property filter, and value provider.</param>
        /// <param name="propertyDescriptor">Describes a property to be bound. The descriptor provides information such as the component type, property type, and property value. It also provides methods to get or set the property value.</param>
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {
            if (bindingContext.Model is IEntity && propertyDescriptor.PropertyType == typeof(DateTime) &&
                propertyDescriptor.Attributes.OfType<TimestampAttribute>().Count() != 0)
            {
                TimestampAttribute attr = propertyDescriptor.Attributes.OfType<TimestampAttribute>().First();

                if (attr.AutoUpdateNow)
                {
                    this.SetProperty(controllerContext, bindingContext, propertyDescriptor, DateTime.Now);
                }

                if (attr.AutoAddNow && (bindingContext.Model as IEntity).IsNew)
                {
                    this.SetProperty(controllerContext, bindingContext, propertyDescriptor, DateTime.Now);
                }
            }
            else
            {
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
            }
        }
    }
}
