using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace TaskParallelLibrary
{
    public class ProducerConsumer
    {
        public static void UseLock()
        {

        }

        private static void BennchmarkWithQueue(Func<object, Queue<int>, Random, Thread> producer, Func<object, Queue<int>, Thread> consumer)
        {
            var locker = new object();
            var queue = new Queue<int>();
            var random = new Random(100);

            var producerThread = producer(locker, queue, random);
            var consumerThread = consumer(locker, queue);

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            producerThread.Start();
            consumerThread.Start();

            producerThread.Join();
            consumerThread.Join();

            stopwatch.Stop();

            Console.WriteLine($"Usage of lock took {stopwatch.ElapsedMilliseconds} ms");

            Console.WriteLine($"{queue.Count} items left in queue");
        }

        private static Thread LockProducer(object locker, Queue<int> queue, Random random)
        {
            return new Thread(() =>
            {
                for (var index = 0; index < 10000; index++)
                {
                    lock (locker)
                    {
                        queue.Enqueue(random.Next(100));
                    }
                }

                Console.WriteLine("Consumer job is done");
            });
        }

        private static Thread LockConsumer(object locker, Queue<int> queue)
        {
            return new Thread(() =>
            {
                for (var index = 0; index < 10000; index++)
                {
                    lock (locker)
                    {
                        queue.TryDequeue(out var item);
                    }
                }

                Console.WriteLine("Consumer job is done");
            });
        }

        private static Thread SpinLockProducer(SpinLock spinLock, Queue<int> queue, Random random)
        {
            return new Thread(()=>{
                for (var index = 0; index < 10000; index++)
                {
                    bool lockTaken = false;

                    try
                        {
                            spinLock.Enter(ref lockTaken);
                            queue.Enqueue(random.Next(100));
                        }
                        catch (AggregateException ae)
                        {
                            Console.WriteLine($"Error message {ae}");
                        }
                        finally
                        {
                            if (lockTaken)
                            {
                                spinLock.Exit();
                            }
                        }
                        queue.TryDequeue(out var item);
                }

                Console.WriteLine("Consumer job is done");
            });
        }
    }
}