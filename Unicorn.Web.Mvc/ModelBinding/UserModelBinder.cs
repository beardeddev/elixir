using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Unicorn.Web.Mvc.ModelBinding
{
    using Unicorn.Security;
    using Unicorn.Data.Contracts;

    public abstract class UserModelBinder : EntityModelBinder
    {
        protected abstract new object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType);

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            IUser user = base.BindModel(controllerContext, bindingContext) as IUser;

            if (!string.IsNullOrEmpty(user.Password))
            {
                Password pass = new Password(user.Password);
                user.PasswordHash = pass.Hash;
                user.PasswordSalt = pass.Salt;
            }

            if (user.IsNew)
            {
                user.PersistenceToken = Guid.NewGuid().ToString();
            }

            return user;
        }
    }
}
