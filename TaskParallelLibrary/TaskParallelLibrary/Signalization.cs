using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    public class Signalization
    {
        //konsument producent przykład
        public static void SyncWithSemaphore()
        {
            var semaphoreSlim = new SemaphoreSlim(0, 10);

            for(var index = 0; index < 20; ++index)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Entering task {Task.CurrentId}.");
                    semaphoreSlim.Wait(); // ReleaseCount--
                    Console.WriteLine($"Processing task {Task.CurrentId}.");
                });
            }

            while (semaphoreSlim.CurrentCount <= 2)
            {
                Console.WriteLine($"Semaphore count: {semaphoreSlim.CurrentCount}");
                Console.ReadKey();
                semaphoreSlim.Release(2); // ReleaseCount += n
            }
        }

        public static void AutomaticPreparingTea()
        {
            var autoResetEvent = new AutoResetEvent(false);

            var cancellationTokenSource = new CancellationTokenSource();

            var water = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Boiling water...");

                for (int index = 0; index < 30; index++)
                {
                    cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    Thread.Sleep(100);
                }

                Console.WriteLine("Water is ready");
                autoResetEvent.Set();
            }, cancellationTokenSource.Token);

            var tea = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Waiting for water...");

                autoResetEvent.WaitOne(5000);

                Console.WriteLine($"Tea is done!");

            }, cancellationTokenSource.Token);
        }

        public static void ManualPreparingTea()
        {
            var manualResetEventSlim = new ManualResetEventSlim();
            var cancellationTokenSource = new CancellationTokenSource();

            var water = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Boiling water...");

                for (int index = 0; index < 30; index++)
                {
                    cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    Thread.Sleep(100);
                }

                Console.WriteLine("Water is ready");
                manualResetEventSlim.Set();
            }, cancellationTokenSource.Token);

            var tea = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Waiting for water...");
                manualResetEventSlim.Wait(5000, cancellationTokenSource.Token);
                Console.WriteLine($"Tea is done! And ManualResetEvent IsSet = {manualResetEventSlim.IsSet}");

            }, cancellationTokenSource.Token);
        }


        public static void RandomSleepingCountdown()
        {
            var taskNumber = 5;
            var countdownEvent = new CountdownEvent(taskNumber);
            var random = new Random();

            var tasks = new Task[taskNumber];
            for (var index = 0; index < taskNumber; index++)
            {
                tasks[index] = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(random.Next(1000, 3000));

                    Console.WriteLine($"Current countdown value is {countdownEvent.CurrentCount}");
                    //Drukowac numer tasku i watku
                    countdownEvent.Signal();
                });
            }

            var finalTask = Task.Factory.StartNew(() =>
            {
                countdownEvent.Wait();
                Console.WriteLine("All tasks completed");
            });

            finalTask.Wait();
        }

        public static void PrepareTeaWithBarrier()
        {
            var barrier = new Barrier(2, b =>
            {
                Console.WriteLine($"Phase {b.CurrentPhaseNumber} finished");
                Console.WriteLine($"Barrier has {b.ParticipantCount} participants");
            });

            var water = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Putting the kettle on");
                Thread.Sleep(TimeSpan.FromSeconds(2));
                barrier.SignalAndWait();

                Console.WriteLine("Boiling water");
                Thread.Sleep(TimeSpan.FromSeconds(3));
                barrier.SignalAndWait();

                Console.WriteLine("Putting the kettle away");
            });

            var cup = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Taking the nicest tea cup");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                barrier.SignalAndWait();

                Console.WriteLine("Adding tea");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                barrier.SignalAndWait();

                Console.WriteLine("Adding sugar");
            });

            var tea = Task.Factory.ContinueWhenAll(new[] { water, cup }, tasks =>
            {
                Console.WriteLine($"Enjoy your cup of tea.");

                foreach (var task in tasks)
                {
                    Console.WriteLine($"Task with id {task.Id} has status {task.Status}");
                }
            });

            tea.Wait();
        }
    }
}
