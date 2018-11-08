using System;
using TaskParallelLibrary.Disposable;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventGenerator = new EventGenerator();

            using (var disposable = new Disposable.Disposable(eventGenerator))
            {
                for (var index = 0; index < 10; index++)
                {
                    eventGenerator.BroadcastEvent();
                }
            }

            for (var index = 0; index < 10; index++)
            {
                eventGenerator.BroadcastEvent();
            }

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
