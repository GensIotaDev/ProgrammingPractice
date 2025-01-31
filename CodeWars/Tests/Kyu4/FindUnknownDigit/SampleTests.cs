using Challenges.Kyu4.FindUnknownDigit;

namespace Tests.Kyu4.FindUnknownDigit;

public class SampleTests
{
    [Theory]
    [InlineData("1+1=?", 2)]
    [InlineData("123*45?=5?088", 6)]
    [InlineData("-5?*-1=5?", 0)]
    [InlineData("19--45=5?", -1)]
    [InlineData("??*??=302?", 5)]
    [InlineData("?*11=??", 2)]
    [InlineData("??*1=??", 2)]
    [InlineData("??+??=??", -1)]
    [InlineData("123?45*?=?", 0)]
    [InlineData("??605*-63=-73???5", 1)]
    public void Basic(string expression, int expected)
    {
        Assert.Equal(expected, Runes.solveExpression(expression));
    }
}