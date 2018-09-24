using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    public class Waiting
    {
        private readonly CancellationTokenSource _cancellationTokenSource;

        private readonly Task _task;

        private readonly Task _task2;

        public Waiting()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(3));

            _task = new Task(() =>
            {
                Console.WriteLine("Wait 5 seconds for complete the task");

                for (var i = 0; i < 5; i++)
                {
                    _cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }
            });

            _task2 = new Task(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Second task is done!");
            }, _cancellationTokenSource.Token);
        }

        public void WaitForAll()
        {
            _task.Start();
            _task2.Start();
            try
            {
                Task.WaitAll(new[] {_task, _task2}, 4000, _cancellationTokenSource.Token);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e}");
            }

            Console.WriteLine($"First task status is {_task.Status}");
            Console.WriteLine($"Second task status is {_task2.Status}");
        }

        public void WaitForAny()
        {
            _task.Start();
            _task2.Start();
            try
            {
                Task.WaitAny(new[] {_task, _task2});
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e}");
            }

            Console.WriteLine($"First task status is {_task.Status}");
            Console.WriteLine($"Second task status is {_task2.Status}");
        }
    }
}
