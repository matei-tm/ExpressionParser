using AntlrCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntlrCalculatorTests;

[TestClass]
public class CalculatorTest
{
    [TestMethod]
    [DataRow("1+1", 2)]
    public void TestMethod1(string expression, double expectedResult)
    {
        var calculator = new Calculator();
        double result = calculator.Calculate(expression);
        Assert.AreEqual(expectedResult, result);
    }
}