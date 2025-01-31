using System.Text.RegularExpressions;

namespace Challenges.Kyu4.FindUnknownDigit;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/546d15cebed2e10334000ed9">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/57b9f3475b446cbca8000126/groups/64d42b471c11db00019c5dd3">here</see>
/// </summary>
public class Runes
{
    private static readonly Regex Pattern = new Regex(@"(-?[\d\?]*)([-+*])(-?[\d\?]*)=(-?[\d\?]*)");
  
    public static int solveExpression(string expression)
    {
        var match = Pattern.Match(expression);
        var fragments = new Fragment[3];

        Func<Fragment,Fragment,int,int> op = match.Groups[2].Value switch
        {
            "+" => (l, r, value) => l.Encode(value) + r.Encode(value),
            "-" => (l, r, value) => l.Encode(value) - r.Encode(value),
            "*" => (l, r, value) => l.Encode(value) * r.Encode(value),
            _ => throw new NotImplementedException("Unknown operator")
        };
        fragments[0] = new Fragment(match.Groups[1].Value);
        fragments[1] = new Fragment(match.Groups[3].Value);
        fragments[2] = new Fragment(match.Groups[4].Value);

        // determine not used digits
        var mask = fragments.Aggregate(0b_1_111_111_111, (current, frag) => current & ~frag.Flags);

        for (var i = 0; i < 10; i++)
        {
            // skip if digit exists within expression
            if (((mask >> i) & 1) == 0) continue; 

            // can't have leading zeros
            if(i == 0 && fragments.Any(f => f.Flags >= Fragment.LeadingMask)) continue;

            if (op(fragments[0], fragments[1], i) == fragments[2].Encode(i)) return i;
        }
    
        return -1;
    }
}