namespace AntlrCalculator
{
    public class BasicCalculatorVisitor : CalculatorBaseVisitor<double>
    {

        public override double VisitNumber(CalculatorParser.NumberContext ctx)
        {
            return double.Parse(ctx.richNumber().GetText());
        }


        public override double VisitNegation(CalculatorParser.NegationContext ctx)
        {
            return -1 * this.Visit(ctx.right);
        }

        /**
         * Parentheses are used to give precedence to
         * the expression around which they are wrapped.
         *
         * This precedence is caused elsewhere,
         * in the grammar, via the order in which
         * the rules are defined (ANTLR4).
         *
         * @return Double
         */

        public override double VisitParentheses(CalculatorParser.ParenthesesContext ctx)
        {
            return this.Visit(ctx.inner);
        }

        /**
         * @return Double
         */

        public override double VisitPower(CalculatorParser.PowerContext ctx)
        {
            return Math.Pow(this.Visit(ctx.left), Visit(ctx.right));
        }


        public override double VisitMultiplicationOrDivision(CalculatorParser.MultiplicationOrDivisionContext ctx)
        {
            if (ctx.@operator.Text.Equals("*"))
            {
                return this.Visit(ctx.left) * this.Visit(ctx.right);
            }

            return this.Visit(ctx.left) / this.Visit(ctx.right);
        }


        public override double VisitAdditionOrSubtraction(CalculatorParser.AdditionOrSubtractionContext ctx)
        {
            if (ctx.@operator.Text.Equals("+"))
            {
                return this.Visit(ctx.left) + this.Visit(ctx.right);
            }

            return this.Visit(ctx.left) - this.Visit(ctx.right);
        }
    }
}

