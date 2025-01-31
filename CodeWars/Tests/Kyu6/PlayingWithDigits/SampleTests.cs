using Challenges.Kyu6.PlayingWithDigits;

namespace Tests.Kyu6.PlayingWithDigits;

public class SampleTests
{
    [Theory]
    [InlineData(89, 1, 1)]
    [InlineData(695, 2, 2)]
    [InlineData(46288, 3, 51)]
    public void HasKProperty(int n, int p, long expected)
    {
        Assert.Equal(expected, DigPow.digPow(n, p));
    }

    [Theory]
    [InlineData(92, 1)]
    public void DoesNotHaveKProperty(int n, int p)
    {
        Assert.Equal(-1L, DigPow.digPow(n, p));
    }
}