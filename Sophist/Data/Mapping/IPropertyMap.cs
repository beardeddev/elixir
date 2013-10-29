using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sophist.Data.Mapping
{
    public interface IPropertyMap
    {
        string ColumnName { get; }
        bool IsIgnored { get; }
        bool IsKey { get; }
        bool IsUpdatable { get; }
        bool AutoAddNow { get; }
        bool AutoUpdateNow { get; }

        IPropertyMap Ignore();
        IPropertyMap HasColumnName(string columnName);
        IPropertyMap SetAsKey();
        IPropertyMap SetAsKey(KeyType keyType);
        IPropertyMap NonUpdatable();
        IPropertyMap Timestamp(bool autoAddNow, bool autoUpdateNow);
    }
}
