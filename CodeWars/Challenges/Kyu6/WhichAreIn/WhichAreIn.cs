namespace Challenges.Kyu6.WhichAreIn;

using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/550554fd08b86f84fe000a58">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5535d576d7ec0e8b6d000050/groups/6126f9c73921a5000165d079">here</see>
/// </summary>
class WhichAreIn
{
    public static string[] inArray(string[] array1, string[] array2)
    {
        List<string> contained = new List<string>();
              
        foreach(string s in array1)
        {
            bool isSubstring = false;
            foreach(string s2 in array2)
            {
                if(s2.Contains(s))
                {
                    isSubstring = true;
                    goto QuickExit;
                }
            }
                  
            QuickExit:
            if(isSubstring)
            {
                contained.Add(s);
            }
        }
              
        contained.Sort();
        return contained.ToArray();
    }
}