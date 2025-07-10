using System.Numerics;

namespace Challenges.Kyu3.BooleanOrderSolution;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/59eb1e4a0863c7ff7e000008">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d7491922319a900012c9ce0/groups/6814443e63ee5ac6edd802da">here</see>
/// </summary>
public class BooleanOrder
{
    private record struct Segment(int start, int end)
    {
        public int start = start, end = end;
        public int Length => (end - start) + 1;

        public static Segment operator +(Segment left, Segment right)
        {
            if (left.end != right.start - 1 || right.end != left.start - 1) throw new Exception("Segments must be contiguous.");
            return new Segment(Math.Min(left.start, right.start), Math.Max(left.end, right.end));
        }
    }

    private record struct TruthTable(BigInteger @true, BigInteger @false)
    {
        public BigInteger amountTrue = @true, amountFalse = @false;
        public BigInteger Total => amountTrue + amountFalse;

        public static TruthTable operator |(TruthTable left, TruthTable right)
        {
            return new TruthTable(
                left.amountTrue * right.Total + left.amountFalse * right.amountTrue,
                left.amountFalse * right.amountFalse
            );
        }
        public static TruthTable operator &(TruthTable left, TruthTable right)
        {
            return new TruthTable(
                left.amountTrue * right.amountTrue,
                left.amountFalse * right.Total + left.amountTrue * right.amountFalse
            );
        }
        public static TruthTable operator ^(TruthTable left, TruthTable right)
        {
            return new TruthTable(
                left.amountTrue * right.amountFalse + left.amountFalse * right.amountTrue,
                left.amountTrue * right.amountTrue + left.amountFalse * right.amountFalse
            );
        }
        public static TruthTable operator +(TruthTable left, TruthTable right)
        {
            return new TruthTable(left.amountTrue + right.amountTrue, left.amountFalse + right.amountFalse);
        }

        public static TruthTable True => new TruthTable(1, 0);
        public static TruthTable False => new TruthTable(0, 1);
    }

    class BooleanSegment(Segment segment, TruthTable table)
    {
        public Segment Segment { get; init; } = segment;
        public TruthTable Table { get; init; } = table;

        public static BooleanSegment operator |(BooleanSegment left, BooleanSegment right)
        {
            return new BooleanSegment(left.Segment + right.Segment, left.Table | right.Table);
        }
        public static BooleanSegment operator &(BooleanSegment left, BooleanSegment right)
        {
            return new BooleanSegment(left.Segment + right.Segment, left.Table & right.Table);
        }
        public static BooleanSegment operator ^(BooleanSegment left, BooleanSegment right)
        {
            return new BooleanSegment(left.Segment + right.Segment, left.Table ^ right.Table);
        }
    }
    
    private string operands, operators;

    private Dictionary<Segment, BooleanSegment> cache = new(); 
    public BooleanOrder(string operands, string operators)
    {
        this.operands = operands;
        this.operators = operators;
    }

    public BigInteger Solve()
    {
        var table = SolveSegment(new Segment(0, operands.Length - 1));
        
        return table.amountTrue;
    }

    private TruthTable SolveSegment(Segment segment)
    {
        if (segment.Length == 1) return operands[segment.start] == 't' ? TruthTable.True : TruthTable.False;
        if (cache.TryGetValue(segment, out var bs)) return bs.Table;

        TruthTable root = new TruthTable(0, 0);
        for (var i = 0; i < segment.Length - 1; i++)
        {
            var left = segment with { end = segment.start + i };
            var right = segment with {start = segment.start + i + 1};

            var lTable = SolveSegment(left);
            var rTable = SolveSegment(right);

            var table = operators[left.end] switch
            {
                '|' => lTable | rTable,
                '&' => lTable & rTable,
                '^' => lTable ^ rTable
            };
            root += table;
        }

        BooleanSegment ns = new BooleanSegment(segment, root);
        cache.Add(ns.Segment, ns);
        return ns.Table;
    }
}