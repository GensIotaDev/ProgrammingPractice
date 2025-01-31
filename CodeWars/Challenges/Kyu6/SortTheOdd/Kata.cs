namespace Challenges.Kyu6.SortTheOdd;

using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/578aa45ee9fd15ff4600090d">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/57ce1ccdf17ba36b35000097/groups/6126fca7e0c68200017d4d3c">here</see>
/// </summary>
public class Kata
{
    public static int[] SortArray(int[] array)
    {
    
        List<int> oddValues = new List<int>();
        List<int> oddIndexes = new List<int>();
    
        for(int i = 0; i < array.Length; i++)
        {
            int v = array[i];
            if(v % 2 == 1)
            {
                oddValues.Add(v);
                oddIndexes.Add(i);
            }
        }
    
        oddValues.Sort();
    
        for(int i = 0; i < oddIndexes.Count; i++)
        {
            array[oddIndexes[i]] = oddValues[i];
        }
    
        return array;
    }
}