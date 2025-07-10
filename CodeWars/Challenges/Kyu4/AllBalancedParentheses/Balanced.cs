namespace Challenges.Kyu4.AllBalancedParentheses;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5426d7a2c2c7784365000783">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d6ab513476ab30001ddaaab/groups/6825ede8819b01800f4dedfd">here</see>
/// </summary>
public class Balanced
{
    public static List<string> BalancedParens(int n)
    {
        List<string> output = new();
        Recurse(n, 0, "", output);
        return output;    
    }
  
    private static void Recurse(int n, int open, string current, List<string> result)
    {
        if(current.Length == 2 * n)
        {
            result.Add(current);
            return;
        }
      
        if(open < n)
        {
            Recurse(n, open + 1, current + "(", result);
        }
        if(current.Length - open < open)
        {
            Recurse(n, open, current + ")", result);
        }
    }
}