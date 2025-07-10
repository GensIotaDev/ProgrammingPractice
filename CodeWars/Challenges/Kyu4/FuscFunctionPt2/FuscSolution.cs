using System.Numerics;

namespace Challenges.Kyu4.FuscFunctionPt2;

public class FuscSolution
{
    public static BigInteger Fusc1(BigInteger n)
    {
        if (n <= 1) return n;
        
        var half = n >> 1;
        if (n.IsEven) return Fusc(half);

        return Fusc(half) + Fusc(half + 1);
    }

    public static BigInteger Fusc(BigInteger n)
    {
        BigInteger a = 0, b = 1;
        while (n > 0)
        {
            if (!n.IsEven)
            {
                a += b;
            }
            else
            {
                b += a;
            }
            n >>= 1;
        }
        
        return a;
    }
}