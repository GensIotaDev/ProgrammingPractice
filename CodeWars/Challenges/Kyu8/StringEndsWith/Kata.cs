namespace Challenges.Kyu8.StringEndsWith;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/51f2d1cafc9c0f745c00037d">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5990b47735fd2f187600011c/groups/5990be1e800bb6fb300000a8">here</see>
/// </summary>
public class Kata
{
  public static bool Solution(string str, string ending)
  {
    return str.EndsWith(ending);
  }
}