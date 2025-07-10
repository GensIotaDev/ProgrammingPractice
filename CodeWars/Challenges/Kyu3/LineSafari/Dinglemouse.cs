namespace Challenges.Kyu3.LineSafari;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/59c5d0b0a25c8c99ca000237">Kata</see>
/// Submission - WIP
/// </summary>
public class Dinglemouse
{
    struct Position : IEquatable<Position>
    {
        public int y;
        public int x;

        public Position(int x, int y)
        {
            this.x = x;
            this.y= y;
        }
        
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
            return 137 * y + x;
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

    public static bool Line(char[][] grid)
    {
        //does not verify that all cells are 'connected'
        if (!TryGatherMeta(grid, out Position[] endpoints, out int cellCount)) return false;

        
        
        return TryWalk(grid, endpoints[0]);
    }

    private static bool TryGatherMeta(char[][] grid, out Position[] endpoints, out int cellCount)
    {
        cellCount = 0;
        endpoints = new Position[2];
        int endpointCount = 0;
        
        for (ushort y = 0; y < grid.GetLength(0); y++)
        {
            for (ushort x = 0; x < grid[y].Length; x++)
            {
                var c = grid[y][x];
                switch (c)
                {
                    case ' ':
                        continue;
                    case 'X' when endpointCount >= 2:
                        return false;
                    case 'X':
                        endpoints[endpointCount++] = new Position(x, y);
                        break;
                }

                cellCount++;
            }
        }

        return endpointCount == 2;
    }
    
    private static bool TryWalk(char[][] grid, Position pos)
    {
        Queue<(Position start, Position next)> history = new();
        EnqueueX(pos, grid, history);
        
        bool isPathing = true;
        char prev = '\0';

        Position cur, pre;
        while (history.Count > 0)
        {
            
        }

        throw new NotImplementedException();
    }

    private static void EnqueueX(Position pos, char[][] grid, Queue<(Position start, Position next)> queue)
    {
        if (pos.y > 0 && grid[pos.y - 1][pos.x] is '|' or '+') queue.Enqueue((pos, new Position(pos.x, pos.y - 1)));
        if (pos.y < grid.GetLength(0) - 1 && grid[pos.y + 1][pos.x] is '|' or '+') queue.Enqueue((pos, new Position(pos.x, pos.y + 1)));
        if (pos.x > 0 && grid[pos.y][pos.x - 1] is '-' or '+') queue.Enqueue((pos, new Position(pos.x - 1, pos.y)));
        if (pos.x < grid[pos.y].Length - 1 && grid[pos.y][pos.x + 1] is '-' or '+') queue.Enqueue((pos, new Position(pos.x + 1, pos.y)));
    }
}