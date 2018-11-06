namespace TaskParallelLibrary.Equality
{
    public sealed class CookedFood : Food
    {
        public CookedFood(int calories, string name, FoodGroup group, string cookingMethod)
            : base(calories, name, group)
        {
            CookingMethod = cookingMethod;
        }

        public string CookingMethod { get; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj) == false) return false;

            return obj is CookedFood cookedFood && cookedFood.CookingMethod == CookingMethod;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ CookingMethod.GetHashCode();
        }

        public static bool operator ==(CookedFood l, CookedFood r) => Equals(l, r);

        public static bool operator !=(CookedFood l, CookedFood r) => !(l == r);
    }
}
