namespace TestableSignalrApp.Model
{
    public class Calculator : ICalculator
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Substract(int a, int b)
        {
            return a - b;
        }

        public int Divide(int a, int b)
        {
            return a/b;
        }
    }
}