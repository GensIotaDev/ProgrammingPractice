namespace Challenges.Kyu4.HowManyNumbers3;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5877e7d568909e5ff90017e6">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d93b6d6b0ad69000100fd98/groups/62b22ffbe3eaac00010a15f2">here</see>
/// </summary>
class HowManyNumbers
{
    struct StackData
    {
        public long value;
        public int depth;
        public int lastDigit;
    }
  
    public static List<long> FindAll(int sumDigits, int numDigits)
    {
        List<long> results = new List<long>();
        FindAllDeep(sumDigits, new StackData()
        {
            value = 0,
            depth = numDigits,
            lastDigit = 1
        }, results);

        return results.Count == 0 ? new List<long>() : new List<long>(){results.Count, results[0], results[^1]};
    }
  
    private static void FindAllDeep(int sumDigits, StackData data, List<long> results)
    {
        if (data.depth <= 0)
        {
            if (sumDigits == 0)
            {
                results.Add(data.value);
            }

            return;
        }


        for (int i = data.lastDigit; i < 10; i++)
        {
            StackData nData = new StackData()
            {
                depth = data.depth - 1,
                value = (10L * data.value) + i,
                lastDigit = i
            };

            FindAllDeep(sumDigits - i, nData, results);
        }
    }
}