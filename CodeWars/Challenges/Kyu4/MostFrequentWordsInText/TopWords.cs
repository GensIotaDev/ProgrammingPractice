namespace Challenges.Kyu4.MostFrequentWordsInText;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/51e056fe544cf36c410000fb">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d617c13344de600012b938e/groups/61273905c759a0000115f4ab">here</see>
/// </summary>
public class TopWords
{
    public static List<string> Top3(string s)
    {
        Dictionary<string, int> uniqueWords = new Dictionary<string, int>();
        
        Regex rx = new Regex(@"((?:[a-zA-Z]+\'*)+)");
        MatchCollection matches = rx.Matches(s);  
      
        foreach(Match m in matches)
        {
            string word = m.Groups[1].Value.ToLower();
            if(uniqueWords.ContainsKey(word))
            {
                uniqueWords[word] += 1;
            }
            else
            {
                uniqueWords.Add(word, 1);
            }
        }
        
        return uniqueWords.OrderByDescending(x => x.Value).Take(3).Select(z => z.Key).ToList();
    }
}