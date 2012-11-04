using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLToolkit.Mapping;
using BLToolkit.DataAccess;

namespace Unicorn.Data.BLToolkit
{
    public class Entity<T, TKey> : Unicorn.Data.Common.Entity<T, TKey>
        where T : Entity<T, TKey>, new()
    {
        [MapIgnore(true)]
        public override bool IsNew
        {
            get
            {
                return base.IsNew;
            }
        }

        [PrimaryKey]
        public override TKey Id { get; set; }
    }
}
