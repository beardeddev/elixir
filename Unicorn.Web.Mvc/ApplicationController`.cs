using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Unicorn.Web.Mvc
{
    using Unicorn.Web.Mvc.Extensions;
    using Unicorn.Data.Contracts;
    using Unicorn.Resources;
    using Unicorn.Web.Mvc.Configuration;

    public class ApplicationController<T, TKey> : ApplicationController, IApplicationController
       where T : class, IEntity<TKey>, new()
    {
        private IRepository<T, TKey> repository;        

        public RouteNames RouteNames { get; private set; }

        public ApplicationController(IResourceManagerFactory resourceFactory, IRepository<T, TKey> repository)
            : base(resourceFactory)
        {
            this.RouteNames = new RouteNames();
            this.repository = repository;
            this.repository.BeginTransaction();            
        }

        protected void SetRouteNames(Action<RouteNames> action)
        {
            action(this.RouteNames);
        }

        protected virtual dynamic LoadCollection(IFilter<T, TKey> filter)
        {
            return repository.GetPaged(filter);
        }

        protected virtual dynamic LoadModel(TKey id)
        {
            return repository.GetById(id);
        }

        protected virtual RedirectToRouteResult RedirectToCollectionUrl()
        {
            return RedirectToAction(this.RouteNames.IndexName);
        }

        protected virtual RedirectToRouteResult RedirectToResourceUrl(T resource)
        {
            return RedirectToAction(this.RouteNames.EditName, new { @id = resource.Id });
        }

        protected virtual RedirectToRouteResult RedirectToDefaultUrl(T resource)
        {
            return RedirectToCollectionUrl();
        }

        [HttpGet]
        public virtual ActionResult Index(IFilter<T, TKey> filter)
        {
            ViewBag.Filter = filter;
            dynamic model = this.LoadCollection(filter);

            return View(this.RouteNames.IndexName, model);
        }

        [HttpGet]
        public virtual ActionResult Show(TKey id)
        {
            dynamic model = this.LoadModel(id);
            return ObjectOr404(this.RouteNames.ShowName, model);
        }

        [HttpGet, ValidateInput(false)]
        public virtual ActionResult Create()
        {
            T model = new T();
            return View(this.RouteNames.NewName, model);
        }

        [HttpPost, ValidateInput(false)]
        public virtual ActionResult Create(T entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Insert(entity);
                    Flash.Success = ResourceManager.GetHtmlString("DataSuccessfullySaved");
                    return RedirectToDefaultUrl(entity);
                }
                catch (Exception ex)
                {
                    Flash.Error(ex.Message);
                }
            }

            return View(this.RouteNames.NewName, entity);
        }

        [HttpGet, ValidateInput(false)]
        public virtual ActionResult Update(TKey id)
        {
            dynamic model = this.LoadModel(id);
            return ObjectOr404(this.RouteNames.EditName, model);
        }

        [HttpPut, ValidateInput(false)]
        public virtual ActionResult Update(TKey id, T entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(entity);
                    Flash.Success = ResourceManager.GetHtmlString("DataSuccessfullyUpdated");
                    return RedirectToDefaultUrl(entity);
                }
                catch (Exception ex)
                {
                    Flash.Error = ex.Message;
                }
            }

            return View(this.RouteNames.EditName, entity);
        }

        [HttpDelete]
        public virtual ActionResult Destroy(TKey id)
        {
            try
            {
                T entity = repository.GetById(id);
                repository.Delete(entity);
                Flash.Success = ResourceManager.GetHtmlString("DataSuccessfullyDeleted");
            }
            catch (Exception ex)
            {
                Flash.Error = ex.Message;
            }

            return RedirectToCollectionUrl();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && repository != null)
            {
                repository.CommitTransaction();
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
