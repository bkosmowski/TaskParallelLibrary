using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace TaskParallelLibraryTest.Enumerable
{
    internal sealed class ThrowingEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// For checking that exception was throwing when MoveNext was called
        /// </summary>
        /// <param name="deferredFunction"></param>
        /// <typeparam name="T"></typeparam>
        internal static void AssertDeferred<T>(
            Func<IEnumerable<int>, IEnumerable<T>> deferredFunction)
        {
            ThrowingEnumerable source = new ThrowingEnumerable();
            var result = deferredFunction(source);
            using (var iterator = result.GetEnumerator())
            {
                Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
            }
        }
    }
}