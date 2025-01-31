using Challenges.Kyu5.ProductConsecutiveFibNumbers;

namespace Tests.Kyu5.ProductConsecutiveFibNumbers;

public class SimpleTests
{
    [Theory]
    [InlineData(new ulong[]{21, 34, 1}, 714)]
    [InlineData(new ulong[]{34, 55, 0}, 800)]
    [InlineData(new ulong[]{55, 89, 1}, 4895)]
    [InlineData(new ulong[]{89, 144, 0}, 5895)]
    public void Basic(ulong[] expected, ulong input)
    {
        var actual = ProdFib.productFib(input);
        Assert.Equal(expected, actual);
    }
}