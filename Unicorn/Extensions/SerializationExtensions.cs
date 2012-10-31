using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;

namespace Unicorn.Extensions
{
    /// <summary>
    /// Provides methods to serialize objects.
    /// </summary>
    public static class SerializationExtensions
    {
        /// <summary>
        /// Serialize object as XML string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="omitDeclaration">if set to <c>true</c> [omit declaration].</param>
        /// <param name="removeNS">if set to <c>true</c> [remove NS].</param>
        /// <returns>XML string representation of an object.</returns>
        public static string ToXml(this object value, bool omitDeclaration = true, bool removeNS = true)
        {
            // removing declaration
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = omitDeclaration;
            settings.Indent = true;

            // removing namespaces
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            if (removeNS)
            {
                ns.Add(string.Empty, string.Empty);
            }

            // serializing value
            XmlSerializer xml = new XmlSerializer(value.GetType());
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, settings);
            xml.Serialize(writer, value, ns);
            writer.Flush();
            writer.Close();
            return sb.ToString();
        }

        /// <summary>
        /// Creates instance of and object of a given type from xml string.
        /// </summary>
        /// <param name="xml">The xml string that represents and object.</param>
        /// <param name="type">The type of an object to create.</param>
        /// <returns>Deserialized instance of an object.</returns>
        public static object FromXml(this Type type, string xml)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            byte[] data = Encoding.UTF8.GetBytes(xml);
            MemoryStream memoryStream = new MemoryStream(data);
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return serializer.Deserialize(memoryStream);
        }
    }
}