namespace Challenges.Kyu3.MillionthFibonacci;

using System;
using System.Collections.Generic;
using System.Numerics;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/53d40c1e2f13e331fc000c26">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5b89574444324095c7000d3f/groups/615214ef4b8827000170ed33">here</see>
/// </summary>
public class Fibonacci
{
    private static Dictionary<int, BigInteger> mem = new Dictionary<int, BigInteger>()
    {
        { 0, 0 },
        { 1, 1 }
    };
  
    //Negative sequence
    public static BigInteger fib(int n)
    {
        BigInteger ans = fibCore(Math.Abs(n));
        if(n < 0 && n % 2 == 0)
        {
            ans *= -1;
        }
        if(!mem.ContainsKey(n))
        {
            mem.Add(n, ans);
        }

        return ans;
    }
  
    //Operates only on positive sequence
    private static BigInteger fibCore(int n)
    {
        if (mem.TryGetValue(n, out BigInteger v)) return v;

        if(n % 2 == 0) //F2n
        {
            int oN = n;
            n /= 2;

            if(!mem.TryGetValue(n, out BigInteger fn))
            {
                fn = fibCore(n);
            }
            if(!mem.TryGetValue(n - 1, out BigInteger fnMinus))
            {
                fnMinus = fibCore(n - 1);
            }

            BigInteger f2n = ((2 * fnMinus) + fn) * fn;
            mem.Add(oN, f2n);

            return f2n;
        }
        else
        {
            int oN = n;
            n = (n / 2) + 1;

            if(!mem.TryGetValue(n, out BigInteger fn))
            {
                fn = fibCore(n);
            }
            if(!mem.TryGetValue(n - 1, out BigInteger fnMinus))
            {
                fnMinus = fibCore(n - 1);
            }

            BigInteger f2nMinus = (fn * fn) + (fnMinus * fnMinus);
            mem.Add(oN, f2nMinus);

            return f2nMinus;
        }
    }
}