using NUnit.Framework;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibraryTest.Enumerable
{
    [TestFixture]
    public class FindTest
    {
        [Test]
        public void Find_Item_In_Collection()
        {
            var items = new[] {1, 2, 34, 5};

            var searchedValue = 2;

            var find = items.Find(x => x == searchedValue);

            Assert.AreEqual(searchedValue, find);
        }
    }
}
