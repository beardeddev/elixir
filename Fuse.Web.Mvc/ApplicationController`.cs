using Fuse.Data;
using Fuse.Resources;
using RestfulRouting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFlash.Core.Extensions;
using System.Web.Routing;
using Fuse.Web.Mvc.Html;

namespace Fuse.Web.Mvc
{
    using Fuse.Common;
    using Fuse.Data.Common;
    using System.Resources;

    public abstract class ApplicationController<T, TKey> : ApplicationController
         where T : class, IEntity<TKey>, new()
    {
        private IRepository<T, TKey> repository;

        public ApplicationController(IRepository<T, TKey> repository)
        {
            this.repository = repository;
        }

        protected virtual IPagedCollection LoadCollection(IFilter<T, TKey> filter)
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
            return RedirectToAction(this.RouteNames.ShowName, new { @id = resource.Id });
        }

        protected virtual RedirectToRouteResult RedirectToDefaultUrl(T resource)
        {
            return RedirectToCollectionUrl();
        }

        [HttpGet]
        public virtual ActionResult Index(Filter<T, TKey> filter)
        {
            IPagedCollection model = this.LoadCollection(filter);
            return View(this.RouteNames.IndexName, model);
        }

        [HttpGet]
        public virtual ActionResult Show(TKey id)
        {
            dynamic model = this.LoadModel(id);
            return ObjectOr404(this.RouteNames.ShowName, model);
        }

        [HttpGet, ValidateInput(false)]
        public virtual ActionResult New()
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
                    entity = repository.Insert(entity);
                    Flash.Success(content:  (string)Messages.SuccessSave);
                    return RedirectToDefaultUrl(entity);
                }
                catch (Exception ex)
                {
                    Flash.Error(content: ex.ExpandMessage());
                }
            }

            return View(this.RouteNames.NewName, entity);
        }

        [HttpGet, ValidateInput(false)]
        public virtual ActionResult Edit(TKey id)
        {
            dynamic model = this.LoadModel(id);
            return ObjectOr404(this.RouteNames.EditName, model);
        }

        [HttpPut, ValidateInput(false)]
        public virtual ActionResult Update(long id, T entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    entity = repository.Update(entity);
                    Flash.Success(content: (string)Messages.SuccessUpdate);
                    return RedirectToDefaultUrl(entity);
                }
                catch (Exception ex)
                {
                    Flash.Error(content: ex.ExpandMessage());
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
                Flash.Success(content: (string)Messages.SuccessDestroy);
            }
            catch (Exception ex)
            {
                Flash.Error(content: ex.ExpandMessage());
            }

            return RedirectToCollectionUrl();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && repository != null)
            {
                repository.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            
        }
            
    }
}