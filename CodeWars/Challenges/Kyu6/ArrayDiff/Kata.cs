namespace Challenges.Kyu6.ArrayDiff;

using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/523f5d21c841566fde000009">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/59aae2e33490695eae001027/groups/61265595d3028d00016aa66d">here</see>
/// </summary>
public class Kata
{
    public static int[] ArrayDiff(int[] a, int[] b)
    {
        HashSet<int> unique = new HashSet<int>(b);
    
        List<int> diff = new List<int>();
        foreach(int i in a)
        {
            if(!unique.Contains(i))
            {
                diff.Add(i);
            }
        }
    
        return diff.ToArray();
    }
}