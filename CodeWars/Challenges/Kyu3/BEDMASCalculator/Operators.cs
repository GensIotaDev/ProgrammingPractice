namespace Challenges.Kyu3.BEDMASCalculator;

public interface IOperator
{
    double Apply(double left, double right);
}
    
public class Exp : IOperator
{
    public double Apply(double left, double right)
    {
        return Math.Pow(left, right);
    }
}

public class Multiply : IOperator
{
    public double Apply(double left, double right)
    {
        return left * right;
    }
}

public class Divide : IOperator
{
    public double Apply(double left, double right)
    {
        if(right == 0)
        {
            throw new ArgumentException("Divisor can't be zero.");
        }

        return left / right;
    }
}

public class Addition : IOperator
{
    public double Apply(double left, double right)
    {
        return left + right;
    }
}

public class Subtraction : IOperator
{
    public double Apply(double left, double right)
    {
        return left - right;
    }
} 