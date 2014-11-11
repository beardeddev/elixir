using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fuse.Web.Mvc
{
    public class FuseViewEngine : RazorViewEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuseViewEngine"/> class.
        /// </summary>
        public FuseViewEngine(string path, string theme)
        {
            this.AreaMasterLocationFormats = new LocationFormatCollection(path, theme)
                .AppendFormat("{2}/{1}/{0}.cshtml")
                .AppendFormat("{2}/Shared/{0}.cshtml")
                .AppendFormat("{2}/Shared/Scaffolding/{0}.cshtml")
                .LocationFormats;

            this.AreaViewLocationFormats = new LocationFormatCollection(path, theme)
                .AppendFormat("{2}/{1}/{0}.cshtml")
                .AppendFormat("{2}/Shared/{0}.cshtml")
                .AppendFormat("{2}/Shared/Scaffolding/{0}.cshtml")
                .LocationFormats;

            this.MasterLocationFormats = new LocationFormatCollection(path, theme)
                .AppendFormat("{1}/{0}.cshtml")
                .AppendFormat("Shared/{0}.cshtml")
                .AppendFormat("Shared/Scaffolding/{0}.cshtml")
                .LocationFormats;

            this.ViewLocationFormats = new LocationFormatCollection(path, theme)
                .AppendFormat("{1}/{0}.cshtml")
                .AppendFormat("Shared/{0}.cshtml")
                .AppendFormat("Shared/Scaffolding/{0}.cshtml")
                .LocationFormats;

            this.PartialViewLocationFormats = new LocationFormatCollection(path, theme)
                .AppendFormat("{1}/{0}.cshtml")
                .AppendFormat("Shared/{0}.cshtml")
                .AppendFormat("Shared/Scaffolding/{0}.cshtml")
                .LocationFormats;

            this.AreaPartialViewLocationFormats = this.AreaViewLocationFormats;

            this.FileExtensions = new string[1]
            {
                "cshtml",
            };
        }

        /// <summary>
        /// Creates a partial view using the specified controller context and partial path.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="partialPath">The path to the partial view.</param>
        /// <returns>
        /// The partial view.
        /// </returns>
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return (IView)new FuseWebView(controllerContext, partialPath, (string)null, false, (IEnumerable<string>)this.FileExtensions, this.ViewPageActivator);
        }

        /// <summary>
        /// Creates a view by using the specified controller context and the paths of the view and master view.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="viewPath">The path to the view.</param>
        /// <param name="masterPath">The path to the master view.</param>
        /// <returns>
        /// The view.
        /// </returns>
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return (IView)new FuseWebView(controllerContext, viewPath, masterPath, true, (IEnumerable<string>)this.FileExtensions, this.ViewPageActivator);
        }

    }
}