namespace Challenges.Kyu4.SquareIntoSquare;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/54eb33e5bc1a25440d000891">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/551cf315d08ea3f1af000471/groups/681bc81d5430a3894c908d13">here</see>
/// </summary>
public class Decompose {
  
    public string decompose(long n) 
    {
        var sequence = new Stack<long>();
        sequence.Push(n);
        long diff = 0;
      
        while(sequence.TryPop(out long i))
        {
            diff += i * i;
            i -= 1;

            while(i > 0)
            {
                var i2 = i * i;
                if(diff - i2 < 0) 
                {
                    i = (long)Math.Sqrt(diff);
                    i2 = i * i;
                }
                if(diff - i2 >= 0)
                {
                    diff -= i2;
                    sequence.Push(i);
                    i -= 1;

                    if(diff == 0) return string.Join(' ', sequence);
                }
            }
        }
        return null;
    }
}