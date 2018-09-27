using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    public class DataSharing
    {
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
                    Thread.Sleep(TimeSpan.FromSeconds(5));

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
                    Thread.Sleep(TimeSpan.FromSeconds(5));

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

            Debug.WriteLine($"Current balance on account is {bankAccount.Balance}");
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

            Debug.WriteLine($"Current balance on account is {bankAccount.Balance}");
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

            Debug.WriteLine($"Current balance on account is {bankAccount.Balance}");
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
