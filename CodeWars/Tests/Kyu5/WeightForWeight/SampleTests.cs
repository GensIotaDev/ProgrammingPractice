using Challenges.Kyu5.WeightForWeight;

namespace Tests.Kyu5.WeightForWeight;

public class SampleTests
{
    [Theory]
    [InlineData("103 123 4444 99 2000", "2000 103 123 4444 99")]
    public void Basic(string input, string expected)
    {
        Assert.Equal(expected, WeightSort.orderWeight(input));
    }
}