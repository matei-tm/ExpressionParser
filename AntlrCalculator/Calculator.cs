using Antlr4.Runtime;

namespace AntlrCalculator
{
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
}

