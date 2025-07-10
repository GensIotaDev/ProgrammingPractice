using System.Collections;

namespace Challenges.Kyu2.RegexParser;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5470c635304c127cad000f0d">Kata</see>
/// Submission - WIP
/// </summary>
public class Reg
{
    public class Exp{}

    public static Exp normal(char c) => new Exp();
    public static Exp any() => new Exp();
    public static Exp zeroOrMore(Exp starred)=> new Exp();
    public static Exp or(Exp left, Exp right)=> new Exp();
    public static Exp str(Exp first)=> new Exp();
    public static Exp add(Exp str, Exp next)=> new Exp();
}

public class RegExpParser
{
    private static readonly char[] Operators = ['*', '|', '(', ')'];
    
    public static Reg.Exp parse(string input)
    {
        var seq = new Stack<char>();
        var operands = new Stack<Reg.Exp>();
        var operators = new Stack<char>();

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];
            switch (c)
            {
                case '(':
                    operators.Push(c);
                    break;
                case ')':
                    if (!ResolveSubExpression()) return null;
                    
                    break;
                case '|' when operators.TryPeek(out var op1) && op1 == '|':
                    return null;
                case '|':
                    if (!ResolveSequence(out var exp1)) return null;
                    operands.Push(exp1!);
                    operators.Push(c);
                    break;
            }
        }

        return null;

        bool ResolveSequence(out Reg.Exp? exp)
        {
            exp = null;
            while (seq.TryPop(out var c))
            {
                Reg.Exp? next = null;
                switch (c)
                {
                    case '*' when seq.TryPop(out var c2) && c2 != '*':
                        next = Reg.zeroOrMore(c2 == '.'? Reg.any() : Reg.normal(c2));
                        break;
                    case '*':
                        exp = null;
                        return false;
                    case '.':
                        next = Reg.any();
                        break;
                    default:
                        next = Reg.normal(c);
                        break;
                }

                if (seq.Count == 0 && exp != null)
                {
                    next = Reg.str(next);
                }

                exp = (exp is null) ? next : Reg.add(next, exp);
            }

            return exp != null;
        }

        bool ResolveSubExpression()
        {
            while (operators.TryPop(out var op))
            {
                switch (op)
                {
                    case '(':
                        break;
                    case '|' when operands.Count >= 2:
                        break;
                }
            }

            return false;
        }
    }
}