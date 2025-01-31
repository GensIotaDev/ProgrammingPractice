namespace Challenges.Kyu5.PickPeaks;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5279f6fe5ab7f447890006a7">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d85f193a48580000198e258/groups/6127778fe1c85b0001ca3846">here</see>
/// </summary>
public class PickPeaks
{
    public static Dictionary<string, List<int>> GetPeaks(int[] arr)
    {
        List<int> pos = new List<int>();
        List<int> peaks = new List<int>();
      
        int plateauPos = -1;
      
        for(int i = 1; i < arr.Length - 1; i++)
        {
            float lSlope = arr[i] - arr[i - 1];
            float rSlope = arr[i + 1] - arr[i];

            if(lSlope > 0)
            {
                plateauPos = -1;
                if(rSlope < 0)
                {
                    pos.Add(i);
                    peaks.Add(arr[i]);
                }
                else if(rSlope == 0)
                {
                    plateauPos = i;
                }
            }
            else if(plateauPos != -1 && rSlope < 0)
            {
                pos.Add(plateauPos);
                peaks.Add(arr[plateauPos]);
            
                plateauPos = -1;
            }
        }
        
        return new Dictionary<string, List<int>>()
        {
            {"pos", pos},
            {"peaks", peaks}
        };
    }
}