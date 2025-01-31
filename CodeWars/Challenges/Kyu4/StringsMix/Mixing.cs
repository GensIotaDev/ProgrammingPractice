namespace Challenges.Kyu4.StringsMix;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5629db57620258aa9d000014">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/562a043b2feabb355a0000cf/groups/61299b4059d83800019c50b4">here</see>
/// </summary>
public class Mixing 
{
    public static string Mix(string s1, string s2)
    {
        Dictionary<char, (int, int)> letterCount = new Dictionary<char, (int, int)>();

        string[] items = new string[] { s1, s2 };
        for(int i = 0; i < 2; i++)
        {
            foreach(char c in items[i])
            {
                if (c < 'a' || c > 'z') continue;

                if(letterCount.TryGetValue(c, out (int, int) counter))
                {
                    if(i == 0)
                    {
                        counter.Item1++;
                    }
                    else
                    {
                        counter.Item2++;
                    }

                    letterCount[c] = counter;
                }
                else
                {
                    (int, int) count = (i == 0) ? (1, 0) : (0, 1);

                    letterCount.Add(c, count);
                }
            }
        }

        //sort
        var ordered = letterCount
            .Select(x =>
            {
                char largest = '=';
                int max = Math.Max(x.Value.Item1, x.Value.Item2);
                if (x.Value.Item1 > x.Value.Item2)
                {
                    largest = '1';
                }
                else if (x.Value.Item1 < x.Value.Item2)
                {
                    largest = '2';
                }

                return (x.Key, max, largest);
            })
            .Where(x => x.max > 1)
            .OrderByDescending(x => x.max)
            .ThenBy(x => x.largest)
            .ThenBy(x => x.Key);

        StringBuilder builder = new StringBuilder();
        foreach(var t in ordered)
        {
            if(builder.Length > 0)
            {
                builder.Append('/');
            }

            //largest input
            builder.Append(t.largest);

            //separator
            builder.Append(":");

            //display all letters
            for(int i = 0; i < t.max; i++)
            {
                builder.Append(t.Key);
            }
        }

        return builder.ToString();
    }
}