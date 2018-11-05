using System;

namespace TaskParallelLibrary.Equality
{
    public struct ValueTypeEquality : IEquatable<ValueTypeEquality>
    {
        public ValueTypeEquality(int firstProp, int secondProp)
        {
            FirstProp = firstProp;
            SecondProp = secondProp;
        }

        public int FirstProp { get; }
        public int SecondProp { get; }

        public override bool Equals(object obj)
        {
            if (obj is ValueTypeEquality other) return Equals(other);
            return false;
        }

        public bool Equals(ValueTypeEquality other)
        {
            return FirstProp == other.FirstProp && SecondProp == other.SecondProp;
        }

        public override int GetHashCode()
        {
            return FirstProp.GetHashCode() ^ SecondProp.GetHashCode();
        }
    }
}
