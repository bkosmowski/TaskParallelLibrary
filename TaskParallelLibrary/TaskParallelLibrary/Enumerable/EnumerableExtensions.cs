using System;
using System.Collections;
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

        private static IEnumerable<TResult> SelectImpl<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }
        
        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            checked
            {
                var index = 0;
                foreach (var item in source)
                {
                    if (predicate(item)) index++;
                }
                return index;   
            }
        }

        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            if (source is ICollection<TSource> genericCollection) return genericCollection.Count;
            if (source is ICollection nonGenericCollection) return nonGenericCollection.Count;

            checked
            {
                var index = 0;
                foreach (var item in source)
                {
                    index++;
                }
                return index;
            }
        }

        public static long LongCount<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            checked
            {
                var index = 0L;
                foreach (var item in source)
                {
                    if (predicate(item))
                    {
                        index++;
                    }
                }

                return index;
            }
        }

        public static long LongCount<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (source is ICollection<TSource> genericCollection) return genericCollection.Count;
            if (source is ICollection nonGenericCollection) return nonGenericCollection.Count;

            checked
            {
                var index = 0L;
                foreach (var item in source)
                {
                    index++;
                }
                return index;
            }
        }

        public static TSource Find<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
            }

            return default;
        }

        public static IEnumerable<TResult> Zip<TResult, TFirst, TSecond>(this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> selector)
        {
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            using (var firstEnumerator = first.GetEnumerator())
            using (var secondEnumerator = second.GetEnumerator())
            {
                while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
                {
                    yield return selector(firstEnumerator.Current, secondEnumerator.Current);
                }
            }
        }
    }
}