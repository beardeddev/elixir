using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace Sophist.Web.Mvc.UI
{
    using Sophist.Web.Mvc.Scaffolding;
    using System.IO;
    

    public class Grid<T> : IHtmlString where T : class, IEntity
    {
        private readonly IEnumerable<T> items;        
        private readonly ViewContext context;
        private ModelMetadata modelMetadata;
        private ModelMetadata[] fields;
        private IDictionary<string, object> attributes;
        private Type viewModelType;

        public Grid(IEnumerable<T> items, ViewContext context, IDictionary<string, object> attributes)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            
            this.items = items;
            this.context = context;
            this.attributes = attributes ?? new Dictionary<string, object>();
        }

        public virtual void Render(HtmlTextWriter writer)
        {            
            if (viewModelType == null)
            {
                modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, this.items.GetType().GetGenericArguments()[0]); 
            }
            else
            {
                modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, viewModelType);
            }

            object showInGrid = (object)false;
            this.fields = modelMetadata.Properties.Where(
                x => !x.IsComplexType && (!x.AdditionalValues.TryGetValue("ShowInGrid", out showInGrid) || (bool)showInGrid))
                    .ToArray();

            if (attributes == null)
            {
                this.attributes = new Dictionary<string, object>();
            }

            RenderBeginTag(writer);
            RenderHead(writer);
            RenderBody(writer);
            RenderEndTag(writer);
        }

        public virtual void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Table);
            RenderAttributes(writer);
        }

        public virtual void RenderAttributes(HtmlTextWriter writer)
        {
            foreach (KeyValuePair<string, object> entry in this.attributes)
            {
                writer.WriteAttribute(entry.Key, entry.Value.ToString(), false);
            }
        }

        public virtual void RenderHead(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Thead);
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);

            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.WriteLine("<input type=\"checkbox\" name=\"check-all\" id=\"check-all\" />");
            writer.RenderEndTag();

            foreach (ModelMetadata field in fields)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Th);
                writer.Write(field.GetDisplayName());
                writer.RenderEndTag();
            }
            writer.RenderEndTag();
            writer.RenderEndTag();
        }

        public virtual void RenderBody(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Tbody);
            foreach (T item in items)
            {
                RenderRow(writer, item);
            }            
            writer.RenderEndTag();
        }

        public virtual void RenderRow(HtmlTextWriter writer, T item)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.WriteLine("<input type=\"checkbox\" name=\"check-id\" id=\"check-id\" value=\"{0}\" />", item.Id);
            foreach (ModelMetadata field in fields)
            {
                RenderCell(writer, item, field);
            }
            writer.RenderEndTag();
        }

        public virtual void RenderCell(HtmlTextWriter writer, T item, ModelMetadata metadata)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.Write(item.GetType().GetProperty(metadata.PropertyName).GetValue(item));
            writer.RenderEndTag();
        }

        public virtual void RenderEndTag(HtmlTextWriter writer)
        {
            writer.RenderEndTag();
        }

        public string ToHtmlString()
        {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter()))
            {
                this.Render(writer);
                return writer.ToString();
            }
        }

        public override string ToString()
        {
            return this.ToHtmlString();
        }
    }
}
