using Challenges.Kyu5.Rot13;

namespace Tests.Kyu5.Rot13;

public class SampleTests
{
    [Theory]
    [InlineData("grfg", "test")]
    [InlineData("Grfg", "Test")]
    public void Basic(string expected, string input)
    {
        if (null == expected) input = string.Empty;
        
        Assert.Equal(expected, Kata.Rot13(input));
    }
}