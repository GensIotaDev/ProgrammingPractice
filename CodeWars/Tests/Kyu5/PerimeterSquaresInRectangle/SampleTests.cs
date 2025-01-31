using System.Numerics;
using Challenges.Kyu5.PerimeterSquaresInRectangle;

namespace Tests.Kyu5.PerimeterSquaresInRectangle;

public class SampleTests
{
    [Theory]
    [InlineData(5, 80)]
    public void Basic(BigInteger n, BigInteger expected)
    {
        Assert.Equal(expected, SumFct.perimeter(n));
    }
}