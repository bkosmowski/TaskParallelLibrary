using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace TaskParallelLibrary.Disposable
{
    public class SubscriptionDisposable : IDisposable
    {
        private readonly SerialDisposable _subscription = new SerialDisposable();

        private bool _disposed;

        public SubscriptionDisposable(IEventGenerator eventGenerator)
        {
            _subscription.Disposable = eventGenerator.Stream.ObserveOn(Scheduler.CurrentThread)
                .SubscribeOn(Scheduler.CurrentThread).Subscribe(_ => OnEventAppeared());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;    
            if (disposing)
            {
                _subscription.Dispose();
                _disposed = true;
            }
        }

        private void OnEventAppeared()
        {
            Console.WriteLine($"Event appeared in {nameof(SubscriptionDisposable)}!");
        }
    }
}
