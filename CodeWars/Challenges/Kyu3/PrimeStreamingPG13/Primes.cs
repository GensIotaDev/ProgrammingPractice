namespace Challenges.Kyu3.PrimeStreamingPG13;

using System.Collections;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5519a584a73e70fa570005f5">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d6551f8df74a50001d01676/groups/61521ca288ae0100015eb69c">here</see>
/// </summary>
public class Primes
{
    public static IEnumerable<int> Stream()
    {
        int lastPrime = 0;
        while(true)
        {
            if(IsPrime(++lastPrime))
            {
                yield return lastPrime;
            }
        }
    }
  
    private static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n <= 3) return true;

        if(n % 2 == 0 || n % 3 == 0)
        {
            return false;
        }

        for(int i = 5; i * i <= n; i+=6)
        {
            if(n % i == 0 || n % (i + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }
}