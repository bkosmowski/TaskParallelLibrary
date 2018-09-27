using System;
using System.Threading;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Signalization.PrepareTeaWithBarrier();
            Console.ReadKey();
        }
    }
}
