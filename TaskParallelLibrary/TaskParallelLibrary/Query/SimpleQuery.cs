using System;
using System.Linq.Expressions;
using TaskParallelLibrary.Enumerable;

namespace TaskParallelLibrary.Query
{
    public class SimpleQuery<T>
    {
        public SimpleEnumerator<T> GetEnumerator()
        {
            return new SimpleEnumerator<T>();
        }

        public SimpleQuery<T> Where(Expression<Func<T, bool>> f)
        {
            throw new NotImplementedException();
        }

        public SimpleQuery<TR> Select<TR>(Expression<Func<T, TR>> f)
        {
            throw new NotImplementedException();
        }

        public Expression Expression => throw new NotImplementedException();
    }
}
