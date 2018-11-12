using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TaskParallelLibraryTest.Enumerable
{
    public static class TestExtensions
    {
        internal static void AreSequenceEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
        {
            Assert.IsTrue(actual.SequenceEqual(expected));
        }
    }
}