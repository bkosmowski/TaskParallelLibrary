using System;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            (int value1, string value2) temp = (10, "test");

            temp.value1 = 10;
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
