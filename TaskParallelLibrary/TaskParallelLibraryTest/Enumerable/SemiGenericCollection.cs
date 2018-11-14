using System;
using System.Collections;
using System.Collections.Generic;

namespace TaskParallelLibraryTest.Enumerable
{
    public class SemiGenericCollection<T> : ICollection, IEnumerable<T>
    {
        private readonly IList<T> _list;

        public SemiGenericCollection(IEnumerable<T> enumerable)
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

        public void CopyTo(Array array, int index)
        {
            ((ICollection) _list).CopyTo(array, index);
        }

        public int Count => _list.Count;
        public bool IsSynchronized => throw new NotImplementedException();
        public object SyncRoot => throw new NotImplementedException();
    }
}