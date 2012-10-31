using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Munq.MVC3;

using FluentValidation;

namespace Unicorn.Web.Mvc.Host.Factories
{
    public class MunqValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            if (MunqDependencyResolver.Container.CanResolve(validatorType))
            {
                return MunqDependencyResolver.Container.Resolve(validatorType) as IValidator;
            }

            return null;
        }
    }
}
