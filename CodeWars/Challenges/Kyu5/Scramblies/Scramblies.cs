namespace Challenges.Kyu5.Scramblies;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/55c04b4cc56a697bb0000048">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5684fd62a86c6fc9a100002c/groups/6127d60ec5dc780001707dbc">here</see>
/// </summary>
public class Scramblies 
{
    public static bool Scramble(string str1, string str2) 
    {
        Dictionary<char, int> availableCharacters = new Dictionary<char, int>();
      
        foreach(char c in str1)
        {
            if(availableCharacters.ContainsKey(c))
            {
                availableCharacters[c] = availableCharacters[c] + 1;
            }
            else
            {
                availableCharacters.Add(c, 1);
            }
        }
      
        foreach(char c in str2)
        {
            if(availableCharacters.TryGetValue(c, out int value) && value > 0)
            {
                availableCharacters[c] = value - 1;
            }
            else
            {
                return false;
            }
        }
      
        return true;
    }

}