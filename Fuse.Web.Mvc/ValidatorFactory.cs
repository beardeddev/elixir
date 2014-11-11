using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fuse.Web.Mvc
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            object service = DependencyResolver.Current.GetService(validatorType);
            if (service != null)
            {
                return service as IValidator;
            }

            return null;
        }
    }
}
