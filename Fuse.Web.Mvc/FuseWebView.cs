using Fuse.Web.Mvc.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Fuse.Web.Mvc
{
    public class FuseWebView : RazorView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuseWebView"/> class.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="viewPath">The view path.</param>
        /// <param name="layoutPath">The layout path.</param>
        /// <param name="runViewStartPages">if set to <c>true</c> [run view start pages].</param>
        /// <param name="viewStartFileExtensions">The view start file extensions.</param>
        public FuseWebView(ControllerContext controllerContext, string viewPath, string layoutPath, bool runViewStartPages, IEnumerable<string> viewStartFileExtensions)
            : base(controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions, (IViewPageActivator)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FuseWebView"/> class.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="viewPath">The view path.</param>
        /// <param name="layoutPath">The layout or master page.</param>
        /// <param name="runViewStartPages">A value that indicates whether view start files should be executed before the view.</param>
        /// <param name="viewStartFileExtensions">The set of extensions that will be used when looking up view start files.</param>
        /// <param name="viewPageActivator">The view page activator.</param>
        public FuseWebView(ControllerContext controllerContext, string viewPath, string layoutPath, bool runViewStartPages, IEnumerable<string> viewStartFileExtensions, IViewPageActivator viewPageActivator)
            : base(controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions, viewPageActivator)
        {
        }

        protected override void RenderView(ViewContext viewContext, TextWriter writer, object instance)
        {            
#if DEBUG
            writer.WriteLine("<!-- View Start {0} -->", this.ViewPath);
#endif
            base.RenderView(viewContext, writer, instance);
        }
    }
}
