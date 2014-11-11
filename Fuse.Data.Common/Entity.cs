using Fuse.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fuse.Data.Common
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [GridColumn(true, Order = 0)]
        public abstract TKey Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new; otherwise, <c>false</c>.
        /// </value>
        [ScaffoldColumn(false), GridColumn(false)]
        public abstract bool IsNew { get; set; }

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

        private DateTime createdOn = DateTime.Now;

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        [ScaffoldColumn(false)]
        public virtual DateTime CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }

        private DateTime updatedOn = DateTime.Now;

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        /// <value>
        /// The updated on.
        /// </value>
        [ScaffoldColumn(false)]
        public virtual DateTime UpdatedOn
        {
            get { return updatedOn; }
            set { updatedOn = value; }
        }
    }
}