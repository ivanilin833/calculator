using Xunit;
using ClassLibrary1;

namespace TestCalculator
{
    public class UnitTestCalculator
    {
        readonly ConsoleCalculator _consCalc = new();

        [Theory]
        [InlineData(0,"5-x")]
        [InlineData(0,"(2-3)/(2-2)")]
        [InlineData(1.5,"1+2-1*3/2")]
        [InlineData(-6,"(-3+5)*(-8+2)/2")]
        [InlineData(0, "-5+5")]
        [InlineData(20, "-5+5*5")]
        [InlineData(0, "10/0")]
        [InlineData(15, "((1+2)*(2+3))")]
        public void Test1(double result, string inputExpression)
        {
            // ARRANGE
            // ACT
            // ASSERT
            Assert.Equal(result, _consCalc.ConsCalc(inputExpression));
        }
    }
}
