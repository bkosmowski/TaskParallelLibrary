using System.Linq;
using NUnit.Framework;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibraryTest.Enumerable
{
    [TestFixture]
    public class EmptyTest
    {
        [Test]
        public void Sequence_Is_Empty()
        {
            Assert.IsFalse(EnumerableImpl.Empty<int>().GetEnumerator().MoveNext());
        }

        [Test]
        public void Sequences_Are_The_Same_Instance_If_They_Have_The_Same_Type()
        {
            Assert.AreSame(EnumerableImpl.Empty<int>(), EnumerableImpl.Empty<int>());
            Assert.AreSame(EnumerableImpl.Empty<double>(), EnumerableImpl.Empty<double>());
            Assert.AreSame(EnumerableImpl.Empty<int>(), EnumerableImpl.Empty<int>());
            Assert.AreSame(EnumerableImpl.Empty<object>(), EnumerableImpl.Empty<object>());
            Assert.AreSame(EnumerableImpl.Empty<int>(), EnumerableImpl.Empty<int>());
            Assert.AreSame(EnumerableImpl.Empty<long>(), EnumerableImpl.Empty<long>());

            Assert.AreNotSame(EnumerableImpl.Empty<int>(), EnumerableImpl.Empty<long>());
            Assert.AreNotSame(EnumerableImpl.Empty<double>(), EnumerableImpl.Empty<long>());
            Assert.AreNotSame(EnumerableImpl.Empty<object>(), EnumerableImpl.Empty<long>());
        }
    }
}
