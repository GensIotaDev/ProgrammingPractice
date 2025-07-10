namespace Challenges.Kyu4.TopDownMovement;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/59315ad28f0ebeebee000159">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5931665046a506c7df00124a/groups/68652a7ec9a9348e716c4bda">here</see>
/// </summary>
public class PlayerMovement
{
    private static readonly Direction[] Precedence = [Direction.Right, Direction.Left, Direction.Down, Direction.Up]; // low - high
    private List<(Direction dir, int lastSeen)> history = new(4);
    private int stateUID = 0;
    
    public Tile Position { get; private set; }
    public Direction Direction { get; private set; }
    
    public PlayerMovement(int x, int y)
    {
        Position = new Tile(x,y);
    }
      
    public void Update()
    {
        foreach (Direction dir in Precedence)
        {
            var state = Input.GetState(dir);
            int index = history.FindIndex(kv => kv.dir == dir);
            
            switch (state)
            {
                case false when index != -1:
                    history.RemoveAt(index);
                    break;
                case true when index == -1:
                    history.Add((dir, stateUID));
                    break;
                default: continue;
            }
        }

        if (history.Count == 0)
        {
            stateUID = 0;
            return;
        }

        if (history[^1].dir == Direction) Move();
        else
        {
            Direction = history[^1].dir;
        }
    }

    private void Move()
    {
        Position = Direction switch {
            Direction.Up => new Tile(Position.X, Position.Y + 1),
            Direction.Down => new Tile(Position.X, Position.Y - 1),
            Direction.Left => new Tile(Position.X - 1, Position.Y),
            Direction.Right => new Tile(Position.X + 1, Position.Y),
            _ => throw new Exception("Unknown direction")
        };
    }
}

#region Predefined
public enum Direction { Up = 8, Down = 2, Left = 4, Right = 6 }
  
public struct Tile
{
    public int X { get; }
    public int Y { get; }

    public Tile(int x, int y)
    {
        X = x;
        Y = y;
    }
}
  
public static class Input
{
    private static HashSet<Direction> state = new();
    
    // pressed = true, released = false
    public static void Clear() => state.Clear();
    
    public static void Press(Direction direction) => state.Add(direction);
    public static void Release(Direction direction) => state.Remove(direction);
    public static bool GetState(Direction direction) => state.Contains(direction);
}
#endregion