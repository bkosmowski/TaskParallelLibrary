using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace TaskParallelLibrary.Disposable
{
    public class Disposable : IDisposable
    {
        private readonly SerialDisposable _subscription = new SerialDisposable();

        public Disposable(EventGenerator eventGenerator)
        {
            _subscription.Disposable = eventGenerator.Stream.ObserveOn(Scheduler.CurrentThread)
                .SubscribeOn(Scheduler.CurrentThread).Subscribe(_ => OnEventAppeared());
        }

        private void OnEventAppeared()
        {
            Console.WriteLine("Event appeared!");
        }

        public void Dispose()
        {
            _subscription?.Dispose();
        }
    }

    public interface IEventGenerator
    {
        void BroadcastEvent();
        IObservable<Unit> Stream { get; }
    }

    public class EventGenerator : IEventGenerator
    {
        private readonly ISubject<Unit> _stream = new Subject<Unit>();

        public void BroadcastEvent()
        {
            _stream.OnNext(Unit.Default);
        }

        public IObservable<Unit> Stream => _stream.AsObservable();
    }
}
