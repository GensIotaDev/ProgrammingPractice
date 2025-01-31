namespace Challenges.Kyu3.StargatePathing;

public struct Point
{
    public int x, y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Point point) return false;

        return point.x == x && point.y == y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }
}

public struct Cell
{
    public Point parent;
    public double f, g;
}