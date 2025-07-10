namespace Challenges.Kyu2.BlainTrain;

public class Track
{
    public int Length { get; init; }
    public HashSet<int> Stations { get; init; }
    public SortedList<int,int> Crossings { get; init; }
    
    private Track(int length, HashSet<int> stations, SortedList<int,int> crossings)
    {
        Length = length;
        Stations = stations;
        Crossings = crossings;
    }

    #region Factory
    enum Direction
    {
        North = 0,
        East = 2,
        South = 4,
        West = 6,
        NorthEast = 1,
        SouthEast = 3,
        SouthWest = 5,
        NorthWest = 7
    }
    
    //(cell, heading) -> [outgoing directions]
    private static readonly Dictionary<(char, Direction), Direction[]> States = new ()
    {
        {('-', Direction.East), [Direction.East] },
        {('-', Direction.West), [Direction.West] },
        {('|', Direction.North), [Direction.North] },
        {('|', Direction.South), [Direction.South] },
        {('+', Direction.East), [Direction.East] },
        {('+', Direction.West), [Direction.West] },
        {('+', Direction.North), [Direction.North] },
        {('+', Direction.South), [Direction.South] },
        {('X', Direction.NorthWest), [Direction.NorthWest]},
        {('X', Direction.SouthEast), [Direction.SouthEast]},
        {('X', Direction.NorthEast), [Direction.NorthEast]},
        {('X', Direction.SouthWest), [Direction.SouthWest]},
        {('/', Direction.North), [Direction.NorthEast, Direction.East] },
        {('/', Direction.South), [Direction.SouthWest, Direction.West] },
        {('/', Direction.East), [Direction.NorthEast, Direction.North] },
        {('/', Direction.West), [Direction.SouthWest, Direction.South] },
        {('/', Direction.NorthEast), [Direction.NorthEast, Direction.North, Direction.East] },
        {('/', Direction.SouthWest), [Direction.SouthWest, Direction.South, Direction.West] },
        {('\\', Direction.North), [Direction.NorthWest, Direction.West] },
        {('\\', Direction.South), [Direction.SouthEast, Direction.East] },
        {('\\', Direction.East), [Direction.SouthEast, Direction.South] },
        {('\\', Direction.West), [Direction.NorthWest, Direction.North] },
        {('\\', Direction.NorthWest), [Direction.NorthWest, Direction.North, Direction.West] },
        {('\\', Direction.SouthEast), [Direction.SouthEast, Direction.South, Direction.East] },
        {('S', Direction.North), [Direction.North]},
        {('S', Direction.South), [Direction.South]},
        {('S', Direction.East), [Direction.East]},
        {('S', Direction.West), [Direction.West]},
        {('S', Direction.NorthEast), [Direction.NorthEast]},
        {('S', Direction.SouthWest), [Direction.SouthWest]},
        {('S', Direction.SouthEast), [Direction.SouthEast]},
        {('S', Direction.NorthWest), [Direction.NorthWest]},
    };

    private static readonly Position[] DirectionOffset =
    [
        new (-1, 0),
        new (-1,1),
        new (0, 1),
        new (1, 1),
        new (1,0),
        new (1, -1),
        new (0, -1),
        new (-1, -1)
    ];
    
    public static Track Build(string track)
    {
        string[] rows = track.Split('\n');
        int startX = FindStart(rows[0]);
        Position start = new(0, startX), current = new (0, startX + 1);
        Direction curDir = Direction.East;
        int pathLen = 1;

        Dictionary<Position, (char type, List<int> cells)> poi = new();
        
        do
        {
            char[] r = rows[current.y].ToCharArray();
            char cell = rows[current.y][current.x];
            
            switch (cell)
            {
                case '+' or 'X' or 'S':
                    if (!poi.TryGetValue(current, out var p))
                    {
                        poi.Add(current, (cell, [pathLen]));
                    }
                    p.cells.Add(pathLen);
                    break;
            }

            var options = States[(cell, curDir)];
            for (var i = 0; i < options.Length; i++)
            {
                var dir = DirectionOffset[(int)options[i]];
                var next = current + dir;
                if (next.y >= 0 && next.y < rows.GetLength(0) && next.x >= 0 && next.x < rows[next.y].Length && rows[next.y][next.x] != ' ')
                {
                    current = next;
                    curDir = options[i];
                    break;
                }
            }
            pathLen++;
        } while (current != start);

        HashSet<int> stations = new();
        SortedList<int, int> crossings = new();

        foreach (var (type, cells) in poi.Values)
        {
            if (type == 'S')
            {
                stations.Add(cells[0]);
                if (cells.Count == 2) stations.Add(cells[1]);
            }
            
            if (cells.Count == 2)
            {
                crossings.Add(cells[0], cells[1]);
                crossings.Add(cells[1], cells[0]);
            }
        }
        
        return new Track(pathLen, stations, crossings);
    }
    private static int FindStart(string row)
    {
        for (var i = 0; i < row.Length; i++)
        {
            if (row[i] != ' ') return i;
        }

        return -1;
    }
    #endregion
}