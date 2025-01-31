namespace Challenges.Kyu4.ParseIntReloaded;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/525c7c5ab6aecef16e0001a5">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d6111b2344de60001df1872/groups/6480e9c3db1cd400011352c9">here</see>
/// </summary>
public class Parser
{
    private static readonly Dictionary<string, int> UniqueValueConverter = new()
    {
        {"zero",      0},
        {"one" ,      1},
        {"two" ,      2},
        {"three",     3},
        {"four",      4},
        {"five",      5},
        {"six",       6},
        {"seven",     7},
        {"eight",     8},
        {"nine",      9},
        {"ten",      10},
        {"eleven",   11},
        {"twelve",   12},
        {"thirteen", 13},
        {"fourteen", 14},
        {"fifteen",  15},
        {"sixteen",  16},
        {"seventeen",17},
        {"eighteen", 18},
        {"nineteen", 19},
        {"twenty",   20},
        {"thirty",   30},
        {"forty",    40},
        {"fifty",    50},
        {"sixty",    60},
        {"seventy",  70},
        {"eighty",   80},
        {"ninety",   90}
    };

    private static readonly Dictionary<string, (int value, bool hold)> MultiplierConverter = new()
    {
        {"hundred",  (100, true)},
        {"thousand", (1000, false)},
        {"million", (1000000, false)}
    };
  
    public static int ParseInt(string s)
    {
        var total = 0;
        var temp = 0;
        
        foreach (var part in s.Split(' ', '-'))
        {
            if(part == "and") continue;

            if (UniqueValueConverter.TryGetValue(part, out var value))
            {
                temp += value;
            }
            else if (MultiplierConverter.TryGetValue(part, out var multiplier))
            {
                if (multiplier.hold)
                {
                    temp *= multiplier.value;
                }
                else
                {
                    total += temp * multiplier.value;
                    temp = 0;
                }
            }
        }
        
        return total + temp;
    }
}