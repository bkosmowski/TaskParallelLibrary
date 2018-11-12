using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Runtime.InteropServices;

namespace TaskParallelLibrary.Disposable
{
    public class UnmanagedDispose : SubscriptionDisposable
    {
        private IntPtr _pointer;
        private readonly SerialDisposable _eventGeneratorSubscription = new SerialDisposable();

        public UnmanagedDispose(IEventGenerator eventGenerator) : base(eventGenerator)
        {
            _eventGeneratorSubscription.Disposable = eventGenerator.Stream.ObserveOn(Scheduler.CurrentThread)
                .SubscribeOn(Scheduler.CurrentThread).Subscribe(_ => OnEventAppeared());

            _pointer = Marshal.AllocHGlobal(1024 * 1024 * 300);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _eventGeneratorSubscription.Dispose();
            }

            if (_pointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_pointer);
                _pointer = IntPtr.Zero;
            }

            base.Dispose(disposing);
        }

        private void OnEventAppeared()
        {
            Console.WriteLine($"Event appeared in {nameof(UnmanagedDispose)}!");
        }

        ~UnmanagedDispose()
        {
            Dispose(false);
        }
    }
}