using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    public class TaskCancellation
    {
        public static void DisarmTheBomb()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var task = new Task(() =>
            {
                Console.WriteLine("You have 5 second to disarm the bomb. Press any key...");

                var canceled = cancellationTokenSource.Token.WaitHandle.WaitOne(TimeSpan.FromSeconds(5));

                Console.WriteLine(canceled ? "Bomb disarmed" : "Bomb exploded! BOOM!");
            }, cancellationTokenSource.Token);

            task.Start();

            Console.ReadKey();

            cancellationTokenSource.Cancel();
        }

        public static void UseCompositeCancellationToken()
        {
            var planned = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();
            var countdownEnded = false;
            planned.Token.Register(() => countdownEnded = true);

            var composed = CancellationTokenSource.CreateLinkedTokenSource(planned.Token, emergency.Token);

            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Press any key to use emergency cancellation.");
                Console.WriteLine("Loop will be canceled automatically in ");

                var index = 5;
                while (index >= 0)
                {
                    composed.Token.ThrowIfCancellationRequested();
                    Console.WriteLine(index);
                    Task.Delay(TimeSpan.FromSeconds(1));
                    index--;
                }

                Console.WriteLine("Time is up! Planned cancellation");
                planned.Cancel();
            }, composed.Token);

            Console.ReadKey();

            emergency.Token.Register(() => Console.WriteLine("Emergency cancellation!"));

            if (countdownEnded == false)
            {
                emergency.Cancel();
            }
        }

        public static void SoftCancellation()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() => Console.WriteLine("Soft cancellation requested!"));

            var task = Task.Factory.StartNew(() =>
            {
                int index = 0;

                while (true)
                {
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        break;
                    }

                    Console.WriteLine($"{index++}");
                    Task.Delay(1000);
                }
            }, cancellationTokenSource.Token);

            Console.ReadKey();

            cancellationTokenSource.Cancel();

            Task.Delay(1000);

            Console.WriteLine($"Status of soft canceled task is {task.Status}");
        }

        public static void HardCancellation()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() => Console.WriteLine("Hard cancellation requested!"));

            var task = Task.Factory.StartNew(() =>
            {
                int index = 0;

                while (true)
                {
                    cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        throw new OperationCanceledException("Cancellation requested!");
                    }

                    Console.WriteLine($"{index}");
                    index++;
                    Task.Delay(1000);
                }
            }, cancellationTokenSource.Token);

            Console.ReadKey();

            cancellationTokenSource.Cancel();

            Task.Delay(1000);

            Console.WriteLine($"Status of hard canceled task is {task.Status}");
        }
    }
}
