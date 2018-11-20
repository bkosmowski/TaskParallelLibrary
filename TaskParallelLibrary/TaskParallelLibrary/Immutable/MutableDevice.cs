using System.Runtime.CompilerServices;

namespace TaskParallelLibrary.Immutable
{
    public class MutableDevice
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public void Discount(int discount) => Price = Price * (1 - discount / 100M);
    }
}