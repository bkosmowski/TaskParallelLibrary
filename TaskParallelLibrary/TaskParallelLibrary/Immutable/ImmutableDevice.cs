namespace TaskParallelLibrary.Immutable
{
    public class ImmutableDevice
    {
        public ImmutableDevice(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        
        public string Name { get; }
        
        public decimal Price { get; }

        public ImmutableDevice Discount(int discount) => new ImmutableDevice(Name, Price * (1 - discount / 100M));

        //TODO: User posiada urz¹dzenie i mo¿e je zmieniaæ.
        //TODO: Implemnetacja na wielu w¹tkach
    }
}