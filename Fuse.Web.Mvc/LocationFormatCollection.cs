using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Web.Mvc
{
    public class LocationFormatCollection : Collection<LocationFormat>
    {
        public LocationFormatCollection(string path, string theme)
        {
            this.Path = path;
            this.Theme = theme;
        }

        public LocationFormatCollection(string path)
            : this(path, null)
        {
        }

        public LocationFormatCollection AppendFormat(string format)
        {
            this.Add(new LocationFormat(this.Path, this.Theme, format));
            return this;
        }

        public string Path { get; private set; }

        public string Theme { get; private set; }

        public string[] LocationFormats
        {
            get
            {
                return this.Items.Select(x => x.Location).ToArray();
            }
        }

    }
}
