namespace Challenges.Kyu5.SimplePigLatin;

using System.Text.RegularExpressions;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/520b9d2ad5c005041100000f">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/56a1b57eb8433c6f3c00006c/groups/63e258065f6d200001208002">here</see>
/// </summary>
public class Kata
{
    private static Regex regex = new Regex(@"\w+");
  
    public static string PigIt(string str)
    {
        return regex.Replace(str, (match) => 
        {
            var word = match.Value;
      
            return $"{word[1..]}{word[0]}ay";
        });
    }
}