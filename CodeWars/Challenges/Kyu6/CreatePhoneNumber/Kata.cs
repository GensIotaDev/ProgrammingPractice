namespace Challenges.Kyu6.CreatePhoneNumber;

using System;
using System.Linq;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/525f50e3b73515a6db000b83">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/59b1a33a4f820bfc5a00150e/groups/5b903b2f0059e52e6d0005ad">here</see>
/// </summary>
public class Kata
{
    public static string CreatePhoneNumber(int[] numbers)
    {
        return string.Format("({0}{1}{2}) {3}{4}{5}-{6}{7}{8}{9}", numbers.Cast<object>().ToArray());
    }
}