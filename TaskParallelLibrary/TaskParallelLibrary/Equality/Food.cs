namespace TaskParallelLibrary.Equality
{
    public class Food
    {
        private readonly int _calories;
        private readonly string _name;
        private readonly FoodGroup _group;

        public Food(int calories, string name, FoodGroup group)
        {
            _calories = calories;
            _name = name;
            _group = group;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Food food 
                   && food._calories == _calories 
                   && food._name == _name 
                   && food._group == _group;
        }

        public override int GetHashCode()
        {
            return _calories.GetHashCode() ^ _name.GetHashCode() ^ _group.GetHashCode();
        }
        
        public static bool operator ==(Food l, Food r) => Equals(l, r);

        public static bool operator !=(Food l, Food r) => !(l == r);
    }
}
