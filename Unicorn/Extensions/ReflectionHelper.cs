using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace Unicorn.Extensions
{
    /// <summary>
    /// These class can be used to manipulate instances of loaded types, 
    /// for example to invoke getters or setters for properties
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// Sets the value of the property using typed delegate via DynamicInvoke.
        /// </summary>
        /// <param name="target">The object whose property value will be set.</param>
        /// <param name="properyName">The name of a property to be set.</param>
        /// <param name="value">The new value for this property.</param>
        public static void SetPropertyValue(this object target, string properyName, object value)
        {
            PropertyInfo pi = target.GetType().GetProperty(properyName);
            Type setter = Expression.GetActionType(pi.PropertyType);
            Delegate dl = Delegate.CreateDelegate(setter, target, pi.GetSetMethod());
            dl.DynamicInvoke(new object[] { value });
        }

        /// <summary>
        /// Returns the value of the property using typed delegate via DynamicInvoke.
        /// </summary>
        /// <param name="target">The object whose property value will be returned.</param>
        /// <param name="properyName">The name of a property which value will be returned.</param>
        /// <returns>The property value for the target parameter.</returns>
        public static object GetPropertyValue(this object target, string properyName)
        {
            PropertyInfo pi = target.GetType().GetProperty(properyName);
            Type getter = Expression.GetFuncType(pi.PropertyType);
            Delegate dl = Delegate.CreateDelegate(getter, target, pi.GetGetMethod());
            return dl.DynamicInvoke(new object[] { });
        }

        /// <summary>
        /// Returns the value of the property using typed delegate via DynamicInvoke.
        /// </summary>
        /// <typeparam name="T">
        /// The type of property will be returned
        /// </typeparam>
        /// <param name="target">The object whose property value will be returned.</param>
        /// <param name="properyName">The name of a property which value will be returned.</param>
        /// <returns>The property value converted to typeof(T) for the target parameter.</returns>
        public static T GetPropertyValue<T>(this object target, string properyName)
        {
            return (T)target.GetPropertyValue(properyName);
        }
    }
}
