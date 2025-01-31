using Challenges.Kyu5.DirectionsReduction;

namespace Tests.Kyu5.DirectionsReduction;

public class SampleTests
{
    [Fact]
    public void Basic1()
    {
        var expected = new string[] { "WEST" };
        var input = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
        
        Assert.Equal(expected, DirReduction.dirReduc(input));
    }

    [Fact]
    public void Basic2()
    {
        var expected = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
        var input = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
        
        Assert.Equal(expected, DirReduction.dirReduc(input));
    }
}