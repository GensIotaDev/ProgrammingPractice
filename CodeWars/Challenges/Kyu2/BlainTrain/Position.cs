namespace Challenges.Kyu2.BlainTrain;

public struct Position(int y, int x) : IEquatable<Position>
{
    public int y = y, x = x;

    public Position Flip()
    {
        (y, x) = (x, y);
        return this;
    }

    public Position With(int y = 0, int x = 0)
    {
        this.y = y;
        this.x = x;
        return this;
    }
    
    public static Position operator +(Position left, Position right)
    {
        return new Position(left.y + right.y, left.x + right.x);
    }
    public static Position operator -(Position left, Position right)
    {
        return new Position(left.y - right.y, left.x - right.x);
    }

    public static Position operator *(int factor, Position right)
    {
        return new Position(factor * right.y, factor * right.x);
    }

    public static Position operator *(Position left, int factor) => factor * left;

    public bool Equals(Position other)
    {
        return y == other.y && x == other.x;
    }

    public override bool Equals(object? obj)
    {
        return obj is Position other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(y, x);
    }

    public static bool operator ==(Position left, Position right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Position left, Position right)
    {
        return !left.Equals(right);
    }
}