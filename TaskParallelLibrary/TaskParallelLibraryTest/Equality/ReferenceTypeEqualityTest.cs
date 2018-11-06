using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TaskParallelLibrary.Equality;

namespace TaskParallelLibraryTest.Equality
{
    [TestFixture]
    public class ReferenceTypeEqualityTest
    {
        [Test]
        public void Equals_Should_Return_True_For_Food_With_Equal_Properties()
        {
            var apple1 = new Food(100, "apple", FoodGroup.Fruit);
            var apple2 = new Food(100, "apple", FoodGroup.Fruit);

            Assert.IsTrue(apple1.Equals(apple2));
        }

        [Test]
        public void Equals_Should_Return_False_For_Food_With_Different_Properties()
        {
            var apple = new Food(100, "apple", FoodGroup.Fruit);
            var banana = new Food(200, "banana", FoodGroup.Fruit);

            Assert.IsFalse(apple.Equals(banana));
        }

        [Test]
        public void GetHashCode_Should_Return_The_Same_Hashes_For_Food_With_Equal_Properties()
        {
            var apple1 = new Food(100, "apple", FoodGroup.Fruit);
            var apple2 = new Food(100, "apple", FoodGroup.Fruit);

            Assert.AreEqual(apple1.GetHashCode(), apple2.GetHashCode());
        }

        [Test]
        public void GetHashCode_Should_Return_Different_Hashes_For_Food_With_Different_Properties()
        {
            var apple = new Food(100, "apple", FoodGroup.Fruit);
            var banana = new Food(200, "banana", FoodGroup.Fruit);

            Assert.AreNotEqual(apple.GetHashCode(), banana.GetHashCode());
        }

        [Test]
        public void Equals_Should_Return_True_If_GetHashCode_Returns_The_Same_Hashes()
        {
            var apple1 = new Food(100, "apple", FoodGroup.Fruit);
            var apple2 = new Food(100, "apple", FoodGroup.Fruit);

            Assert.IsTrue(apple1.Equals(apple2));
            Assert.AreEqual(apple1.GetHashCode(), apple2.GetHashCode());
        }

        [Test]
        public void Equals_Should_Return_False_If_GetHashCode_Returns_Different_Hashes()
        {
            var apple = new Food(100, "apple", FoodGroup.Fruit);
            var banana = new Food(200, "banana", FoodGroup.Fruit);

            Assert.IsFalse(apple.Equals(banana));
            Assert.AreNotEqual(apple.GetHashCode(), banana.GetHashCode());
        }

        [Test]
        public void HashSet_Should_Have_Only_One_Food_Despite_Inserting_Two_With_The_Same_HashCode()
        {
            var apple1 = new Food(100, "apple", FoodGroup.Fruit);
            var apple2 = new Food(100, "apple", FoodGroup.Fruit);

            var hashSet = new HashSet<Food>
            {
                apple1, apple2
            };

            Assert.AreEqual(apple1.GetHashCode(), apple2.GetHashCode());
            Assert.AreEqual(hashSet.Count, 1);
        }
        
        [Test]
        public void HasSet_Should_Have_Two_Food_When_They_Have_Different_HashCodes()
        {
            var foodItem1 = new Food(100, "apple", FoodGroup.Fruit);
            var foodItem2 = new Food(100, "banana", FoodGroup.Fruit);
            
            var hashSet = new HashSet<Food>
            {
                foodItem1, foodItem2
            };

            Assert.AreNotEqual(foodItem1.GetHashCode(), foodItem2.GetHashCode());
            Assert.AreEqual(hashSet.Count, 2);
        }

        [Test]
        public void Equality_Operator_Should_Return_True_For_Food_With_Equal_Properties()
        {
            var apple1 = new Food(100, "apple", FoodGroup.Fruit);
            var apple2 = new Food(100, "apple", FoodGroup.Fruit);

            Assert.IsTrue(apple1 == apple2);
        }

        [Test]
        public void Equality_Operator_Should_Return_False_For_Food_With_Different_Properties()
        {
            var apple1 = new Food(100, "apple", FoodGroup.Fruit);
            var apple2 = new Food(1000, "apple", FoodGroup.Fruit);
            Assert.IsFalse(apple1 == apple2);
        }
        
        [Test]
        public void Inequality_Operator_Should_Return_True_For_Food_With_Different_Properties()
        {
            var apple = new Food(100, "apple", FoodGroup.Fruit);
            var banana = new Food(200, "banana", FoodGroup.Fruit);
            
            Assert.IsTrue(apple != banana);
        }

