using System;
using System.Collections.Generic;
using NUnit.Framework;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibraryTest.Enumerable
{
    [TestFixture]
    public class WhereTest
    {
        [Test]
        public void Simple_Filtering()
        {
            var source = new[] {1, 2, 3, 5, 8, 1, 4};
            var result = source.Where(x => x < 4);
            result.AreSequenceEqual(new[] {1, 2, 3, 1});
        }
        
        [Test]
        public void Simple_Filtering_With_Index()
        {
            var source = new[] {1, 2, 3, 5, 8, 1, 4};
            var result = source.Where((x, index) => x < 4);
            result.AreSequenceEqual(new[] {1, 2, 3, 1});
        }

        [Test]
        public void Null_Source_Throws_Null_Argument_Exception()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(x => x > 5));
        }

        [Test]
        public void Null_Source_Throws_Null_Argument_Exception_With_Index()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where((x, index) => x > 5));
        }

        [Test]
        public void Null_Predicate_Throws_Null_Argument_Exception()
        {
            var source = new[] {1, 3, 7, 9, 10};
            Func<int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        [Test]
        public void Null_Predicate_Throws_Null_Argument_Exception_With_Index()
        {
            var source = new[] {1, 3, 7, 9, 10};
            Func<int,int , bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        [Test]
        public void Execution_Is_Deferred()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Where(x => x > 0));
        }

        [Test]
        public void Execution_Is_Deferred_With_Index()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Where((x, index) => x > 0));
        }

        [Test]
        public void Filter_Empty_Source()
        {
            var source = new int[0];
            var result = source.Where(x => x < 4);
            result.AreSequenceEqual(new int [0]);
        }
        [Test]
        public void Filter_Empty_Source_With_Index()
        {
            var source = new int[0];
            var result = source.Where((x, index) => x < 4);
            result.AreSequenceEqual(new int [0]);
        }
    }
}