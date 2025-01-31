namespace Challenges.Kyu4.AddingBigNumbers;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/525f4206b73515bffb000b21">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/567ed1c753de3bdc8b0000bc/groups/6127efecf54af00001f74197">here</see>
/// </summary>
public class Kata
{
    public static string Add(string a, string b)
    {
        int carryOver = 0;
    
        int aIdx = a.Length - 1;
        int bIdx = b.Length - 1;
    
        List<char> answer = new List<char>();
        while(true)
        {
            int aValue = (aIdx >= 0)? a[aIdx] - '0' : 0;
            int bValue = (bIdx >= 0)? b[bIdx] - '0' : 0;
      
            int ans = carryOver + aValue + bValue;
      
            carryOver = ans / 10;
            answer.Add((char)((ans % 10) + '0'));
      
            aIdx--;
            bIdx--;
            if(aIdx < 0 && bIdx < 0 && carryOver == 0)
            {
                break;
            }
        }
    
        answer.Reverse();
    
        return new string(answer.ToArray());
    }
}