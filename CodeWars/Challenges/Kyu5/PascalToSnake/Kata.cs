using System.Text;

namespace Challenges.Kyu5.PascalToSnake;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/529b418d533b76924600085d">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5a06ba92cdccdd419c0010c3/groups/64c037ecda358c0001bc70d3">here</see>
/// </summary>
public static class Kata 
{
    public static string ToUnderscore(int str) => str.ToString();

    public static string ToUnderscore(string str) 
    {
        var builder = new StringBuilder();
        foreach (var c in str)
        {
            switch (c)
            {
                case >= 'A' and <= 'Z':
                    if (builder.Length > 0)
                        builder.Append('_');
                    builder.Append(char.ToLower(c));
                    break;
                default:
                    builder.Append(c);
                    break;
            }
        }

        return builder.ToString();
    }
}