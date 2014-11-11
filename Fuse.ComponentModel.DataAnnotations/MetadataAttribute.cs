using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fuse.ComponentModel.DataAnnotations
{
    public abstract class MetadataAttribute : Attribute
    {
        /// <summary>
        /// Method for processing custom attribute data.
        /// </summary>
        /// <param name="modelMetaData">A ModelMetaData instance.</param>
        public abstract void Process(ModelMetadata modelMetaData);
    }
}