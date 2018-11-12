using System;
using System.Collections.Generic;
using NUnit.Framework;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibraryTest.Enumerable
{
    [TestFixture]
    public class SelectTest
    {
        [Test]
        public void Simple_Selecting()
        {
            var source = new[] {1, 2, 3};
            var result = source.Select(x => x.ToString());
            result.AssertSequenceEqual(new []{"1", "2", "3"});
        }

        [Test]
        public void Side_Effects_In_Selection()
        {
            var source = new int[3];
            var count = 0;
            var query = source.Select(x => count++);
            query.AssertSequenceEqual(new [] {0, 1, 2});
            query.AssertSequenceEqual(new [] {3, 4, 5});
            count = 10;
            query.AssertSequenceEqual(new[] {10, 11, 12});
        }

        [Test]
        public void Simple_Where_And_Select()
        {
            var source = new[] {1, 2, 3, 4, 5, 6};
            var result = source.Where(x => x < 4).Select(x => x * 2);
            result.AssertSequenceEqual(new[] {2, 4, 6});
        }

        [Test]
        public void Null_Source_Throws_NullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Select(x => x));    
        }

        [Test]
        public void Null_Selector_Throws_NullArgumentException()
        {
            var source = new []{1, 2, 3};
            Func<int, int> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Select(selector));
        }
    }
}