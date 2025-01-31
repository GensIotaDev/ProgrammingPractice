using Challenges.Kyu5.MoveZerosToEnd;

namespace Tests.Kyu5.MoveZerosToEnd;

public class SampleTests
{
    [Fact]
    public void Basic()
    {
        var expected = new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 };
        var input = new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1};
        
        Assert.Equal(expected, Kata.MoveZeroes(input));
    }
}