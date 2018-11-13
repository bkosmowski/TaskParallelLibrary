using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace TaskParallelLibrary.Enumerable
{
    public class EnumerableImpl
    {
        public static IEnumerable<int> Range(int start, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if ((long) start + count - 1L > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return RangeImpl(start, count);
        }

        private static IEnumerable<int> RangeImpl(int start, int count)
        {
            for (var index = 0; index < count; index++)
            {
                yield return start + index;
            }
        }

        public static IEnumerable<TResult> Empty<TResult>()
        {
            return EmptyHolder<TResult>.Empty;
        }

        private static class EmptyHolder<T>
        {
          public static readonly T[] Empty = new T[0];
        }
    }
}