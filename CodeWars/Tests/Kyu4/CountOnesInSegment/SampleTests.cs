using System.Numerics;
using Challenges.Kyu4.CountOnesInSegment;

namespace Tests.Kyu4.CountOnesInSegment;

public class SampleTests
{
    [Theory]
    [InlineData(5, 7, 7)]
    [InlineData(12, 29, 51)]
    [InlineData(1, 200000000000000, 100)]
    [InlineData(145091590060127, 167403729710703, 100)]
    public void Valid(long left, long right, BigInteger expected)
    {
        Assert.Equal(expected, BitCount.CountOnes(left, right));
    }
}