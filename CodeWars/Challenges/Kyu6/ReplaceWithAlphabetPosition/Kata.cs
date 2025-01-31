namespace Challenges.Kyu6.ReplaceWithAlphabetPosition;

using System.Text;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/546f922b54af40e1e90001da">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/59b31adb49339dbd1e000013/groups/6124f02894bb6d0001e6fa89">here</see>
/// </summary>
public static class Kata
{
    public static string AlphabetPosition(string text)
    {
        StringBuilder builder = new StringBuilder();
    
        foreach(char c in text.ToLower())
        {
            //magic number is the ascii offset of a
            int alpha = (int)c - 97;
      
            //don't include non-alphabetical symbols
            if(alpha < 0 || alpha >= 26) continue;
      
            if(builder.Length != 0)
            {
                builder.Append(' ');
            }
      
            builder.Append(alpha + 1);
        }
    
        return builder.ToString();
    }
}