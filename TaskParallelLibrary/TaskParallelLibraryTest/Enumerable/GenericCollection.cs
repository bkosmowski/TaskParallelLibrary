using System.Collections;
using System.Collections.Generic;

namespace TaskParallelLibraryTest.Enumerable
{
    public class GenericCollection<T> : ICollection<T>
    {
        private readonly IList<T> _list;

        public GenericCollection(IEnumerable<T> enumerable)
        {
            _list = new List<T>(enumerable);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public int Count => _list.Count;
        public bool IsReadOnly => _list.IsReadOnly;
    }
}