using System;
using System.Linq;
using TaskParallelLibrary.Disposable;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var animalGroup = new AnimalGroup(new Animal("Wafel", 10), new Animal("Sami", 1), new Animal("Jed", 1));

            foreach (var animal in animalGroup)
            {
                Console.WriteLine(animal);
            }

            animalGroup.ToList();
            
            Console.ReadKey();
        }

        private static void TestInCases(Action<int> action)
        {
            var arrayOfCases = new[] {1, 10, 100};

            foreach (var caseFromArray in arrayOfCases)
            {
                action(caseFromArray);
            }
        }
    }
}
