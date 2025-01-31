namespace Challenges.Kyu5.LastDigitLargeNumber;

using System.Numerics;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5511b2f550906349a70004e1">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/62838ba96eec330001bde605/groups/64e27cadf900530001fb97e1">here</see>
/// </summary>
public class LastDigit
{
    public static int GetLastDigit(BigInteger n1, BigInteger n2)
    {
        if (n2 == 0) return 1;

        var a = n1 % 10;
        var b = n2 % 4;

        b = (b == 0) ? 4 : b;
        return (int)BigInteger.ModPow(a, b, 10);
    }
}