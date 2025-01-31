namespace Challenges.Kyu4.NextBiggestNumber;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/55983863da40caa2c900004e">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/561a244567692717a300005b/groups/6127c9ebdda294000150b663">here</see>
/// </summary>
public class Kata
{
    public static long NextBiggerNumber(long n)
    {
        string s = n.ToString();
        if(s.Length == 1) return -1; // single digits can't have next biggest
      
        //find digit that is smaller than its immediate right neighbor
        int smallerIndex = -1;
        for(int i = s.Length - 2; i >= 0; i--)
        {
            if(s[i] < s[i + 1])
            {
                smallerIndex = i;
                break;
            }
        }
        if(smallerIndex == -1) return -1; //already in descending order, thus no swaps would create a larger number
      
        //find digit to the right of smallerIndex that is the smallest but still greater than smallerIndex
        int nextSmallest = -1;
        for(int i = s.Length - 1; i > smallerIndex; i--)
        {
            if(s[i] > s[smallerIndex])
            {
                if(nextSmallest == -1 || s[i] < s[nextSmallest])
                {
                    nextSmallest = i;
                }
            }
        }
      
        s = Swap(s, smallerIndex, nextSmallest);
        s = Sort(s, smallerIndex + 1, s.Length - 1);
      
        if(long.TryParse(s, out long value))
        {
            return value;
        }
      
        return -1;// impossible to reach as all operations are on numbers thus TryParse will always be true
    }
  
    private static string Swap(string str, int i, int j)
    {
        char temp;
        char[] array = str.ToCharArray();
      
        temp = array[i];
        array[i] = array[j];
        array[j] = temp;
      
        return new string(array);
    }
    private static string Sort(string str, int i, int j)
    {
        char[] arr = str.ToCharArray();
        char[] toSort = str.Substring(i, j - i + 1).ToCharArray();
      
        Array.Sort(toSort);
        Array.Copy(toSort, 0, arr, i, toSort.Length);
      
        return new string(arr);
    }
}