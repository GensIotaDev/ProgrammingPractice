using Challenges.Kyu4.BlockSequence;

namespace Tests.Kyu4.BlockSequence;

public class SampleTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(100, 1)]
    [InlineData(2100, 2)]
    [InlineData(3100, 2)]
    [InlineData(1000000000000000000, 1)]
    [InlineData(999999999999999993, 7)]
    public void Test(long n, int expected)
    {
        Assert.Equal(expected, BlockSeq.Solve(n));
    }
}