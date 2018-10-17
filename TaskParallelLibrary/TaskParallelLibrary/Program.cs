using System;
using System.Threading;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            new DataSharing().UseVolatileWithTasks();

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
