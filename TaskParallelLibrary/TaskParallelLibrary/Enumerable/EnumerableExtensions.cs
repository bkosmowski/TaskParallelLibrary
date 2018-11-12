using System;
using System.Collections.Generic;

namespace TaskParallelLibrary.Enumerable
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
            Func<TSource,  bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return WhereImpl(source, predicate);
        }
        
        private static IEnumerable<TSource> WhereImpl<TSource>( 
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate) 
        { 
            foreach (var item in source) 
            { 
                if (predicate(item)) 
                { 
                    yield return item; 
                } 
            } 
        }
    }
}