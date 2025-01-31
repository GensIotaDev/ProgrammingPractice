namespace Challenges.Kyu4.TwiceLinear;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5672682212c8ecf83e000050">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/56726d3ce3659e3f8a00001f/groups/62b82cf226297d0001e9e9d1">here</see>
/// </summary>
public class DoubleLinear 
{
    public static int DblLinear (int n) 
    {
        SortedSet<int> values = new SortedSet<int>(){1};
        PriorityQueue<int, int> next = new();
        next.Enqueue(1, 1);
        
        while (values.Count <= 1.2 * n) //magic minimum viable cutoff to prevent overcalculation
        {
            int x = next.Dequeue();

            int y = 2 * x + 1;
            int z = 3 * x + 1;

            values.Add(y);
            values.Add(z);
            
            next.Enqueue(y, y);
            next.Enqueue(z, z);
        }
        
        return values.ElementAt(n);
    }
}