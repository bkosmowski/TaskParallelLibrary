using System;
using NUnit.Framework;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibraryTest.Enumerable
{
    [TestFixture]
    public class ZipTest
    {
        [Test]
        public void Zip_Two_Collections()
        {
            var items = new[] {"1", "2", "3", "4"};

            var result = items.Zip(System.Linq.Enumerable.Skip(items, 1), (x, y) => x + y);
            var expectedValue = new[] {"12", "23", "34"};
            result.AssertSequenceEqual(expectedValue);
        }

        [Test]
        public void Zip_Should_Throw_ArgumentNullException_For_Null_Selector()
        {
            var items = new[] { "1", "2", "3", "4" };
            //TODO: Add checking null arguments and add tests for them
            Assert.Throws<ArgumentNullException>(() => items.Zip(items, null));
        }
    }
}
