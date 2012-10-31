using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicorn.Web.Mvc.Configuration
{
    public class RouteNames
    {
        public string IndexName { get; set; }

        public string ShowName { get; set; }

        public string CreateName { get; set; }

        public string UpdateName { get; set; }

        public string DestroyName { get; set; }

        public string NewName { get; set; }

        public string EditName { get; set; }

        public string DeleteName { get; set; }

        public RouteNames()
        {
            this.IndexName = "Index";
            this.ShowName = "Show";
            this.NewName = "Create";
            this.CreateName = "Create";
            this.EditName = "Update";
            this.UpdateName = "Update";
            this.DeleteName = "Delete";
            this.DestroyName = "Destroy";
        }
    }
}
