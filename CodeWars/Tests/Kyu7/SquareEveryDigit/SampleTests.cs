using Challenges.Kyu7.SquareEveryDigit;

namespace Tests.Kyu7.SquareEveryDigit;

public class SampleTests
{
    [Theory]
    [InlineData(811181, 9119)]
    [InlineData(0, 0)]
    public void Basic(int expected, int input)
    {
        Assert.Equal(expected, Kata.SquareDigits(input));
    }
    
}