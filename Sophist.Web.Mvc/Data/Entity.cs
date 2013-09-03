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

    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public abstract TKey Id { get; set; }

        dynamic IEntity.Id
        {
            get
            {
                return this.Id;
            }
            set
            {
                this.Id = (TKey)value;
            }
        }

        public virtual object ToUrlParams()
        {
            return new { @id = this.Id };
        }

        [NotMapped, ScaffoldColumn(false), GridColumn(false)]
        public virtual bool IsNew { get; set; }
    }
}
