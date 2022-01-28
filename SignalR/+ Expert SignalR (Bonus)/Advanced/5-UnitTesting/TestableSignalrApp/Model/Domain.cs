namespace TestableSignalrApp.Model
{
    public class Domain: IDomain
    {
        private readonly ICalculator _calculator;
        public Domain(ICalculator calculator)
        {
            _calculator = calculator;
        }
        public int GetNumber(int a)
        {
            if (a > 10)
                return _calculator.Multiply(a, 10);
            if (a < 5)
                return _calculator.Multiply(a, -1);
            return _calculator.Multiply(a, 2);
        }
    }
}