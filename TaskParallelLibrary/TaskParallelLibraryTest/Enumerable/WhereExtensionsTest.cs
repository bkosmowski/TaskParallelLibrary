using System;
using System.Collections.Generic;
using NUnit.Framework;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibraryTest.Enumerable
{
    [TestFixture]
    public class WhereExtensionsTest
    {
        [Test]
        public void SimpleFiltering()
        {
            var source = new[] {1, 2, 3, 5, 8, 1, 4};
            var result = source.Where(x => x < 4);
            result.AreSequenceEqual(new[] {1, 2, 3, 1});
        }

        [Test]
        public void NullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(x => x > 5));
        }

        [Test]
        public void NullPredicateThrowsNullArgumentException()
        {
            var source = new[] {1, 3, 7, 9, 10};
            Func<int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        [Test]
        public void ExecutionIsDeferred()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Where(x => x > 0));
        }

        [Test]
        public void FilterEmptySource()
        {
            var source = new int[0];
            var result = source.Where(x => x < 4);
            result.AreSequenceEqual(new int [0]);
        }
    }
}