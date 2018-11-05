using System;

namespace TaskParallelLibrary.Equality
{
    public class ReferenceTypeEquality : IEquatable<ReferenceTypeEquality>
    {
        public ReferenceTypeEquality(int firstProp, int secondProp)
        {
            FirstProp = firstProp;
            SecondProp = secondProp;
        }

        public int FirstProp { get; }
        public int SecondProp { get; }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            return obj is ReferenceTypeEquality referenceType && Equals(referenceType);
        }

        public override int GetHashCode()
        {
            return FirstProp.GetHashCode() ^ SecondProp.GetHashCode();
        }

        public bool Equals(ReferenceTypeEquality other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return FirstProp == other.FirstProp && SecondProp == other.SecondProp;
        }

        public static bool operator ==(ReferenceTypeEquality l, ReferenceTypeEquality r) => Equals(l, r);

        public static bool operator !=(ReferenceTypeEquality l, ReferenceTypeEquality r) => !(l == r);
    }
}