        [Test]
        public void Inequality_Operator_Should_Return_False_For_Food_With_Equal_Properties()
        {
            var apple1 = new Food(100, "apple", FoodGroup.Fruit);
            var apple2 = new Food(100, "apple", FoodGroup.Fruit);

            Assert.IsFalse(apple1 != apple2);
        }

        [Test]
        public void Equals_Should_Return_True_For_CookedFood_With_Equal_Properties()
        {
            var bakedApple1 = new CookedFood(100, "Apple", FoodGroup.Fruit, "Baked");
            var bakedApple2 = new CookedFood(100, "Apple", FoodGroup.Fruit, "Baked");

            Assert.IsTrue(bakedApple1.Equals(bakedApple2));
        }

        [Test]
        public void Equals_Should_Return_False_For_CookedFood_With_Different_Properties()
        {
            var bakedApple = new CookedFood(100, "Apple", FoodGroup.Fruit, "Baked");
            var bakedBanana = new CookedFood(100, "banana", FoodGroup.Fruit, "Baked");

            Assert.IsFalse(bakedApple.Equals(bakedBanana));
        }

        [Test]
        public void GetHashCode_Should_Return_The_Same_Hashes_For_CookedFood_With_Equal_Properties()
        {
            var bakedApple1 = new CookedFood(100, "apple", FoodGroup.Fruit, "Baked");
            var bakedApple2 = new CookedFood(100, "apple", FoodGroup.Fruit, "Baked");

            Assert.AreEqual(bakedApple1.GetHashCode(), bakedApple2.GetHashCode());
        }

        [Test]
        public void GetHashCode_Should_Return_The_Same_Hashes_For_CookedFood_With_Different_Properties()
        {
            var bakedApple = new CookedFood(100, "apple", FoodGroup.Fruit, "Baked");
            var bakedBanana = new CookedFood(100, "banana", FoodGroup.Fruit, "Baked");

            Assert.AreNotEqual(bakedApple.GetHashCode(), bakedBanana.GetHashCode());
        }
        
        [Test]
        public void HashSet_Should_Have_Only_One_CookedFood_Despite_Inserting_Two_With_The_Same_HashCode()
        {
            var apple1 = new CookedFood(100, "apple", FoodGroup.Fruit, "Baked");
            var apple2 = new CookedFood(100, "apple", FoodGroup.Fruit, "Baked");

            var hashSet = new HashSet<CookedFood>
            {
                apple1, apple2
            };

            Assert.AreEqual(apple1.GetHashCode(), apple2.GetHashCode());
            Assert.AreEqual(hashSet.Count, 1);
        }
        
        [Test]
        public void HasSet_Should_Have_Two_CookedFood_When_They_Have_Different_HashCodes()
        {
            var foodItem1 = new CookedFood(100, "apple", FoodGroup.Fruit, "Baked");
            var foodItem2 = new CookedFood(100, "banana", FoodGroup.Fruit, "Baked");
            
            var hashSet = new HashSet<CookedFood>
            {
                foodItem1, foodItem2
            };

            Assert.AreNotEqual(foodItem1.GetHashCode(), foodItem2.GetHashCode());
            Assert.AreEqual(hashSet.Count, 2);
        }
        
        [Test]
        public void Equality_Operator_Should_Return_True_For_CookedFood_With_Equal_Properties()
        {
            var apple1 = new CookedFood(100, "apple", FoodGroup.Fruit, "Baked");
            var apple2 = new CookedFood(100, "apple", FoodGroup.Fruit, "Baked");

            Assert.IsTrue(apple1 == apple2);
        }

        [Test]
        public void Equality_Operator_Should_Return_False_For_CookedFood_With_Different_Properties()
        {
            var apple1 = new CookedFood(100, "apple", FoodGroup.Fruit, "Baked");
            var apple2 = new CookedFood(1000, "apple", FoodGroup.Fruit, "Baked");
            Assert.IsFalse(apple1 == apple2);
        }
        
        [Test]
        public void Inequality_Operator_Should_Return_True_For_CookedFood_With_Different_Properties()
        {
            var apple = new CookedFood(100, "apple", FoodGroup.Fruit, "Baked");
            var banana = new CookedFood(200, "banana", FoodGroup.Fruit, "Baked");
            
            Assert.IsTrue(apple != banana);
        }

        [Test]
        public void Inequality_Operator_Should_Return_False_For_CookedFood_With_Equal_Properties()
        {
            var apple1 = new CookedFood(100, "apple", FoodGroup.Fruit, "Baked");
            var apple2 = new CookedFood(100, "apple", FoodGroup.Fruit, "Baked");

            Assert.IsFalse(apple1 != apple2);
        }
    }
}
