using NUnit.Framework;
using TaskParallelLibrary.Equality;
using System.Collections.Generic;

namespace TaskParallelLibraryTest.Equality
{
    [TestFixture]
    public class ValueTypeEqualityTest
    {
        [Test]
        public void Equals_Should_Return_True_For_FoodItems_With_Equal_Properties()
        {
            var apple1 = new FoodItem(100, "apple", FoodGroup.Fruit);
            var apple2 = new FoodItem(100, "apple", FoodGroup.Fruit);

            Assert.IsTrue(apple1.Equals(apple2));
        }

        [Test]
        public void Equals_Should_Return_False_For_FoodItems_With_Different_Properties()
        {
            var apple = new FoodItem(100, "apple", FoodGroup.Fruit);
            var banana = new FoodItem(200, "banana", FoodGroup.Fruit);

            Assert.IsFalse(apple.Equals(banana));
        }
        
        [Test]
        public void GetHashCode_Should_Return_The_Same_Hashes_For_FoodItems_With_Equal_Properties()
        {
            var apple1 = new FoodItem(100, "apple", FoodGroup.Fruit);
            var apple2 = new FoodItem(100, "apple", FoodGroup.Fruit);

            Assert.AreEqual(apple1.GetHashCode(), apple2.GetHashCode());
        }

        [Test]
        public void GetHashCode_Should_Return_Different_Hashes_For_FoodItems_With_Different_Properties()
        {
            var apple = new FoodItem(100, "apple", FoodGroup.Fruit);
            var banana = new FoodItem(200, "banana", FoodGroup.Fruit);

            Assert.AreNotEqual(apple.GetHashCode(), banana.GetHashCode());
        }

        [Test]
        public void Equals_Should_Return_True_If_GetHashCode_Returns_The_Same_Hashes()
        {
            var apple1 = new FoodItem(100, "apple", FoodGroup.Fruit);
            var apple2 = new FoodItem(100, "apple", FoodGroup.Fruit);

            Assert.IsTrue(apple1.Equals(apple2));
            Assert.AreEqual(apple1.GetHashCode(), apple2.GetHashCode());
        }
        
        [Test]
        public void Equals_Should_Return_False_If_GetHashCode_Returns_Different_Hashes()
        {
            var apple = new FoodItem(100, "apple", FoodGroup.Fruit);
            var banana = new FoodItem(200, "banana", FoodGroup.Fruit);

            Assert.IsFalse(apple.Equals(banana));
            Assert.AreNotEqual(apple.GetHashCode(), banana.GetHashCode());
        }

        [Test]
        public void HashSet_Should_Have_Only_One_FoodItem_Despite_Inserting_Two_With_The_Same_Properties()
        {
            var hashSet = new HashSet<FoodItem>
            {
                new FoodItem(100, "apple", FoodGroup.Fruit), new FoodItem(100, "apple", FoodGroup.Fruit)
            };

            Assert.AreEqual(hashSet.Count, 1);
        }

        [Test]
        public void HasSet_Should_Have_Two_FoodItem_When_They_Have_Different_Properties()
        {
            var hashSet = new HashSet<FoodItem>
            {
                new FoodItem(100, "apple", FoodGroup.Fruit), new FoodItem(100, "banana", FoodGroup.Fruit)
            };

            Assert.AreEqual(hashSet.Count, 2);
        }

        [Test]
        public void Equality_Operator_Should_Return_True_For_FoodItems_With_Equal_Properties()
        {
            var apple1 = new FoodItem(100, "apple", FoodGroup.Fruit);
            var apple2 = new FoodItem(100, "apple", FoodGroup.Fruit);

            Assert.IsTrue(apple1 == apple2);
        }
        
        [Test]
        public void Equality_Operator_Should_Return_False_For_FoodItems_With_Different_Properties()
        {
            var apple1 = new FoodItem(100, "apple", FoodGroup.Fruit);
            var apple2 = new FoodItem(1000, "apple", FoodGroup.Fruit);
            
            Assert.IsFalse(apple1 == apple2);
        }

        [Test]
        public void Inequality_Operator_Should_Return_True_For_FoodItems_With_Different_Properties()
        {
            var apple = new FoodItem(100, "apple", FoodGroup.Fruit);
            var banana = new FoodItem(200, "banana", FoodGroup.Fruit);
            
            Assert.IsTrue(apple != banana);
        }

        [Test]
        public void Inequality_Operator_Should_Return_False_For_FoodItems_With_Equal_Properties()
        {
            var apple1 = new FoodItem(100, "apple", FoodGroup.Fruit);
            var apple2 = new FoodItem(100, "apple", FoodGroup.Fruit);

            Assert.IsFalse(apple1 != apple2);
        }
    }
}