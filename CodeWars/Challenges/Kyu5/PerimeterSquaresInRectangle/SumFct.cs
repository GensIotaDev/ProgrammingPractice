namespace Challenges.Kyu5.PerimeterSquaresInRectangle;

using System.Numerics;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/559a28007caad2ac4e000083">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/55aba38ac5830ac1730000bb/groups/64cd3038a4f2640001707635">here</see>
/// </summary>
public class SumFct
{
    //Assume index n will never actually be larger than an int
    private static List<(BigInteger value, BigInteger sum)> FibSequence = new()
    {
        (1, 4),
        (1, 8),
    };
  
    public static BigInteger perimeter(BigInteger n) 
    {
        var target = (int)n;

        for (var i = FibSequence.Count; i <= target + 2; i++)
        {
            var fib = BigInteger.Add(FibSequence[i - 2].value, FibSequence[i - 1].value);
            FibSequence.Add((fib, 0));

            var temp = FibSequence[i - 2];
            temp.sum = BigInteger.Multiply(4, BigInteger.Subtract(fib, 1));
            FibSequence[i - 2] = temp; //apply struct changes
        }

        return FibSequence[target].sum;
    }
}