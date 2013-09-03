using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sophist.Web.Mvc
{
    public class SophistViewEngine : RazorViewEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElixirViewEngine"/> class.
        /// </summary>
        public SophistViewEngine()
        {
            this.AreaMasterLocationFormats = new string[2] 
            {
                "~/Views/{2}/{1}/{0}.cshtml",
                "~/Views/{2}/Shared/{0}.cshtml",
            };

            this.AreaViewLocationFormats = new string[2] 
            {
                "~/Views/{2}/{1}/{0}.cshtml",
                "~/Views/{2}/Shared/{0}.cshtml",
            };

            this.AreaPartialViewLocationFormats = this.AreaViewLocationFormats;

            this.ViewLocationFormats = new string[3]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/Scaffolding/{0}.cshtml",
            };

            this.MasterLocationFormats = new string[3]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/Scaffolding/{0}.cshtml",
            };

            this.PartialViewLocationFormats = new string[4]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/_{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/Scaffolding/{0}.cshtml",
            };

            this.FileExtensions = new string[1]
            {
                "cshtml",
            };
        }
    }
}
