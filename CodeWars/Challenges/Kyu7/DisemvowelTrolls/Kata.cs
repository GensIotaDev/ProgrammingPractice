using System.Text;

namespace Challenges.Kyu7.DisemvowelTrolls;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/52fba66badcd10859f00097e">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/550af1f4595138841700089f/groups/63e244f51375d40001ab9d89">here</see>
/// </summary>
public static class Kata
{
    public static string Disemvowel(string str)
    {
        var builder = new StringBuilder();
      
        foreach(var letter in str.Where(letter => !IsVowel(letter)))
        {
            builder.Append(letter);
        }
      
        return builder.ToString();
    }
    
    private static bool IsVowel(char c)
    {
        if(!char.IsLetter(c)) return false;
      
        c = char.ToLower(c);
      
        switch(c)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                return true;
        }
      
        return false;
    }
}