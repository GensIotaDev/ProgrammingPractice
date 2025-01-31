namespace Challenges.Kyu5.NotVerySecure;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/526dbd6c8c0eb53254000110">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/599ea6aee50047b3af0029e2/groups/64c03e01e10e0300010d2b08">here</see>
/// </summary>
public class Kata
{
    public static bool Alphanumeric(string str)
    {
        if (str.Length == 0) return false;
    
        var firstWrong = str.FirstOrDefault(c => !char.IsLetterOrDigit(c));
        return firstWrong == default(char);
    }
}