using System;
using System.Collections.Generic;
using NUnit.Framework;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibraryTest.Enumerable
{
    [TestFixture]
    public class RangeTest
    {
        [Test]
        public void Simple_Range()
        {
            var range = EnumerableImpl.Range(1, 3);
            range.AssertSequenceEqual(new[] {1, 2, 3});
        }

        [Test]
        public void Range_With_Negative_Start_Value()
        {
            var range = EnumerableImpl.Range(-5, 5);
            range.AssertSequenceEqual(new[] {-5, -4, -3, -2, -1});
        }

        [Test]
        public void Range_With_Count_Zero_Should_Be_Empty()
        {
            var range = EnumerableImpl.Range(int.MinValue, 0);
            range.AssertSequenceEqual(new int[0]);
        }

        [Test]
        public void Range_With_Count_One_Should_Return_One_Item()
        {
            var range = EnumerableImpl.Range(int.MaxValue, 1);
            range.AssertSequenceEqual(new[] {int.MaxValue});
        }

        [Test]
        public void Range_With_Count_Less_Than_Zero_Should_Throw_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EnumerableImpl.Range(10, -1));
        }

        [Test]
        public void Range_With_Values_Out_Of_Range_Should_Throw_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EnumerableImpl.Range(int.MaxValue, 2));
        }
    }
}