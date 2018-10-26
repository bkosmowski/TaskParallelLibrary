using NUnit.Framework;
using TaskParallelLibrary.NotifyPropertyChanged;

namespace TaskParallelLibraryTest.NotifyPropertyChanged
{
    [TestFixture]
    public class NotifyPropertyChangedTests
    {
        [Test]
        public void OnPropertyChanged_Should_Invoke_PropertyChanged_Event()
        {
            var personData = new PersonData();

            var propertyChangedEventWasCalled = false;

            personData.PropertyChanged += (sender, args) => { propertyChangedEventWasCalled = true; };

            personData.Age = 20;

            Assert.IsTrue(propertyChangedEventWasCalled);
        }

        [Test]
        public void OnPropertyChanged_Should_Not_Invoke_PropertyChanged_Event_When_Property_Is_The_Same()
        {
            var age = 20;
            var personData = new PersonData
            {
                Age = age
            };

            var propertyChangedEventWasCalled = false;

            personData.PropertyChanged += (sender, args) => { propertyChangedEventWasCalled = true; };

            personData.Age = age;

            Assert.IsFalse(propertyChangedEventWasCalled);
        }

        [Test]
        public void OnPropertyChanged_Should_Invoke_Action()
        {
            var actionWasInvoked = false;

            var personData = new PersonData(20, () => { actionWasInvoked = true; });

            personData.WithAction = 30;

            Assert.IsTrue(actionWasInvoked);
        }

        [Test]
        public void OnPropertyChanged_Should_Not_Invoke_Action_When_Property_Is_The_Same()
        {
            var value = 20;

            var actionWasInvoked = false;

            var personData = new PersonData(20, () => { actionWasInvoked = true; });

            personData.WithAction = value;

            Assert.IsFalse(actionWasInvoked);
        }

        [Test]
        public void OnPropertyChanged_should_Invoke_PropertyChanged_Event_With_Property_Name()
        {
            var personData = new PersonData();

            var changedPropertyName = string.Empty;
            personData.PropertyChanged += (sender, args) => { changedPropertyName = args.PropertyName; };

            personData.Age = 30;
            
            Assert.AreEqual(changedPropertyName, nameof(personData.Age));
        }
    }
}