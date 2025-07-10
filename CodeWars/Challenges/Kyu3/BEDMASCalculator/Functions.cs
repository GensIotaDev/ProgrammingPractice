namespace Challenges.Kyu3.BEDMASCalculator;

public interface IFunction
{
    double Apply(double right);
}
  
public class UnaryMinus : IFunction
{
    public double Apply(double right)
    {
        return -1.0 * right;
    }
}
