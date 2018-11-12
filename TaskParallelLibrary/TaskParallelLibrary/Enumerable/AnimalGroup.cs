using System.Collections;
using System.Collections.Generic;

namespace TaskParallelLibrary.Enumerable
{
    public class AnimalGroup : IEnumerable<Animal>
    {
        private readonly Animal _firstAnimal;
        private readonly Animal _secondAnimal;
        private readonly Animal _thirdAnimal;

        public AnimalGroup(Animal firstAnimal, Animal secondAnimal, Animal thirdAnimal)
        {
            _firstAnimal = firstAnimal;
            _secondAnimal = secondAnimal;
            _thirdAnimal = thirdAnimal;
        }

        public IEnumerator<Animal> GetEnumerator()
        {
            yield return _firstAnimal;
            yield return _secondAnimal;
            yield return _thirdAnimal;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Animal
    {
        private readonly string _name;
        private readonly int _age;
        
        public Animal(string name, int age)
        {
            _name = name;
            _age = age;
        }
        
        public override string ToString()
        {
            return $"{_name} in age of {_age}";
        }
    }
}