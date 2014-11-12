using Fuse.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Data.EntityFramework
{
    public abstract class Entity<TKey> : Fuse.Data.Common.Entity<TKey>
    {
        [NotMapped, ScaffoldColumn(false), GridColumn(false)]
        public override bool IsNew { get; set; }
    }
}
