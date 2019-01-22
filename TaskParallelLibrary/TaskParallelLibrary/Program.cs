﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskParallelLibrary.Immutable;

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

            //var program = new Program();

            //var thread = new Thread(() => program._flag = false);
            //thread.Start();

            //while (program._flag) //with volatile refresh cache
            //{

            //}

            //if (program._flag)
            //{
            //    return;
            //}

            ////lock (obs)
            ////{
            ////    program._flag = true;
            ////}

            //var enumerable = System.Linq.Enumerable.Range(0, 100).Take(20);

            //foreach (var item in enumerable)
            //{

            //}

            //var sb = new StringBuilder();
            //sb.Append()

            TestUserWithDevices();

            Console.ReadKey();
        }

        private static void TestUserWithDevices()
        {
            var threads = new List<Thread>();
            var user = new User("Jacek", new ImmutableDevice("Nokia", 30),
                new MutableDevice {Name = "Samsung", Price = 50});


            for (var index = 0; index < 10; index++)
            {
                threads.Add(new Thread(() =>
                {
                    Console.WriteLine($"Immutable device before changed: {user.ImmutableDevice}");
                    Console.WriteLine($"Mutable device before changed: {user.MutableDevice}");
                    user.ChangeImmutableDevice();
                    user.ChangeMutableDevice();
                }));
            }

            threads.ForEach(t => t.Start());
        }

        private static Task ExceptionMethod()
        {
            throw new NullReferenceException();
        }

        class A
        {

        }

        class B : A
        {

        }

        private static string FormatTitle(string title)
        {
            var splitResult = title.Split(' ');
            var chapter = string.Join(" ", splitResult.Take(splitResult.Length - 1));
            return $"{chapter} -s. {splitResult.Last()}";
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
