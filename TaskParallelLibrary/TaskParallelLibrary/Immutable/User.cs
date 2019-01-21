using System;

namespace TaskParallelLibrary.Immutable
{
    public class User
    {
        private readonly Random _random = new Random(10000);

        public User(string name, ImmutableDevice immutableDevice, MutableDevice mutableDevice)
        {
            Name = name;
            ImmutableDevice = immutableDevice;
            MutableDevice = mutableDevice;
        }
        
        public string Name { get; }

        public ImmutableDevice ImmutableDevice { get; private set; }

        public MutableDevice MutableDevice { get; private set; }

        public void ChangeImmutableDevice()
        {
            ImmutableDevice = new ImmutableDevice("Test device", _random.Next(10000));
        }

        public void ChangeMutableDevice()
        {
            MutableDevice.Price = _random.Next(10000);
        }
    }
}
