using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Common
{
    public class DynamicDictionary : DynamicObject
    {
        IDictionary<string, object> dictionary = new Dictionary<string, object>();

        public DynamicDictionary(IDictionary<string, object> dictionary)
        {
            this.dictionary = dictionary;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return dictionary.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }
    }
}
