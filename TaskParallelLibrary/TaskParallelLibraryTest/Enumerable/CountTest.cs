using System;
using System.Collections.Generic;
using NUnit.Framework;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibraryTest.Enumerable
{
    [TestFixture]
    public class CountTest
    {
        [Test]
        public void Count_Enumerable()
        {
            Assert.AreEqual(10, EnumerableImpl.Repeat(1, 10).Count());
        }

        [Test]
        public void Count_GenericCollection()
        {
            Assert.AreEqual(10, new GenericCollection<int>(EnumerableImpl.Repeat(1, 10)).Count());
        }

        [Test]
        public void Count_SemiGenericCollection()
        {
            Assert.AreEqual(10, new SemiGenericCollection<int>(EnumerableImpl.Repeat(1, 10)).Count());
        }

        [Test]
        public void Count_List()
        {
            Assert.AreEqual(10, new List<int>(EnumerableImpl.Repeat(1, 10)).Count());
        }

        [Test]
        public void Null_Source_Should_Throw_ArgumentNullException_In_Count()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Count());
        }

        [Test]
        public void Null_Predicate_Should_Throw_ArgumentNullException_In_Count()
        {
            Assert.Throws<ArgumentNullException>(() => EnumerableImpl.Repeat(1, 1).Count(null));
        }
        
        [Test]
        public void Null_Source_Should_Throw_ArgumentNullException_In_LongCount()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.LongCount());
        }

        [Test]
        public void Null_Predicate_Should_Throw_ArgumentNullException_In_LongCount()
        {
            Assert.Throws<ArgumentNullException>(() => EnumerableImpl.Repeat(1, 1).LongCount(null));
        }
    }
}