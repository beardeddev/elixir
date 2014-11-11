using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fuse.ComponentModel.DataAnnotations
{
    public class GridColumnAttribute : MetadataAttribute
    {
        /// <summary>
        /// Gets or sets a value indicating whether column should be shown in grid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show in grid]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowInGrid { get; set; }

        private int order = int.MaxValue;

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Order
        {
            get { return order; }
            set { order = value; }
        }
        

        /// <summary>
        /// Initializes a new instance of the <see cref="GridColumnAttribute"/> class.
        /// </summary>
        /// <param name="showInGrid">if set to <c>true</c> [show in grid].</param>
        public GridColumnAttribute(bool showInGrid)
        {
            this.ShowInGrid = showInGrid;
        }

        /// <summary>
        /// Method for processing custom attribute data.
        /// </summary>
        /// <param name="modelMetaData">A ModelMetaData instance.</param>
        public override void Process(ModelMetadata modelMetaData)
        {
            modelMetaData.AdditionalValues.Add("ShowInGrid", this.ShowInGrid);
            modelMetaData.AdditionalValues.Add("Order", this.Order);           
        }
    }
}