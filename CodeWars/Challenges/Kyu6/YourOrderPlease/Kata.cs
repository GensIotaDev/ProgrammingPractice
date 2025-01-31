namespace Challenges.Kyu6.YourOrderPlease;

using System;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/55c45be3b2079eccff00010f">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/59c21cd403a9ad981f000933/groups/6125098cb1be5000018bcc61">here</see>
/// </summary>
public static class Kata
{
    public static string Order(string words)
    {
        Regex rx = new Regex(@"\s*?(\w*(\d)\w*)\s*?");
    
        MatchCollection matches = rx.Matches(words);
      
        //maximum priority/word count is 9
        string[] ordered = new string[9];
      
        foreach(Match m in matches)
        {
            int.TryParse(m.Groups[2].Value, out int priority);
        
            ordered[priority - 1] = m.Groups[1].Value;
        }
    
        StringBuilder builder = new StringBuilder();
        for(int i = 0; i < matches.Count; i++)
        {
            if(builder.Length != 0)
            {
                builder.Append(' ');
            }
        
            builder.Append(ordered[i]);
        }
    
        return builder.ToString();
    }
}