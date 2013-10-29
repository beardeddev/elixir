using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.Data
{
    using Sophist.ComponentModel.DataAnnotations;

    public abstract class Entity<TKey> : EntityBase<TKey>
    {
        private bool isNew = true;

        [NotMapped, ScaffoldColumn(false), GridColumn(false)]
        public override bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }
    }
}
