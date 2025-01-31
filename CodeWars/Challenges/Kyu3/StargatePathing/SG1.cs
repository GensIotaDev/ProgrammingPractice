using System.Text;

namespace Challenges.Kyu3.StargatePathing;

public class SG1
{
    public static string WireDHD(string existingWires)
    {
        char[,] map;
        Point start, dest;
        
        MakeMap();
        return FindPath(out var path) ? path : "Oh for crying out loud...";

        void MakeMap()
        {
            var width = existingWires.IndexOf('\n');
            var height = 0;
            if (width == -1)
            {
                width = existingWires.Length;
                height = 1;
            }
            else
            {
                height = (int)((float)existingWires.Length / (width + 1) + 0.5f);
            }
            
            map = new char[height, width];
            start = new Point();
            dest = new Point();
            
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var c = existingWires[(width + 1) * i + j];
                    map[i, j] = c;

                    if (c == 'S') start = new Point(j, i);
                    else if (c == 'G') dest = new Point(j, i);
                }
            }
        }

        bool FindPath(out string path)
        {
            var openSet = new SortedSet<(double, Point)>(Comparer<(double f, Point)>.Create((a,b)=> a.f.CompareTo(b.f))){ (0.0, start) };
            var closedSet = new HashSet<Point>();
            var weights = new Dictionary<Point, Cell>() { 
            { start, new Cell()
                {
                    f = 0.0,
                    g = 0.0,
                    parent = start
                } 
            } }; 
            
            while (openSet.Count > 0)
            {
                (double f, Point pos) p = openSet.Min;
                openSet.Remove(p);
                closedSet.Add(p.pos);

                foreach ((bool isDiagonal, Point n) in ValidNeighbours(p.pos))
                {
                    if (n.Equals(dest))
                    {
                        var w = weights[p.pos];
                        weights[n] = new Cell
                        {
                            parent = p.pos
                        };

                        path = PrintPath(weights);
                        return true;
                    }

                    if (closedSet.Contains(n)) continue;
                    
                    var g = weights[p.pos].g + ((isDiagonal)? 1.414f : 1f);
                    var h = Math.Sqrt(Math.Pow(dest.y - n.y, 2) + Math.Pow(dest.x - n.x, 1.89));
                    var f = g + h;

                    if (weights.TryGetValue(n, out var w2) && w2.f <= f) continue;
                    
                    openSet.Add((f, n));
                    weights[n] = new Cell
                    {
                        f = f,
                        g = g,
                        parent = p.pos
                    };
                }
            }

            path = string.Empty;
            return false;
        }
        
        IEnumerable<(bool,Point)> ValidNeighbours(Point pos)
        {
            for (var i = -1; i <= 1; i++)
            {
                var y = pos.y + i;
                if (y < 0 || map.GetLength(0) <= y) continue;
                
                for (var j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    var x = pos.x + j;
                    if (x < 0 || map.GetLength(1) <= x || map[y,x] == 'X') continue;

                    var diagonal = i * j != 0;
                    yield return (diagonal,new Point(x, y));
                }
            }
        }

        string PrintPath(Dictionary<Point, Cell> weights)
        {
            var t = dest;
            while (!t.Equals(start))
            {
                if (map[t.y, t.x] == '.') map[t.y, t.x] = 'P';
                var temp = weights[t].parent;
                t = weights[t].parent;
            }

            var sb = new StringBuilder();
            for (var y = 0; y < map.GetLength(0); y++)
            {
                if (y != 0) sb.Append('\n');
                for (var x = 0; x < map.GetLength(1); x++)
                {
                    sb.Append(map[y, x]);
                }
            }

            return sb.ToString();
        }
    }

    /*public static string WireDHD2(string existingWires)
    {
        char[,] map;
        Point start, dest;
        
        MakeMap();
        //return FindPath(out var path) ? path : "Oh for crying out loud...";

        void MakeMap()
        {
            var width = existingWires.IndexOf('\n');
            var height = 0;
            if (width == -1)
            {
                width = existingWires.Length;
                height = 1;
            }
            else
            {
                height = (int)((float)existingWires.Length / (width + 1) + 0.5f);
            }
            
            map = new char[height, width];
            start = new Point();
            dest = new Point();
            
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var c = existingWires[(width + 1) * i + j];
                    map[i, j] = c;

                    if (c == 'S') start = new Point(j, i);
                    else if (c == 'G') dest = new Point(j, i);
                }
            }
        }

        void FindPath()
        {
            
        }
        
        IEnumerable<(bool,Point)> ValidNeighbours(Point pos)
        {
            for (var i = -1; i <= 1; i++)
            {
                var y = pos.y + i;
                if (y < 0 || map.GetLength(0) <= y) continue;
                
                for (var j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    var x = pos.x + j;
                    if (x < 0 || map.GetLength(1) <= x || map[y,x] == 'X') continue;

                    var diagonal = i * j != 0;
                    yield return (diagonal,new Point(x, y));
                }
            }
        }
    }*/
}