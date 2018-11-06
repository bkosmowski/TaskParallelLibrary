namespace TaskParallelLibrary.Equality
{
    public class Food
    {
        public Food(int calories, string name, FoodGroup group)
        {
            Calories = calories;
            Name = name;
            Group = group;
        }

        public int Calories { get; }
        public string Name { get; }
        public FoodGroup Group { get; }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Food food && Equals(food);
        }

        public override int GetHashCode()
        {
            return Calories.GetHashCode() ^ Name.GetHashCode() ^ Group.GetHashCode();
        }
        
        public static bool operator ==(Food l, Food r) => Equals(l, r);

        public static bool operator !=(Food l, Food r) => !(l == r);
    }
}
