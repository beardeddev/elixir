using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sophist.Data.Mapping
{
    public interface IEntityMap
    {
        string SchemaName { get; }
        string TableName { get; }
        IDictionary<string, IPropertyMap> Properties { get; }
        IEntityMap ToTable(string tableName);
        IEntityMap ToTable(string schemaName, string tableName);
        IPropertyMap Property<T, TProperty>(Expression<Func<T, TProperty>> selector);
        IEntityMap Ignore<T, TProperty>(Expression<Func<T, TProperty>> selector);
        IEntityMap HasKey<T, TProperty>(Expression<Func<T, TProperty>> selector, KeyType keyType);
        IEntityMap HasKey<T, TProperty>(Expression<Func<T, TProperty>> selector);
    }
}
