using System;
using System.Threading;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Signalization.SyncWithSemaphore();
            Console.ReadKey();
        }
    }
}
