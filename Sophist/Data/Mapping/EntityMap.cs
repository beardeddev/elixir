using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.Data.Mapping
{
    public class EntityMap : IEntityMap
    {
        public string SchemaName { get; private set;  }

        public string TableName { get; private set; }

        public IDictionary<string, IPropertyMap> Properties { get; private set; }

        public IEnumerable<IPropertyMap> PrimaryKeys
        {
            get
            {
                return this.Properties.Values.Where(x => x.IsKey);
            }
        }

        public IEnumerable<IPropertyMap> SelectColumns
        {
            get
            {
                return this.Properties.Values.Where(x => !x.IsIgnored);
            }
        }

        public EntityMap(Type entityType)
        {
            this.Properties = new Dictionary<string, IPropertyMap>();
            this.TableName = entityType.Name;
        }

        public IEntityMap ToTable(string tableName)
        {
            return this.ToTable(null, tableName);
        }

        public IEntityMap ToTable(string schemaName, string tableName)
        {
            this.SchemaName = schemaName;
            this.TableName = tableName;
            return this;
        }

        public IPropertyMap Property<T, TProperty>(Expression<Func<T, TProperty>> selector)
        {
            return GetOrCreatePropertyMap(selector);
        }

        public IEntityMap Ignore<T, TProperty>(Expression<Func<T, TProperty>> selector)
        {
            IPropertyMap propertyMap = GetOrCreatePropertyMap(selector);
            propertyMap.Ignore();
            return this;
        }

        public IEntityMap HasKey<T, TProperty>(Expression<Func<T, TProperty>> selector, KeyType keyType)
        {
            IPropertyMap propertyMap = GetOrCreatePropertyMap(selector);
            propertyMap.SetAsKey(keyType);
            return this;
        }

        public IEntityMap HasKey<T, TProperty>(Expression<Func<T, TProperty>> selector)
        {
            return this.HasKey(selector, KeyType.None);
        }

        private IPropertyMap GetOrCreatePropertyMap<T, TProperty>(Expression<Func<T, TProperty>> selector)
        {
            MemberInfo propertyInfo = selector.GetProperty();            

            IPropertyMap propertyMap = null;

            if (!this.Properties.TryGetValue(propertyInfo.Name, out propertyMap))
            {
                propertyMap = new PropertyMap(propertyInfo);
                this.Properties.Add(propertyInfo.Name, propertyMap);
            }

            return propertyMap;
        }


    }
}
