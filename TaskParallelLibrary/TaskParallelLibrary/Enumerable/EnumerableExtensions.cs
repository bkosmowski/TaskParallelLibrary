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
        
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int,  bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return WhereImpl(source, predicate);
        }
        
        private static IEnumerable<TSource> WhereImpl<TSource>( 
            this IEnumerable<TSource> source, 
            Func<TSource, int, bool> predicate) 
        { 
            var index = 0; 
            foreach (var item in source) 
            { 
                if (predicate(item, index)) 
                { 
                    yield return item; 
                } 
                index++; 
            } 
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return SelectImpl(source, selector);
        }

        public static IEnumerable<TResult> SelectImpl<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }
    }
}