namespace Challenges.Kyu2.BlainTrain;
public class Train
{
    public int Start => clockwise ? position.Start : position.End;
    private Interval position;
    public bool IsExpress { get; init; }
    private bool clockwise;
    private int length, waiting = 0;
    private Track track;
    
    public Train(string layout, int start, Track track)
    {
        clockwise = !char.IsAsciiLetterUpper(layout[0]);
        length = layout.Length;
        position = clockwise ? new Interval(start, null, length, track.Length) : new Interval(null, start, length, track.Length);
        
        IsExpress = layout[0] is 'x' or 'X';
        this.track = track;
    }
    
    public void Tick()
    {
        if (waiting > 0)
        {
            waiting -= 1;
            return;
        }

        position += clockwise ? 1 : -1;
        
        if (!IsExpress && track.Stations.Contains(position.Start)) Wait();
    }

    public bool HasCollision(Train other)
    {
        if (this == other)
        {
            var keys = track.Crossings.Keys.ToList();
            var values = track.Crossings.Values.ToList();
            
            var s = keys.BinarySearch(position.Start);
            var e = keys.BinarySearch(position.End);

            if (position.Start < position.End)
            {
                if (s == e) return false;
                
                s = s >= 0 ? s : ~s;
                e = e >= 0 ? e : ~e - 1;

                var sitting = new HashSet<int>(keys[s..e]);
                var potential = new HashSet<int>(values[s..e]);

                return sitting.Union(potential).Any();
            }
            else
            {
                
            }

            //get POI from track over interval, if any cell has duplicate positions, return true; 
        }
        if (position.Overlaps(other.position)) return true;
        return false;
    } 

    private void Wait()
    {
        waiting = length;
    }

    private void OnCrossings()
    {
        var keys = track.Crossings.Keys.ToList();
        var values = track.Crossings.Values.ToList();
            
        var s = keys.BinarySearch(position.Start);
        var e = keys.BinarySearch(position.End);

        if (position.Start < position.End)
        {
            if (s == e) return;// false;
                
            s = s >= 0 ? s : ~s;
            e = e >= 0 ? e : ~e - 1;

            var sitting = new HashSet<int>(keys[s..e]);
            var potential = new HashSet<int>(values[s..e]);

            return;// sitting.Union(potential).Any();
        }
        else
        {
            
        }
    } 
}