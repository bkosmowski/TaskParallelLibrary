using System;
using System.Threading;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            StartingTasks.CreateAndStartTask();

            Thread.Sleep(3000);

            StartingTasks.CreateTaskWithArg("Test text");

            Thread.Sleep(3000);

            StartingTasks.CalculateTextLengthInTask("Text with length equals to 29");

            Console.ReadKey();
        }
    }
}
