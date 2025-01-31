namespace Challenges.Kyu4.SumIntervals;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/52b7ed099cdc285c300001cd">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d616f61addcfc00010e8bc9/groups/61288862be0f050001d0dde5">here</see>
/// </summary>
public class Intervals
{
    public static int SumIntervals((int, int)[] intervals)
    {
        //order by minimum to find overlaps
        Array.Sort<(int,int)>(intervals, delegate((int, int) x, (int, int) y) { return x.Item1.CompareTo(y.Item1);});
        LinkedList<(int,int)> mutableIntervals = new LinkedList<(int, int)>(intervals);
        
        //Merge overlaps
        var node = mutableIntervals.First;
        while(node != null && node.Next != null)
        {
            var r1 = node.Value;
            var r2 = node.Next.Value;
          
            //remove overlapped interval and dont move index forward 
            //due to possible current + next overlap as well
            if(r1.Item1 <= r2.Item1 && r1.Item2 >= r2.Item1 ) //left overlap
            {
                r1.Item2 = Math.Max(r1.Item2, r2.Item2);
                node.Value = r1;
                mutableIntervals.Remove(node.Next);
            }
            else
            {
                node = node.Next;
            }
        }
        
        int sum = 0;
        foreach(var i in mutableIntervals)
        {
            sum += i.Item2 - i.Item1;
        }
      
        return sum;
    }
}