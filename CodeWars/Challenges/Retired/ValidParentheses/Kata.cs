namespace Challenges.Retired.ValidParentheses;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/52774a314c2333f0a7000688">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/59960ed4f017e45f6000156b/groups/63e25e1b4160c400013643c2">here</see>
/// </summary>
public class Parentheses
{
    public static bool ValidParentheses(string input)
    {
        var openStack = 0;
        foreach (var c in input)
        {
            switch (c)
            {
                case '(':
                    openStack++;
                    break;
                case ')':
                    if (openStack == 0) return false;
                    openStack--;
                    break;
            }
        }

        return openStack == 0;
    }
}