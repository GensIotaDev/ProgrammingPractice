using System.Numerics;

namespace Challenges.Kyu4.BlockSequence;

public class BlockSeq
{
    public struct DigitInfo(long start, long end, long accumulator, long total)
    {
        public long start = start, end = end;
        public long accumulator = accumulator, total = total;
    }


    private static readonly DigitInfo[] Zones = new DigitInfo[20];
    static BlockSeq()
    {
        GenerateInfo();
    } 
    
    public static int Solve(long n)
    {
        int zoneId = Array.FindIndex(Zones, zone => n <= zone.total);

        var prev = Zones[zoneId - 1];
        var zone = Zones[zoneId];

        long end = zone.end;
        while (true)
        {
            long halfEnd = (end - zone.start) / 2;
            long total = Sum(zoneId, zone.start, halfEnd, prev.accumulator, prev.total);
        }

        
        
        
        
        
        
        return 0;
    }

    private static int FindZone(long n)
    {
        return 0;
    }

    private static long FindBlock(long n, int digit)
    {
        DigitInfo zone = Zones[digit], prev = Zones[digit - 1];

        throw new NotImplementedException();
        //var y = n - prev.total;
        
        //return x;
    }
    
    private static void GenerateInfo()
    {
        var prev = new DigitInfo(0, 0,0,0);
        Zones[0] = prev;
        for (var i = 1; i < Zones.Length; i++)
        {
            long start = prev.end + 1;
            long end = (10 * prev.end) + 9;

            var count = end - prev.end;
            
            long diff = (long)((0.5 * i) * (count * (count + 1)));
            long total = (prev.accumulator * count) + diff + prev.total; 
            
            Zones[i] = new DigitInfo(prev.end + 1, end, prev.accumulator + (i * count), total);
            prev = Zones[i];
        }
    }

    private static long Sum(int digits, long start, long end, long accumulator, long total)
    {
        var count = end - start;
        var diff = (long)((0.5 * digits) * (count * (count + 1)));
        return accumulator * count + diff + total;
    }
}