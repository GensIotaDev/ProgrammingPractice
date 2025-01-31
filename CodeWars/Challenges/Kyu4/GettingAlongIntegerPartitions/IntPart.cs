namespace Challenges.Kyu4.GettingAlongIntegerPartitions;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/55cf3b567fc0e02b0b00000b">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/55cf558339cb89ab2e000007/groups/633745ea937caf0001f5143a">here</see>
/// </summary>
public class IntPart 
{
  
    private const string OutputFormat = "Range: {0} Average: {1:0.00} Median: {2:0.00}";
  
    private static List<long[]> UniqueParts = new()
    {
        new []{ 1L }
    };
  
    public static string Part(long n)
    {
        var set = DiscoverUniquePart(n).ToArray();

        // 1 is always in the array as lowest. Just hardcode.
        var range = set[^1] - 1;

        var mid = set.Length / 2;
        var median = ((set.Length & 1) == 1) ? set[mid] : (set[mid] + set[mid - 1]) / 2.0;

        var average = set.Average();

        return string.Format(OutputFormat, range, average, median);
    }
  
    private static IEnumerable<long> DiscoverUniquePart(long n)
    {
        SortedSet<long> complete = new();

        for (var i = 0; i < n; i++)
        {
            if (i < UniqueParts.Count)
            {
                var uniqueSet = UniqueParts[i];
                complete.UnionWith(uniqueSet);
            }
            else
            {
                var subN = i + 1;

                var mid = (subN / 2) + 1;

                SortedSet<long> subNSet = new();
                for (var right = 2; right < mid; right++)
                {
                    var left = subN - right;

                    var leftSet = UniqueParts[left - 1];
                    var nLeftSet = leftSet.Select(a => a * right);

                    subNSet.UnionWith(nLeftSet);
                }

                subNSet.ExceptWith(complete); //find unique from previous levels
                subNSet.Add(subN); //include self to simplify product mapping

                complete.UnionWith(subNSet);

                //for memoization
                UniqueParts.Add(subNSet.ToArray());
            }
        }

        return complete;
    }
}