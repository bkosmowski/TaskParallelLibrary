using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    class Program
    {
        private volatile bool _flag = true;
        static void Main(string[] args)
        {
            //var awaiter = Task.Run(() => { Console.WriteLine("A message from thread pool"); }).GetAwaiter();

            //awaiter.OnCompleted(() =>
            //{
            //    Console.WriteLine("Action is completed");
            //});

            //await Task.Run(() => { Console.WriteLine("A message from thread pool"); });

            //Console.WriteLine("A action is completed");


            //await Task.Run(() => { Console.WriteLine("A message from thread pool"); }).ConfigureAwait(false);
            //await Task.Run(() => { Console.WriteLine("A message from thread pool"); }).ConfigureAwait(true);

            //Console.WriteLine("A action is completed");

            //Console.ReadKey();

            //new List<int>().Find()

            var program = new Program();

            var thread = new Thread(() => program._flag = false);
            thread.Start();

            while (program._flag) //with volatile refresh cache
            {

            }

            if (program._flag)
            {
                return;
            }

            //lock (obs)
            //{
            //    program._flag = true;
            //}

            var enumerable = System.Linq.Enumerable.Range(0, 100).Take(20);

            foreach (var item in enumerable)
            {

            }
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
