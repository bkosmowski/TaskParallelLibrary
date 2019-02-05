namespace TaskParallelLibrary.Enumerable
{
    public class SimpleEnumerable
    {
        public SimpleEnumerator GetEnumerator()
        {
            return new SimpleEnumerator();
        }
    }

    public class SimpleEnumerator
    {
        public bool MoveNext()
        {
            return true;
        }

        public object Current => 50;
    }

    public class SimpleEnumerator<T>
    {
        public bool MoveNext()
        {
            return true;
        }

        public T Current { get; }
    }
}
