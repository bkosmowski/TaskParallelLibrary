using System;
using System.Threading;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            new Waiting().WaitForAny();
            Console.ReadKey();
        }
    }
}
