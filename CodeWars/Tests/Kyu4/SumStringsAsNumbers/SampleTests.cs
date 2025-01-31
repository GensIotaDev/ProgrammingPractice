using Challenges.Kyu4.SumStringsAsNumbers;

namespace Tests.Kyu4.SumStringsAsNumbers;

public class SampleTests
{
    [Theory]
    [InlineData("123", "456", "579")]
    [InlineData("99", "1", "100")]
    public void Basic(string a, string b, string expected)
    {
        Assert.Equal(expected, Kata.sumStrings(a, b));
    }
}