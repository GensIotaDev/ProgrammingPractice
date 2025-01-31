using System.Text;

namespace Challenges.Kyu3.BinomialExpansion;

public class Expression
{
    private List<Term> terms;

    public Expression()
    {
        this.terms = new List<Term>();
    }

    public Expression(Term[] terms)
    {
        this.terms = new List<Term>(terms);
    }

    public void Add(Term term)
    {
        this.terms.Add(term);
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        foreach (Term t in terms)
        {
            if (builder.Length == 0)
            {
                builder.Append(t);
            }
            else
            {
                if (t.Coefficient > 0)
                {
                    builder.Append("+");
                }

                builder.Append(t);
            }
        }

        return builder.ToString();
    }

    public static Expression operator *(Expression a, Expression b)
    {
        Dictionary<int, List<Term>> roots = new Dictionary<int, List<Term>>();
        //foil
        for (int i = 0; i < a.terms.Count; i++)
        {
            for (int j = 0; j < b.terms.Count; j++)
            {
                Term t = a.terms[i] * b.terms[j];

                if (roots.TryGetValue(t.Exponent, out List<Term> ls))
                {
                    ls.Add(t);
                }
                else
                {
                    roots.Add(t.Exponent, new List<Term> { t });
                }
            }
        }

        Expression newExpression = new Expression();
        //merge
        foreach (int key in roots.Keys.OrderByDescending(x => x))
        {
            Term aggregate = null;
            foreach (Term t in roots[key])
            {
                if (aggregate is null) aggregate = t;
                else
                {
                    aggregate += t;
                }
            }

            if (aggregate != null && aggregate.Coefficient != 0)
            {
                newExpression.Add(aggregate);
            }
        }

        return newExpression;
    }

    public static Expression operator *(Expression a, Term b)
    {
        Expression bb = new Expression(new Term[] { b });

        return a * bb;
    }
}