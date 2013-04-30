using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elixir.Web.Mvc
{
    using Elixir.Web.Mvc.Components;
    using Elixir.Web.Mvc.Factories;
    using Elixir.Web.Mvc.ModelBinding;
    using Elixir.Data.Contracts;
    
    public abstract class ApplicationController<T, TKey> : ApplicationController
        where T : class, IEntity<T, TKey>, new()
    {
        private IRepository<T, TKey> repository;

        public ApplicationController(IResourceManagerFactory factory, IRepository<T, TKey> repository)
            : base(factory)
        {
            this.repository = repository;
        }

        protected virtual dynamic LoadCollection(IFilter<T> filter)
        {
            return repository.GetPaged(filter);
        }

        protected virtual dynamic LoadModel(int id)
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
        public virtual ActionResult Index([ModelBinder(typeof(DocumentFilterModelBinder))] IFilter<T> filter)
        {
            ViewBag.Filter = filter;
            dynamic model = this.LoadCollection(filter);

            return View(this.RouteNames.IndexName, model);
        }

        [HttpGet]
        public virtual ActionResult Show(int id)
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
                    entity = repository.Save(entity);
                    Flash.Success(ResourceManager.GetString("Message_Save_Success"));
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
        public virtual ActionResult Edit(int id)
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
                    entity = repository.Save(entity);
                    Flash.Success(ResourceManager.GetString("Message_Save_Success"));
                    return RedirectToDefaultUrl(entity);
                }
                catch (Exception ex)
                {
                    Flash.Error(ex.InnerException.Message);
                }
            }

            return View(this.RouteNames.EditName, entity);
        }

        [HttpDelete]
        public virtual ActionResult Destroy(int id)
        {
            try
            {
                T document = repository.GetById(id);
                repository.Delete(document);
                Flash.Success(ResourceManager.GetString("Message_Delete_Success"));
            }
            catch (Exception ex)
            {
                Flash.Error(ex.Message);
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
    }
}
