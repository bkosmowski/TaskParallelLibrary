using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TaskParallelLibraryTest.Enumerable
{
    public static class TestExtensions
    {
        internal static void AssertSequenceEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
        {
            Assert.IsTrue(actual.SequenceEqual(expected));
        }
    }
}