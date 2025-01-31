namespace Challenges.Kyu6.DetectPangram;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/545cedaa9943f7fe7b000048">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/59ae0e50cfb4470003000171/groups/61265cab056eff000125ed27">here</see>
/// </summary>
public static class Kata
{
    public static bool IsPangram(string str)
    {
        //(first but too many repeated loops)
        //return str.ToLower().ToArray().Where(c => c >= 'a' && c <= 'z').Distinct().Count() == 26;
    
        HashSet<char> unique = new HashSet<char>();
        foreach(char c in str.ToLower())
        {
            if('a' <= c && c <= 'z')
            {
                unique.Add(c);
            }
        }
    
        return unique.Count == 26;
    }
}