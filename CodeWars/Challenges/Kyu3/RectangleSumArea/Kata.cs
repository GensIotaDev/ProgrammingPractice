namespace Challenges.Kyu3.RectangleSumArea;

public struct Point
{
    public int x, y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
public struct Bounds
{
    public Point start, stop;
}

public struct Rect
{
    public Point p1, p2;
    
    public Rect(int x1, int y1, int x2, int y2)
    {
        p1 = new Point(x1, y1);
        p2 = new Point(x2, y2);
    }
}
public static class Kata
{
    public static long Calculate(IEnumerable<int[]> rectangles)
    {
        var rects = rectangles.Select(raw => new Rect(raw[0], raw[1], raw[2], raw[3])).ToList();
        rects.Sort((Rect a, Rect b) =>
        {
            if (a.p2.x < b.p2.x) return -1;
            if (a.p2.x > b.p2.x) return 1;
            if (a.p1.y < b.p1.y) return -1;
            if (a.p1.y > b.p1.y) return 1;
            return 0;
        });

        long area = 0;
        for (var i = 0; i < rects.Count; i++)
        {
            
        }
        
        return area;

        int getNextX()
        {
            for (var i = 0; i < rects.Count; i++)
            {
                
            }

            return 0;
        }

        long AreaOfRange(int start, int end, int width)
        {
            var area = 0L;

            for (var i = start; i < end; i++)
            {
                var i2 = i + 1;
                var yMin = rects[i].p1.y;
                var yMax = rects[i].p2.y;
                while (i2 < end && rects[i2].p1.y < yMax)
                {
                    yMax = rects[i2].p2.y;
                    i2++;
                }

                area += width * (yMax - yMin);
            }
            
            return area;
        }
    }
}