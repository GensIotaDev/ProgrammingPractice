namespace Challenges.Kyu4.MysteryFunction;

using System;
using System.Numerics;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/56b2abae51646a143400001d">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d6fde2ed58c850001faed07/groups/6817c788a0a4edd1e85628d7">here</see>
/// </summary>
public class MysteryFunction
{
    public static long Mystery(long n)
    {
        return n ^ (n >> 1);
    }

    public static long MysteryInv(long n)
    {
        long mask = n;
        while(mask > 0)
        {
            mask >>= 1;
            n ^= mask;
        }
        return n;
    }

    public static string NameOfMystery()
    {
        return "Gray code";
    }
}