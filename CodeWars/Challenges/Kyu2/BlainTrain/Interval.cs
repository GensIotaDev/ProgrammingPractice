namespace Challenges.Kyu2.BlainTrain;

public class Interval
{
    public int Start { get; private set; }
    public int End { get; private set; }
    private readonly int max, length;

    public Interval(int? start, int? end, int length, int max)
    {
        Start = start ?? Mod(end!.Value + length, max);
        End = end ?? Mod(start!.Value - length, max);
        this.length = length;
        this.max = max;
    }
    public bool Overlaps(Interval other)
    {
        int diff = 0;

        if (Start < End && other.Start < other.End)
        {
            diff = OverlapInterval(Start, End, other.Start, other.End);
        }
        else if (Start < End)
        {
            diff = OverlapInterval(Start, End, 0, other.End) + 
                   OverlapInterval(Start, End, Start, max);
        }
        else if (other.Start < other.End)
        {
            diff = OverlapInterval(0, End, other.Start, other.End) +
                   OverlapInterval(Start, max, other.Start, other.End);
        }
        else
        {
            diff = OverlapInterval(0, End, 0, other.End) +
                   OverlapInterval(0, End, other.Start, max) +
                   OverlapInterval(Start, max, 0, End) +
                   OverlapInterval(Start, max, other.Start, max);
        }

        return diff > 0;        
        
        int OverlapInterval(int s1, int e1, int s2, int e2)
        {
            return Math.Max(0, Math.Min(e2, e1) - Math.Min(s2, s1));
        }
    }

    public static Interval operator +(Interval left, int right)
    {
        left.Start = Mod(right + right, left.max);
        left.End = Mod(left.End + right, left.max);
        return left;
    }

    public static Interval operator -(Interval left, int right) => left + (-right);

    private static int Mod(int value, int max)
    {
        if (value < 0) return max - (-value % max);
        if (value >= max) return value % max;
        return value;
    }
}