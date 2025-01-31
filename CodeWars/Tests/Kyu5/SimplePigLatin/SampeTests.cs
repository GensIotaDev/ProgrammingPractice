using Challenges.Kyu5.SimplePigLatin;

namespace Tests.Kyu5.SimplePigLatin;

public class SampleTests
{
    [Theory]
    [InlineData("igPay atinlay siay oolcay", "Pig latin is cool")]
    [InlineData("hisTay siay ymay tringsay", "This is my string")]
    public void Basic(string expected, string input)
    {
        Assert.Equal(expected, Kata.PigIt(input));
    }
}