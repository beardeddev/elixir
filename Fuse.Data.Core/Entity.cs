using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fuse.Data.Core
{
    using Kame.ComponentModel.DataAnnotations;

    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public abstract TKey Id { get; set; }

        [NotMapped, ScaffoldColumn(false), GridColumn(false)]
        public bool IsNew { get; set; }

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
        public DateTime CreatedOn
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
        public DateTime UpdatedOn
        {
            get { return updatedOn; }
            set { updatedOn = value; }
        }
    }
}