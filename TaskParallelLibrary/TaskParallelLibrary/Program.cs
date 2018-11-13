using System;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
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
