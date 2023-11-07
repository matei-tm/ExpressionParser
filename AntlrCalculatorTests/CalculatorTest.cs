using AntlrCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntlrCalculatorTests;

[TestClass]
public class CalculatorTest
{
    [TestMethod]
    [DataRow("1+1", 2)]
    [DataRow("1-1", 0)]
    [DataRow("9+2*5+7", 26)]
    public void ShouldCalculateExpression(string expression, double expectedResult)
    {
        var calculator = new Calculator();
        double result = calculator.Calculate(expression);
        Assert.AreEqual(expectedResult, result);
    }
}