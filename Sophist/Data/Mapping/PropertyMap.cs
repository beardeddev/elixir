using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sophist.Data.Mapping
{
    public class PropertyMap : IPropertyMap
    {
        public MemberInfo MemberInfo { get; private set; }
        public bool IsKey { get; private set; }
        public KeyType KeyType { get; private set; }
        public string ColumnName { get; private set; }
        public bool IsIgnored { get; private set; }        
        public bool IsUpdatable { get; private set; }
        public bool AutoAddNow { get; private set; }
        public bool AutoUpdateNow { get; private set; }

        public PropertyMap(MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException("memberInfo");
            }

            this.MemberInfo = memberInfo;
            this.ColumnName = memberInfo.Name;
        }

        public IPropertyMap HasColumnName(string columnName)
        {
            this.ColumnName = columnName;
            return this;
        }

        public IPropertyMap Ignore()
        {
            this.IsIgnored = true;
            return this;
        }

        public IPropertyMap SetAsKey(KeyType keyType)
        {
            this.IsKey = true;
            this.KeyType = keyType;
            return this;
        }

        public IPropertyMap SetAsKey()
        {
            return this.SetAsKey(KeyType.None);
        }

        public IPropertyMap NonUpdatable()
        {
            this.IsUpdatable = false;
            return this;
        }

        public IPropertyMap Timestamp(bool autoAddNow, bool autoUpdateNow)
        {
            if (this.MemberInfo.ReflectedType != typeof(DateTime))
            {
                throw new ArgumentException("Timestamp property should have type of System.DateTime.");
            }

            this.AutoAddNow = autoAddNow;
            this.AutoUpdateNow = autoUpdateNow;

            return this;
        }
    }
}
