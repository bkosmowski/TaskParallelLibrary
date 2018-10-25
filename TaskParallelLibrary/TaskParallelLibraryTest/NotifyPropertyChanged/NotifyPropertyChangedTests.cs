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
        public void OnPropertyChanged_Should__Not_Invoke_PropertyCHanged_Event()
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
    }
}