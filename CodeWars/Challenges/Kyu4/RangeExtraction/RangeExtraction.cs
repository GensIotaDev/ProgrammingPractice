using System.Text;

namespace Challenges.Kyu4.RangeExtraction;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/51ba717bb08c1cd60f00002f">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5a6fbc0a5c03c84a84000ab8/groups/64cbdb86c4761a0001780e68">here</see>
/// </summary>
public class RangeExtraction
{
    private class Range
    {
        public int start;
        public int? end;
    }
  
    public static string Extract(int[] args)
    {
        if (args.Length == 0) return string.Empty;

        /* Build Ranges */
        var ranges = new Queue<Range>();

        var last = new Range
        {
            start = args[0]
        };
        ranges.Enqueue(last);

        for (var i = 1; i < args.Length; i++)
        {
            var item = args[i];
            if (item == last.start + 1 || (last.end is not null && item == last.end + 1))
            {
                last.end = item;
            }
            else if (last.end is null || item - last.end > 1)
            {
                last = new Range
                {
                    start = item
                };
                ranges.Enqueue(last);
            }
        }

        /* Print Ranges */
        var builder = new StringBuilder();
        foreach (var range in ranges)
        {
            if (builder.Length != 0) builder.Append(',');

            var append = range switch
            {
                { end: null } => range.start.ToString(),
                _ when range.end - range.start == 1 => $"{range.start},{range.end}",
                _ => $"{range.start}-{range.end}"
            };

            builder.Append(append);
        }

        return builder.ToString();
    }
}