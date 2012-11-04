using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Unicorn.Web.Mvc.Host
{
    using Unicorn.Data.Contracts;
    using Unicorn.Resources;
    using Unicorn.Web.Mvc.Host.ModelBinding;
    using Unicorn.Web.Mvc.ViewModels;
    
    public class ApplicationController<T, TKey> : Unicorn.Web.Mvc.ApplicationController<T, TKey>
       where T : class, IEntity<TKey>, new()
    {
        public ApplicationController(IResourceManagerFactory resourceFactory, IRepository<T, TKey> repository)
            : base(resourceFactory, repository)
        {
            this.SetRouteNames(r =>
            {
                r.CreateName = "create";
                r.DeleteName = "delete";
                r.DestroyName = "destroy";
                r.EditName = "edit";
                r.NewName = "new";
            });
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.PageInfo = new RequestPageInfo(this.ResourceManager, filterContext.RequestContext, this.RouteNames);
        }

        public override ActionResult Index([ModelBinder(typeof(MunqModelBinder))] IFilter<T, TKey> filter)
        {
            return base.Index(filter);
        }

        [ActionName("New")]
        public override ActionResult Create()
        {
            return base.Create();
        }

        public override ActionResult Create([ModelBinder(typeof(MunqModelBinder))] T entity)
        {
            return base.Create(entity);
        }

        [ActionName("Edit")]
        public override ActionResult Update(TKey id)
        {
            return base.Update(id);
        }

        public override ActionResult Update(TKey id, [ModelBinder(typeof(MunqModelBinder))] T entity)
        {
            return base.Update(id, entity);
        }

        [ActionName("Delete")]
        public override ActionResult Destroy(TKey id)
        {
            return base.Destroy(id);
        }
    }
}
