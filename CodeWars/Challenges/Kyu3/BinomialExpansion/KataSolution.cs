using System.Text.RegularExpressions;

namespace Challenges.Kyu3.BinomialExpansion;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/540d0fdd3b6532e5c3000b5b">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5b8aee666dc085b5b90009a9/groups/61297d65be0f050001d0f821">here</see>
/// </summary>
public class KataSolution
{
    public static string Expand(string expr)
    {
        Term root = BuildRootTerm(expr);
    
        return root.Expand().ToString();
    }

    private static Term BuildRootTerm(string expr)
    {
        Console.WriteLine($"** {expr}");
    
        Regex rx = new Regex(@"\((?<a>\-?\d*)(?<x>[a-z])(?<b>[\+|\-]?\d*)?\)\^(?<n>\-?\d+)");
        Match m = rx.Match(expr);

        if (!m.Success) throw new ArgumentException($"expression [{expr}] does not match pattern");

        string variableName = m.Groups["x"].Value;
        //ax+b -> ax^1 + bx^0
        string aStr = m.Groups["a"].Value;
        int a;
        if(aStr.Length == 0)
        {
            a = 1;
        }
        else if(aStr.Length == 1 && aStr[0] == '-')
        {
            a = -1;
        }
        else
        {
            a = int.Parse(aStr);
        }
        Term x1 = new Term(variableName, a, 1);

        int b = (m.Groups["b"].Length > 0) ? int.Parse(m.Groups["b"].Value) : 0;
        Term x0 = new Term(variableName, b, 0);

        //Combined
        int n = (m.Groups["n"].Length > 0) ? int.Parse(m.Groups["n"].Value) : 1;
        Term combined = new Term(variableName, 1, n, new Expression(new Term[] { x1, x0 }));

        return combined;
    }
}