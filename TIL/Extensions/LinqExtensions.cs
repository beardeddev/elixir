using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIL.Extensions
{
    /// <summary>
    /// Represents a class that extend standard LINQ extensions methods.
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Recursive lookup and returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">
        /// <typeparamref name="System.Collections.Generic.IEnumerable<TSource>"/>
        /// The IEnumerable<T> to return the first element of.
        /// </param>
        /// <param name="childrenSelector">A function to expand child elements for a source.</param>
        /// <param name="condition">A function to test each element for a condition.</param>
        /// <returns>default(TSource) if source is empty; otherwise, the first element in source.</returns>
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TSource>> childrenSelector, Predicate<TSource> condition)
        {
            if (source == null || !source.Any()) return default(TSource);

            var attempt = source.FirstOrDefault(t => condition(t));

            if (!Equals(attempt, default(TSource)))
            {
                return attempt;
            }

            return source.SelectMany(childrenSelector).FirstOrDefault(childrenSelector, condition);
        }
    }
}
