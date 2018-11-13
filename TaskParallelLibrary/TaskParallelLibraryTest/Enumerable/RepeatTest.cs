using System;
using NUnit.Framework;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibraryTest.Enumerable
{
    [TestFixture]
    public class RepeatTest
    {
        [Test]
        public void Repeat_Item()
        {
            var item = "Item to test";
            var count = 3;
            var result = EnumerableImpl.Repeat(item, count);
            var expectedResult = new[] {item, item, item};
            result.AssertSequenceEqual(expectedResult);
        }

        [Test]
        public void Create_Empty_Sequence()
        {
            var item = "Item to test";
            var result = EnumerableImpl.Repeat(item, 0);
            var expectedResult = new string[0];
            result.AssertSequenceEqual(expectedResult);
        }

        [Test]
        public void Create_Sequence_With_Null()
        {
            string item = null;
            var count = 4;
            var result = EnumerableImpl.Repeat(item, count);
            var expectedResult = new string[] {null, null, null, null};
            result.AssertSequenceEqual(expectedResult);
        }

        [Test]
        public void Usage_Negative_Count_Should_Throw_Exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EnumerableImpl.Repeat("Item to test", -1));
        }
    }
}
