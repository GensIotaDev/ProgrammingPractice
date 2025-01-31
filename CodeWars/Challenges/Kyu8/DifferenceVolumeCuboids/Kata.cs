namespace Challenges.Kyu8.DifferenceVolumeCuboids;

using System;
using System.Linq;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/58cb43f4256836ed95000f97">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/59ae1051310a9628560015b9/groups/618bcb7afb8d160001273126">here</see>
/// </summary>
public class Kata
{
    public static int FindDifference(int[] a, int[] b)
    {
        return Math.Abs(a.Aggregate((total, x) => total *= x) - b.Aggregate((total, x) => total *= x));
    }
}