using Challenges.Kyu3.StargatePathing;

namespace Tests.Kyu3.StargatePathing;

public class Tests
{
    public static IEnumerable<object[]> SampleData = new[]
    {
        new object[]
        {
            ".SP..\n" +
            "XXXP.\n" +
            ".XPXX\n" +
            ".PX..\n" +
            "G...X",
            
            ".S...\n" +
            "XXX..\n" +
            ".X.XX\n" +
            "..X..\n" +
            "G...X"
        },
        new object[]
        {
            "...X..X.X.....X..XXXX.GXXX\n" +
            "XX.X.XX..X..X.X..XX.XXXP..\n" +
            "XXXX.X.X.X..X.XXXX.X.XPX.X\n" +
            "XX..XX.X.X.XXXXXXXXX.PX..X\n" +
            "XXXXX.X.X.XXX..X.XXXX.P.XX\n" +
            ".XX.X..XX.X.XX.X.XXXXXPXX.\n" +
            "...XXX.X.XXXXX.XXXX.PPX.XX\n" +
            ".X.XXXXX.X....XXXXPPXXX..X\n" +
            "XXX..X..XX.XXXXXXPXXX..X.X\n" +
            "XX....XX..X.X...PX...X.X.X\n" +
            "..XXX.XXXXX..X.PXX.XXXX.X.\n" +
            "...X..XXXX.X..PX.XXX..XX.X\n" +
            "..XX.XX.XXX.XXXPXXXXXX.X..\n" +
            "XX.XXXXX...X..XPXX...XX...\n" +
            "XX.X.....XXX.XPXX.XX.XX..X\n" +
            ".X...X.XX.XXXPX..X.X.XXX.X\n" +
            "XX.X..XXX.XXXP....XXX.XXX.\n" +
            ".XX.X.XX.XXXP..X.X..XXXXX.\n" +
            "...X.XX.X.X.PXXX..X..X.X.X\n" +
            "XXXXXXX.....PXXX...X...XX.\n" +
            "X..X.XXX..XX.PX.XX..XXXXXX\n" +
            "XXX...XX.X.XXPXXXXXXXX...X\n" +
            "X.X.XXX.X.XX.SX.XXX.XX.XXX\n" +
            "..XXXX..X..XX..X..X....X.X\n" +
            "X..XXX.XXX..X..X.X.X.X..X.\n" +
            "XX.X.X......XX..XX.X.XX..X\n",
            
            "...X..X.X.....X..XXXX.GXXX\n" +
            "XX.X.XX..X..X.X..XX.XXX...\n" +
            "XXXX.X.X.X..X.XXXX.X.X.X.X\n" +
            "XX..XX.X.X.XXXXXXXXX..X..X\n" +
            "XXXXX.X.X.XXX..X.XXXX...XX\n" +
            ".XX.X..XX.X.XX.X.XXXXX.XX.\n" +
            "...XXX.X.XXXXX.XXXX...X.XX\n" +
            ".X.XXXXX.X....XXXX..XXX..X\n" +
            "XXX..X..XX.XXXXXX.XXX..X.X\n" +
            "XX....XX..X.X....X...X.X.X\n" +
            "..XXX.XXXXX..X..XX.XXXX.X.\n" +
            "...X..XXXX.X...X.XXX..XX.X\n" +
            "..XX.XX.XXX.XXX.XXXXXX.X..\n" +
            "XX.XXXXX...X..X.XX...XX...\n" +
            "XX.X.....XXX.X.XX.XX.XX..X\n" +
            ".X...X.XX.XXX.X..X.X.XXX.X\n" +
            "XX.X..XXX.XXX.....XXX.XXX.\n" +
            ".XX.X.XX.XXX...X.X..XXXXX.\n" +
            "...X.XX.X.X..XXX..X..X.X.X\n" +
            "XXXXXXX......XXX...X...XX.\n" +
            "X..X.XXX..XX..X.XX..XXXXXX\n" +
            "XXX...XX.X.XX.XXXXXXXX...X\n" +
            "X.X.XXX.X.XX.SX.XXX.XX.XXX\n" +
            "..XXXX..X..XX..X..X....X.X\n" +
            "X..XXX.XXX..X..X.X.X.X..X.\n" +
            "XX.X.X......XX..XX.X.XX..X\n"
        }
    };
    
    [Theory]
    [MemberData(nameof(SampleData))]
    public void Simple(string expected, string input)
    {
        Assert.Equal(expected, SG1.WireDHD(input));
    }
}