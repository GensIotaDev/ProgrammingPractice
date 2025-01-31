using Challenges.Kyu4.ParseIntReloaded;

namespace Tests.Kyu4.ParseIntReloaded;

public class SimpleTests
{
    [Theory]
    [InlineData("one", 1)]
    [InlineData("twenty", 20)]
    [InlineData("two hundred forty-six", 246)]
    [InlineData("six hundred sixty-six thousand six hundred sixty-six", 666666)]
    [InlineData("two hundred and sixty-four thousand two hundred ninety-one", 264291)]
    public void Basic(string input, int expected)
    {
        Assert.Equal(expected, Parser.ParseInt(input));
    }
}