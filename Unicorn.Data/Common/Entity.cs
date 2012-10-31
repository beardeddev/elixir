using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Unicorn.Data.Common
{
    using Unicorn.Data.Contracts;

    public abstract class Entity<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        dynamic IEntity.Id
        {
            get
            {
                return this.Id;
            }
            set
            {
                this.Id = Convert.ChangeType(value, typeof(TKey));
            }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public abstract TKey Id { get; set; }

        /// <summary>
        /// Converts entity to Uri parameters.
        /// </summary>
        /// <returns>Anonymous object representing query string parameters.</returns>
        public virtual object ToUrlParams()
        {
            return new { @id = this.Id };
        }

        /// <summary>
        /// Gets a value indicating whether this instance is new.
        /// </summary>        
        [Editable(false), ScaffoldColumn(false)]
        public virtual bool IsNew
        {
            get
            {
                return Comparer<TKey>.Default.Compare(this.Id, default(TKey)) == 0;
            }
        }


        /// <summary>
        /// Updates entity attributes.
        /// </summary>
        /// <param name="attributes">Object containing entity attributes collection.</param>
        /// <returns>
        /// <c>true</c> if entity attributes updated successfully; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool UpdateAttributes(object attributes);
    }
}
