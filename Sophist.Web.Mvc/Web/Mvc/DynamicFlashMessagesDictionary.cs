using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.Web.Mvc
{
    public class DynamicFlashMessagesDictionary : DynamicObject
    {
        private readonly Func<FlashMessagesDictionary> _viewDataThunk;

        private FlashMessagesDictionary FlashMessages
        {
          get
          {
            return this._viewDataThunk();
          }
        }

        public DynamicFlashMessagesDictionary(Func<FlashMessagesDictionary> viewDataThunk)
        {
          this._viewDataThunk = viewDataThunk;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
          return (IEnumerable<string>) this.FlashMessages.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
          result = this.FlashMessages[binder.Name];
          return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
          this.FlashMessages[binder.Name] = value;
          return true;
        }
    }
}
