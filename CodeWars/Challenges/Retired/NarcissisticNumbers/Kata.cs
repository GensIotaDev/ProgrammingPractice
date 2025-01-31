namespace Challenges.Retired.NarcissisticNumbers;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/56b22765e1007b79f2000079">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/606f533d53432e00014f1855/groups/6293d0505ef6ba0001cbbef6">here</see>
/// </summary>
class Kata
{
    public static bool IsNarcissistic(long n)
    {
        var digits = GetDigits(n);
        long total = 0;
        foreach (int i in digits)
        {
            total += (long)Math.Pow(i, digits.Length);
        }
        
        
        return total == n;
    }
  
    //order does not matter in this instance (reversed)
    private static int[] GetDigits(long n)
    {
        List<int> digits = new List<int>();
        while (n >= 10)
        {
            int d = (int)(n % 10L);
            digits.Add(d);

            n = n / 10;
        }
        digits.Add((int)n);

        return digits.ToArray();
    }
}