namespace Challenges.Kyu4.MagnetParticleBoxes;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/56c04261c3fcf33f2d000534">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/56c0473bc302b58832000039/groups/6823af8b66b06ef497e60a8c">here</see>
/// </summary>
public class Magnets 
{
    public static double Doubles(int maxk, int maxn)
    {
        double total = 0.0;
        
        for(var k = 1; k <= maxk; k++)
        {
            int dk = 2 * k;
            for(var n = 1; n <= maxn; n++)
            {
                total += 1.0 / (k * Math.Pow(n + 1, dk));
            }
        }
        return total;
    }
}