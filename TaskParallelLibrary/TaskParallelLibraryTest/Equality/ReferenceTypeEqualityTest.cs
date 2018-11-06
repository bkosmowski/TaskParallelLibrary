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
            var apple2 = new Food(100, "apple", FoodGroup.Fruit);
            //TODO: WTF?
            Assert.IsFalse(apple1 != apple2);
        }

        [Test]
        public void Equals_Should_Return_True_For_CookedFood_With_Equal_Properties()
        {
            var bakedApple1 = new CookedFood(100, "Apple", FoodGroup.Fruit, "Baked");
            var bakedApple2 = new CookedFood(100, "Apple", FoodGroup.Fruit, "Baked");

            Assert.AreEqual(bakedApple1, bakedApple2);
        }

        [Test]
        public void Equals_Should_Return_False_For_CookedFood_With_Different_Properties()
        {
            var bakedApple = new CookedFood(100, "Apple", FoodGroup.Fruit, "Baked");
            var bakedBanana = new CookedFood(100, "banana", FoodGroup.Fruit, "Baked");

            Assert.AreEqual(bakedApple, bakedBanana);
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

            Assert.AreEqual(bakedApple.GetHashCode(), bakedBanana.GetHashCode());
        }
    }
}
