using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    public class DataSharing
    {
        public static void TestResetEvents(int numberOfAdds)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            DataSharing.SyncOperationWithManualResetEvent(numberOfAdds);

            stopwatch.Stop();

            Console.WriteLine(
                $"Usage of ManualResetEvent for {numberOfAdds} items took {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();

            stopwatch.Start();

            DataSharing.SyncOperationWithManualResetEventSlim(numberOfAdds);

            stopwatch.Stop();

            Console.WriteLine(
                $"Usage of ManualResetEventSlim {numberOfAdds} items took {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();

            stopwatch.Start();

            DataSharing.SyncOperationWithAutoResetEvent(numberOfAdds);

            stopwatch.Stop();

            Console.WriteLine(
                $"Usage of AutoResetEvent for {numberOfAdds} items took {stopwatch.ElapsedMilliseconds} ms");
        }

        private static void WriteWithSemaphore(int numberOfAdds)
        {
            var random = new Random(10000);
            var resource = 10;
            var semaphore = new Semaphore(0, 1);
            var tasks = new List<Task>();
            for (var index = 0; index < 1000000; index++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    semaphore.WaitOne();
                    for (var i = 0; i < numberOfAdds; i++)
                    {
                        resource += random.Next(100);
                    }
                    semaphore.Release();
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }

        public static void TestReaderWriterLocks(int numberOfAdds)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            DataSharing.WriteWithReaderWriterLock(numberOfAdds);
            stopwatch.Stop();
            Console.WriteLine(
                $"Usage of ReaderWriterLock for {numberOfAdds} items took {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();
            stopwatch.Start();
            DataSharing.WriteWithReaderWriterLockSlim(numberOfAdds);
            stopwatch.Stop();
            Console.WriteLine(
                $"Usage of ReaderWriterLockSlim {numberOfAdds} items took {stopwatch.ElapsedMilliseconds} ms");
        }

        private static void WriteWithReaderWriterLockSlim(int numberOfAdds)
        {
            var random = new Random(10000);
            var resource = 10;
            var readerWriterLockSlim = new ReaderWriterLockSlim();
            var tasks = new List<Task>();
            for (var index = 0; index < 1000000; index++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    readerWriterLockSlim.EnterWriteLock();
                    for (var i = 0; i < numberOfAdds; i++)
                    {
                        resource += random.Next(100);
                    }
                    readerWriterLockSlim.ExitWriteLock();
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
        private static void WriteWithReaderWriterLock(int numberOfAdds)
        {
            var random = new Random(10000);
            var resource = 10;
            var readerWriterLockSlim = new ReaderWriterLock();
            var tasks = new List<Task>();
            for (var index = 0; index < 1000000; index++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    readerWriterLockSlim.AcquireWriterLock(Timeout.Infinite);
                    for (var i = 0; i < numberOfAdds; i++)
                    {
                        resource += random.Next(100);
                    }
                    readerWriterLockSlim.ReleaseWriterLock();
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }

        private static void SyncOperationWithManualResetEvent(int addsNumber)
        {
            var random = new Random(10000);
            var manualResetEvent = new ManualResetEvent(true);
            var resource = 10;
            var tasks = new List<Task>();
            for (var index = 0; index < 1000000; index++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    manualResetEvent.WaitOne();
                    for (var i = 0; i < addsNumber; i++)
                    {
                        resource += random.Next(100);
                    }
                    manualResetEvent.Set();
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
        private static void SyncOperationWithManualResetEventSlim(int addsNumber)
        {
            var random = new Random(10000);
            var manualResetEvent = new ManualResetEventSlim(true);
            var resource = 10;
            var tasks = new List<Task>();
            for (var index = 0; index < 1000000; index++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    manualResetEvent.Wait();
                    for (var i = 0; i < addsNumber; i++)
                    {
                        resource += random.Next(100);
                    }
                    manualResetEvent.Set();
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
        private static void SyncOperationWithAutoResetEvent(int numberOfAdds)
        {
            var random = new Random(10000);
            var autoResetEvent = new AutoResetEvent(true);
            var resource = 10;
            var tasks = new List<Task>();
            for (var index = 0; index < 1000000; index++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    autoResetEvent.WaitOne();
                    for (var i = 0; i < numberOfAdds; i++)
                    {
                        resource += random.Next(100);
                    }
                    autoResetEvent.Set();
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
        private static void SyncOperationWithManualResetEvent()
        {
            var random = new Random(10000);
            var manualResetEvent = new ManualResetEvent(true);

            var resource = 10;
            var tasks = new List<Task>();
            for (var index = 0; index < 1000000; index++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    manualResetEvent.WaitOne();
                    resource += random.Next(100);
                    resource += random.Next(100);
                    resource += random.Next(100);
                    resource += random.Next(100);
                    manualResetEvent.Set();
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }

        private static void SyncOperationWithManualResetEventSlim()
        {
            var random = new Random(10000);
            var manualResetEvent = new ManualResetEventSlim(true);
            var resource = 10;
            var tasks = new List<Task>();
            for (var index = 0; index < 1000000; index++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    manualResetEvent.Wait();
                    resource += random.Next(100);
                    resource += random.Next(100);
                    resource += random.Next(100);
                    resource += random.Next(100);
                    manualResetEvent.Set();
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
        public static void TestLocks()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var index = 0; index < 10000; index++)
            {
                DataSharing.SyncOperationOnBankAccountWithSpinLock();
            }

            stopwatch.Stop();
            Console.WriteLine($"Spin lock elapsed time {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();
            for (var index = 0; index < 10000; index++)
            {
                DataSharing.SyncOperationOnBankAccountWithLock();
            }

            stopwatch.Stop();
            Console.WriteLine($"Lock elapsed time {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();
            for (var index = 0; index < 10000; index++)
            {
                DataSharing.SyncOperationOnBankAccountWithInterlocked();
            }

            stopwatch.Stop();
            Console.WriteLine($"Interlocked elapsed time {stopwatch.ElapsedMilliseconds} ms");
        }

        public static void SyncWithReaderWriterLocks()
        {
            var x = 0;

            var readerWriterLockSlim = new ReaderWriterLockSlim();

            var tasks = new List<Task>();

            for (var index = 0; index < 10; index++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    readerWriterLockSlim.EnterReadLock();

                    Console.WriteLine($"Entered read lock, x = {x}, pausing for 5 seconds");
                    Task.Delay(TimeSpan.FromSeconds(5));

                    readerWriterLockSlim.ExitReadLock();

                    Console.WriteLine($"Exited read lock, x = {x}.");
                }));
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine(e);
                    return true;
                });
            }

            Random random = new Random();

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    readerWriterLockSlim.EnterReadLock();

                    Console.WriteLine($"Entered read lock, x = {x}, pausing for 5 seconds");
                    Task.Delay(TimeSpan.FromSeconds(5));

                    readerWriterLockSlim.ExitReadLock();

                    Console.WriteLine($"Exited read lock, x = {x}.");
                }

            });

            while (true)
            {
                Console.ReadKey();
                readerWriterLockSlim.EnterWriteLock();
                Console.WriteLine("Write lock acquired");
                var newValue = random.Next(10);
                x = newValue;
                Console.WriteLine($"Set x = {x}");
                readerWriterLockSlim.ExitWriteLock();
                Console.WriteLine("Write lock released");
            }
        }

        public static void SyncOperationOnBankAccountWithSpinLock()
        {
            var tasks = new List<Task>();

            var bankAccount = new SpinLockBankAccount();

            var spinLock = new SpinLock();

            for (var index = 0; index < 10; index++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bool lockTaken = false;

                        try
                        {
                            spinLock.Enter(ref lockTaken);
                            bankAccount.Deposit(100);
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
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bool lockTaken = false;

                        try
                        {
                            spinLock.Enter(ref lockTaken);
                            bankAccount.Withdraw(100);
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
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            // Debug.WriteLine($"Current balance on account is {bankAccount.Balance}");
        }

        class SpinLockBankAccount
        {
            public int Balance { get; private set; }

            public SpinLockBankAccount()
            {
                Balance = 0;
            }

            public void Deposit(int amount)
            {
                Balance += amount;
            }

            public void Withdraw(int amount)
            {
                Balance -= amount;
            }
        }

        public static void SyncOperationOnBankAccountWithInterlocked()
        {
            var tasks = new List<Task>();

            var bankAccount = new InterlockedBankAccount();

            for (var index = 0; index < 10; index++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bankAccount.Deposit(100);
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bankAccount.Withdraw(100);
                    }
                }));
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ae)
            {
                Console.WriteLine(ae);
            }

            var task1 = new Task(() =>
            {
                bankAccount.Exchange(100000);
            });

            var task2 = new Task(() =>
            {
                bankAccount.CompareExchange(1000000000);
            });

            task1.Start();
            task2.Start();

            Task.WaitAll(new[] { task1, task2 });

            // Debug.WriteLine($"Current balance on account is {bankAccount.Balance}");
        }

        class InterlockedBankAccount
        {
            private int _balance;

            public int Balance
            {
                get => _balance;
                private set => _balance = value;
            }

            public InterlockedBankAccount()
            {
                Balance = 0;
            }
            //Dodac pomiary pomiedzy innymi sposobami
            public void Deposit(int amount)
            {
                Interlocked.Add(ref _balance, amount);
            }

            public void Withdraw(int amount)
            {
                Interlocked.Add(ref _balance, -amount);
            }

            public void Exchange(int amount)
            {
                Interlocked.Exchange(ref _balance, amount);
            }

            public void CompareExchange(int amount)
            {
                Interlocked.CompareExchange(ref _balance, amount, 0);
            }
        }

        public static void SyncOperationOnBankAccountWithLock()
        {
            var tasks = new List<Task>();

            var bankAccount = new LockBankAccount();

            for (var index = 0; index < 10; index++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bankAccount.Deposit(100);
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bankAccount.Withdraw(100);
                    }
                }));
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ae)
            {
                Console.WriteLine(ae);
            }

            // Debug.WriteLine($"Current balance on account is {bankAccount.Balance}");
        }

        class LockBankAccount
        {
            private readonly object _locker = new object();

            public LockBankAccount()
            {
                Balance = 0;
            }

            public int Balance { get; private set; }

            public void Deposit(int amount)
            {
                lock (_locker)
                {
                    Balance += amount;
                }
            }

            public void Withdraw(int amount)
            {
                lock (_locker)
                {
                    Balance -= amount;
                }
            }
        }
    }
}
