namespace TaskParallelLibrary.Equality
{
    public sealed class CookedFood : Food
    {
        private readonly string _cookingMethod;

        public CookedFood(int calories, string name, FoodGroup group, string cookingMethod)
            : base(calories, name, group)
        {
            _cookingMethod = cookingMethod;
        }


        public override bool Equals(object obj)
        {
            if (base.Equals(obj) == false) return false;

            return obj is CookedFood cookedFood && cookedFood._cookingMethod == _cookingMethod;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _cookingMethod.GetHashCode();
        }

        public static bool operator ==(CookedFood l, CookedFood r) => Equals(l, r);

        public static bool operator !=(CookedFood l, CookedFood r) => !(l == r);
    }
}
