namespace ClassLibrary1
{
    public class ConsoleCalculator
    {
        private readonly Calculator _calc;

        public ConsoleCalculator()
        {
            _calc = new Calculator();
        }

        public double ConsCalc(string inputExpression)
        {
            try
            {
               return _calc.Calc(inputExpression);
            }
            catch
            {
                Errors.ErrorInExpression();
                return 0;
            }
        }
    }
}
