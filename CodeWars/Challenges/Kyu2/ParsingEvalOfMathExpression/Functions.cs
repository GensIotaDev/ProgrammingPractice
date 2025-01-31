namespace Challenges.Kyu2.ParsingEvalOfMathExpression;

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
  
public class Abs : IFunction
{
    public double Apply(double right)
    {
        return Math.Abs(right);
    }
}

public class Acos : IFunction
{
    public double Apply(double right)
    {
        return Math.Acos(right);
    }
}

public class Asin : IFunction
{
    public double Apply(double right)
    {
        return Math.Asin(right);
    }
}

public class Atan : IFunction
{
    public double Apply(double right)
    {
        return Math.Atan(right);
    }
}

public class Cos : IFunction
{
    public double Apply(double right)
    {
        return Math.Cos(right);
    }
}

public class Sin : IFunction
{
    public double Apply(double right)
    {
        return Math.Sin(right);
    }
}

public class Tan: IFunction
{
    public double Apply(double right)
    {
        return Math.Tan(right);
    }
}

public class Cosh: IFunction
{
    public double Apply(double right)
    {
        return Math.Cosh(right);
    }
}

public class Sinh : IFunction
{
    public double Apply(double right)
    {
        return Math.Sinh(right);
    }
}

public class Tanh : IFunction
{
    public double Apply(double right)
    {
        return Math.Tanh(right);
    }
}
    
public class Sqrt : IFunction
{
    public double Apply(double right)
    {
        if(right < 0)
        {
            throw new NotFiniteNumberException($"Sqrt({right})");
        }
          
        return Math.Sqrt(right);
    }
}