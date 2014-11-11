using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fuse.Data.RavenDb
{
    using Fuse.Data.Common;
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// 
    /// </summary>
    public class Document : Entity<int>
    {
        [JsonIgnore]
        public override bool IsNew { get; set; }

        [ScaffoldColumn(false)]
        public override int Id { get; set; }
    }
}
