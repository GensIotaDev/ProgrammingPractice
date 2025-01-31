namespace Challenges.Kyu5.LazyRepeater;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/51fc3beb41ecc97ee20000c3">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/599e3b6e802d6a14db0032c4/groups/64c28ec5307b62000198c5f4">here</see>
/// </summary>
public class Kata
{
    public static Func<char> MakeLooper(string str)
    {
        var pos = 0;
        return () =>
        {
            if (pos == str.Length) pos = 0;
            return str[pos++];
        };
    }
}