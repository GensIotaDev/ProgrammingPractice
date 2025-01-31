namespace Challenges.Kyu6.SplitStrings;

using System;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/515de9ae9dcfc28eb6000001">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/57ce1bfef17ba36b3500006d/groups/61252b4852154e0001fabc03">here</see>
/// </summary>
public class SplitString
{
    public static string[] Solution(string str)
    {
        //truncation
        int groupCount = str.Length / 2;
        int remainder = str.Length - (groupCount * 2);
    
        string[] result = new string[groupCount + remainder];
    
        for(int i = 0; i < result.Length; i++)
        {
            result[i] = str.Substring(i * 2, ((i * 2) + 1 < str.Length)? 2 : 1);
        }
    
        if(remainder != 0)
        {
            result[result.Length - 1] += "_";
        }
    
        return result;
    }
}