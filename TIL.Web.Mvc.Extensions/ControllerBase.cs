using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TIL.Web.Mvc
{
    using TIL.Data;
    using TIL.Data.Entity;
    using TIL.Web.Mvc.ModelBinders;
    using TIL.Web.Mvc.ViewModels;
    
    public abstract class ControllerBase<T, TKey> : ControllerBase
       where T : class, IEntity<TKey>, new()
    {
        private IRepository<T, TKey> repository;

        public ControllerBase(Type resourceType, IRepository<T, TKey> repository)
            : base(resourceType)
        {
            this.repository = repository;
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
            return RedirectToAction("Index");
        }

        protected virtual RedirectToRouteResult RedirectToResourceUrl(T resource)
        {
            return RedirectToAction("Edit", new { @id = resource.Id });
        }

        protected virtual RedirectToRouteResult RedirectToDefaultUrl(T resource)
        {
            return RedirectToCollectionUrl();
        }

        [HttpGet]
        public virtual ActionResult Index([ModelBinder(typeof(MunqModelBinder))] IFilter<T, TKey> filter)
        {
            ViewBag.Filter = filter;
            dynamic model = this.LoadCollection(filter);
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult Show(TKey id)
        {
            dynamic model = this.LoadModel(id);
            return ObjectOr404(model);
        }

        [HttpGet, ValidateInput(false)]
        public virtual ActionResult New()
        {
            T model = new T();
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public virtual ActionResult Create([ModelBinder(typeof(MunqModelBinder))] T entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Insert(entity);
                    Flash.Success(GetString("SuccessInsert"));
                    return RedirectToDefaultUrl(entity);
                }
                catch (Exception ex)
                {
                    Flash.Error(ex.Message);
                }
            }

            return View("New", entity);
        }

        [HttpGet, ValidateInput(false)]
        public virtual ActionResult Edit(TKey id)
        {
            dynamic model = this.LoadModel(id);
            return ObjectOr404(model);
        }

        [HttpPut, ValidateInput(false)]
        public virtual ActionResult Update(TKey id, [ModelBinder(typeof(MunqModelBinder))] T entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    T model = repository.GetById(id);
                    model.UpdateAttributes(entity);
                    Flash.Success(GetString("SuccessUpdate"));
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Flash.Error(ex.Message);
                }
            }

            return View("Edit", entity);
        }

        [HttpDelete]
        public virtual ActionResult Destroy(TKey id)
        {
            try
            {
                T entity = repository.GetById(id);
                repository.Delete(entity);
                Flash.Success(GetString("SuccessDelete"));
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
                repository.CommitTransaction();
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
