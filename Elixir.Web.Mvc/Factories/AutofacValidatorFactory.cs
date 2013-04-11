using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentValidation;

using Autofac.Integration.Mvc;

namespace Elixir.Web.Mvc.Factories
{
    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            object service = AutofacDependencyResolver.Current.GetService(validatorType);

            if (service == null && validatorType.IsGenericType)
            {
                Type typeDefinition = validatorType.GetGenericTypeDefinition();
                Type[] interfaces = validatorType.GetGenericArguments()[0].GetInterfaces();
                foreach(Type entry in interfaces)
                {
                    Type genericType = typeDefinition.MakeGenericType(entry);
                    service = AutofacDependencyResolver.Current.GetService(genericType);

                    if (service != null)
                    {
                        break;
                    }
                }
            }

            if (service != null)
            {
                return service as IValidator;
            }

            return null;
        }
    }
}
