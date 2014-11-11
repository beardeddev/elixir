using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Web.Mvc
{
    public class LocationFormat
    {
        public string Path { get; private set; }
        public string Format { get; private set; }
        public string Theme { get; private set; }

        public string Location
        {
            get
            {
                if (Theme != null) 
                { 
                    return string.Join("/", Path, Theme, Format); 
                }
                else
                {
                    return string.Join("/", Path, Format); 
                }
                
            }
        }


        public LocationFormat(string path, string theme, string format)
        {
            this.Path = path;
            this.Theme = theme;
            this.Format = format;
        }
    }
}
