using System;

namespace TaskParallelLibrary.Equality
{
    public struct FoodItem : IEquatable<FoodItem>
    {
        public FoodItem(int calories, string name, FoodGroup group)
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
            if (obj is FoodItem other) return Equals(other);
            return false;
        }

        public bool Equals(FoodItem other)
        {
            return Calories == other.Calories && Name == other.Name && Group == other.Group;
        }

        public override int GetHashCode()
        {
            return Calories.GetHashCode() ^ Name.GetHashCode() ^ Group.GetHashCode();
        }

        public static bool operator ==(FoodItem l, FoodItem r) => l.Equals(r);

        public static bool operator !=(FoodItem l, FoodItem r) => !l.Equals(r);
    }
}
