namespace TaskParallelLibrary.Immutable
{
    public readonly struct Complex
    {
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        
        public double Real { get; }
        
        public double Imaginary { get; }
    }
}