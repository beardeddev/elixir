using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Sophist.Web.Mvc.UI
{
    public class Grid : IHtmlString
    {
        private readonly IEnumerable items;
        private readonly ViewContext context;
        private ModelMetadata modelMetadata;
        private ModelMetadata[] fields;
        private IDictionary<string, object> attributes;
        private Type viewModelType;

        public Grid(IEnumerable items, ViewContext context, IDictionary<string, object> attributes)
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
            this.modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, this.items.GetType().GetGenericArguments()[0]);

            object showInGrid = (object)false;
            this.fields = modelMetadata.Properties.Where(
                x => !x.IsComplexType && (!x.AdditionalValues.TryGetValue("ShowInGrid", out showInGrid) || (bool)showInGrid))
                    .ToArray();
        }

        public virtual void Render(HtmlTextWriter writer)
        {
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

            //writer.RenderBeginTag(HtmlTextWriterTag.Th);
            //writer.WriteLine("<input type=\"checkbox\" name=\"check-all\" id=\"check-all\" />");
            //writer.RenderEndTag();

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
            foreach (object item in items)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                RenderRow(writer, item);
                writer.RenderEndTag();
            }
            writer.RenderEndTag();
        }

        public virtual void RenderRow(HtmlTextWriter writer, object item)
        {
            //writer.RenderBeginTag(HtmlTextWriterTag.Td);
            //writer.WriteLine("<input type=\"checkbox\" name=\"check-id\" id=\"check-id\" value=\"{0}\" />", item.Id);
            //writer.RenderEndTag();

            foreach (ModelMetadata field in fields)
            {
                RenderCell(writer, item, field);
            }            
        }

        public virtual void RenderCell(HtmlTextWriter writer, object item, ModelMetadata metadata)
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
            using (StringWriter stringWriter = new StringWriter())
            {
                using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
                {
                    this.Render(writer);
                    return stringWriter.ToString();
                }
            }
        }

        public override string ToString()
        {
            return this.ToHtmlString();
        }
    }
}
