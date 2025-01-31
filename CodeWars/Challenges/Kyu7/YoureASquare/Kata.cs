namespace Challenges.Kyu7.YoureASquare;

using System;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/54c27a33fb7da0db0100040e">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/55bb4e2842bbc4e8ac0000f9/groups/6124c86f4c8a5b00011f5288">here</see>
/// </summary>
public class Kata
{
    public static bool IsSquare(int n)
    {
        if(n < 0) return false;
      
        int truncatedRoot = (int)Math.Sqrt(n);
      
        return n == (truncatedRoot * truncatedRoot);
    }
}