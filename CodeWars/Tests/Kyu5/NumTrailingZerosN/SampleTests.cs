using Challenges.Kyu5.NumTrailingZerosN;

namespace Tests.Kyu5.NumTrailingZerosN;

public class SampleTests
{
    [Theory]
    [InlineData(5, 1)]
    [InlineData(25, 6)]
    [InlineData(531, 131)]
    public void Basic(int input, int expected)
    {
        Assert.Equal(expected, Kata.TrailingZeros(input));
    }
}