using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fuse.Web.Mvc
{
    using Fuse.ComponentModel.DataAnnotations;

    public class FuseModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            ModelMetadata modelMetadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            attributes.OfType<MetadataAttribute>().ToList().ForEach(x => x.Process(modelMetadata));
            return modelMetadata;
        }
    }
}