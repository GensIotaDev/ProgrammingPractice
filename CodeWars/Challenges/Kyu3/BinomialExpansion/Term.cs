namespace Challenges.Kyu3.BinomialExpansion;

public class Term
{
    public string VariableName;

    public long Coefficient;
    public Expression InnerExpression;
    public int Exponent;

    public Term() : this("x", 1, 1, null) {}
    public Term(string variableName, long coefficient, int exponent, Expression expression = null)
    {
      this.VariableName = variableName;
      this.Coefficient = coefficient;
      this.Exponent = exponent;
      this.InnerExpression = expression;
    }

    public Expression Expand()
    {
      if(InnerExpression is null || Exponent < 2)
      {
          return new Expression(new Term[] { this });
      }

      Expression total = InnerExpression;
      for(int i = 0; i < Exponent - 1; i++)
      {
          total *= InnerExpression;
      }

      if(Coefficient > 1)
      {
          Term mult = new Term(this.VariableName, this.Coefficient, 0);

          total *= mult;
      }

      return total;
    }

    public override string ToString()
    {
      if(Exponent == 0)
      {
          return Coefficient.ToString();
      }

      string co = (Math.Abs(Coefficient) == 1) ? $"{((Coefficient > 0) ? string.Empty : "-")}" : Coefficient.ToString();
      string exp = (Exponent > 1) ? $"^{Exponent}" : string.Empty;

      string inner = string.Empty;
      if (InnerExpression is null)
      {
          inner = VariableName;
      }
      else
      {
          if (co.Length == 0 && exp.Length == 0)
          {
              inner = InnerExpression.ToString();
          }
          else
          {
              inner = $"({InnerExpression})";
          }
      }

      return $"{co}{inner}{exp}";
    }

    public static Term operator*(Term a, Term b)
    {
      long co = a.Coefficient * b.Coefficient;
      int exp = a.Exponent + b.Exponent;

      return new Term(a.VariableName, co, exp, a.InnerExpression);
    }
    public static Term operator+(Term a, Term b)
    {
      if (a.VariableName != b.VariableName && a.Exponent != b.Exponent) throw new ArgumentException("Terms require same root and same exponent to be added together.");

      long co = a.Coefficient + b.Coefficient;
      return new Term(a.VariableName, co, a.Exponent, a.InnerExpression);
    }
}