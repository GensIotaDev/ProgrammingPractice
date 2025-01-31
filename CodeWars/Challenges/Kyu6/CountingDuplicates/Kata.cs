namespace Challenges.Kyu6.CountingDuplicates;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/54bf1c2cd5b56cc47f0007a1">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/565b240dd51ad6769100011d/groups/6124c3a294bb6d0001e6f53b">here</see>
/// </summary>
public class Kata
{
    public static int DuplicateCount(string str)
    {
        HashSet<char> unique = new HashSet<char>();
        HashSet<char> repeated = new HashSet<char>();
    
        foreach(char c in str.ToLower())
        {
            if(!unique.Add(c))
            {
                repeated.Add(c);  
            }
        }
    
        return repeated.Count;
    }
}