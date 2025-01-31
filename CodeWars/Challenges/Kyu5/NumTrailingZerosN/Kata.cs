namespace Challenges.Kyu5.NumTrailingZerosN;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/52f787eb172a8b4ae1000a34">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/59b794bc62a4af4593001bf9/groups/64cd35fab7aed40001ac6e66">here</see>
/// </summary>
public static class Kata 
{
    public static int TrailingZeros(int n)
    {
        var k = (int)Math.Log(n, 5);

        var total = 0;
        for (var i = 1; i <= k; i++)
        {
            total += (int)(n / Math.Pow(5, i));
        }

        return total;
    }
}