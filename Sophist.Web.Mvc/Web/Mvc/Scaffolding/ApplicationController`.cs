using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sophist.Web.Mvc.Scaffolding
{    
    using Sophist.Web.Mvc;
    using Sophist.Data;
    using Sophist.Resources;
    
    public abstract class ApplicationController<T, TKey> : ApplicationController
        where T : class, IEntity<TKey>, new()
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
        public virtual ActionResult Index([ModelBinder(typeof(EntityFilterModelBinder))] IFilter<T> filter)
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
                    Flash.Success = ResourceManager.GetString("Message_Save_Success");
                    return RedirectToDefaultUrl(entity);
                }
                catch (Exception ex)
                {
                    Flash.Error = ex.Message;
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
                    Flash.Success = ResourceManager.GetString("Message_Save_Success");
                    return RedirectToDefaultUrl(entity);
                }
                catch (Exception ex)
                {
                    Flash.Error = ex.InnerException.Message;
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
                Flash.Success = ResourceManager.GetString("Message_Delete_Success");
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
                repository.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            /*
            if (filterContext.Result is ViewResult)
            {
                ViewResult viewResult = (ViewResult)filterContext.Result;
                WebViewPage viewPage = (WebViewPage)viewResult.View;

                string controller = filterContext.RouteData.GetRequiredString("controller");
                string action = filterContext.RouteData.GetRequiredString("action");

                IHtmlString controllerName = ResourceManager.GetHtmlString(controller);
                IHtmlString actionName = ResourceManager.GetHtmlString(action);

                viewPage.Page.Description = string.Format("{0} :: {1}", controllerName, actionName);

                object areaDataToken = null;
                if (filterContext.RouteData.DataTokens.TryGetValue("area", out areaDataToken))
                {
                    IHtmlString areaName = ResourceManager.GetHtmlString(areaDataToken.ToString());

                    viewPage.Page.Title = string.Format("{0} :: {1} :: {2} | {3}",
                        areaName,
                        controllerName,
                        actionName,
                        filterContext.HttpContext.Request.Url.Host);
                }
                else
                {
                    viewPage.Page.Title = string.Format("{0} :: {1} | {2}",
                        controllerName,
                        actionName,
                        filterContext.HttpContext.Request.Url.Host);
                }

                viewPage.Page.IsCreateAction = string.Compare(action, this.RouteNames.CreateName, true) == 0;
                viewPage.Page.IsNewAction = string.Compare(action, this.RouteNames.NewName, true) == 0;
            }
            */
        }
    }
}
