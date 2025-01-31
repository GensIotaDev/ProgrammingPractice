using Challenges.Kyu3.RectangleSumArea;

namespace Tests.Kyu3.RectangleSumArea;

public class SampleTests
{
    public static IEnumerable<object[]> SampleData = new[]
    {
        new object[]
        {
            36,
            new[]{ new [] {3,3,8,5}, new [] {6,3,8,9}, new [] {11,6,14,12} }
        }
    };
    
    [Theory]
    [MemberData(nameof(SampleData))]
    public void VariableRectangles(long expected, int[][] data)
    {
        Assert.Equal(expected, Kata.Calculate(data));
    }
}