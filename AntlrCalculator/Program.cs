using System.Text;

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
}

