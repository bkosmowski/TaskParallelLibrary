using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace TaskParallelLibrary.Disposable
{
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