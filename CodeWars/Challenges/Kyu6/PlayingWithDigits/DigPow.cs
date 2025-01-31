namespace Challenges.Kyu6.PlayingWithDigits;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5552101f47fc5178b1000050">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/555223eddfa1a05ee100003e/groups/64c02f66da358c0001bc6f67">here</see>
/// </summary>
public class DigPow {
    public static long digPow(int n, int p) 
    {
        var digits = 1 + (int)Math.Log10(n);

        long total = 0;
        var remainder = n;
        for (var i = digits; i != 0; i--)
        {
            var digit = remainder % 10;
            remainder /= 10;
            total += (long)Math.Pow(digit, p + i - 1);
        }

        var ans = total / n;

        return (ans * n == total) ? ans : -1;
    }
}