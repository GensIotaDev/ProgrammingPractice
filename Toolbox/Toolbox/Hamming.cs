namespace Toolbox;

public static class Hamming
{
    public static int Distance(string from, string to)
    {
        if (from.Length != to.Length) throw new ArgumentException("strings must be of equal length");

        var distance = 0;
        for (var i = 0; i < to.Length; i++)
        {
            if (from[i] != to[i]) distance++;
        }

        return distance;
    }

    public static int Distance(int from, int to)
    {
        return (int)System.Runtime.Intrinsics.X86.Popcnt.PopCount((uint)(from ^ to));
    }
}