using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fuse.Resources
{
    public class ResourceNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ResourceNotFoundException(string message)
            : base(message)
        {
        }
    }
}