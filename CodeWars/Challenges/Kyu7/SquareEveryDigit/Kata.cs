namespace Challenges.Kyu7.SquareEveryDigit;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/546e2562b03326a88e000020">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5990b32035fd2f187600001a/groups/63e24bee5d186d0001984313">here</see>
/// </summary>
public class Kata
{
    public static int SquareDigits(int n)
    {
        var str = n.ToString();
    
        var aggregate = str.Aggregate(string.Empty, (total, letter) =>
        {
            var digit = letter - '0';
      
            return total + (digit * digit);
        });
    
        return int.Parse(aggregate);
    }
}