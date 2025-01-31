using Challenges.Kyu7.VowelCount;

namespace Tests.Kyu7.VowelCount;

public class SampleTests
{
    [Fact]
    public void Basic()
    {
        Assert.Equal(5, Kata.GetVowelCount("abracadabra"));
    }
}