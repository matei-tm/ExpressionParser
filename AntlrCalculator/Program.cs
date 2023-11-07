using System.Text;
using Antlr4.Runtime;

namespace AntlrCalculator
{

    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter your expression:");
            var input = Console.ReadLine();
            try
            {
                var calculator = new Calculator();
                double result = calculator.Calculate(input);

                Console.WriteLine($"Result is: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }

    public class Calculator: ICalculator
    {
        public double Calculate(string? input)
        {
            AntlrInputStream inputStream = new AntlrInputStream(input);
            CalculatorLexer calculatorLexer = new CalculatorLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(calculatorLexer);
            CalculatorParser parser = new CalculatorParser(commonTokenStream);

            var tree = parser.start();

            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            var result = visitor.Visit(tree);
            return result;
        }
    }

    public interface ICalculator
    {
        double Calculate(string? input);
    }
}

