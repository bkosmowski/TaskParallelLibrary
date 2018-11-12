using System;
using System.Collections.Generic;

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
    }
}