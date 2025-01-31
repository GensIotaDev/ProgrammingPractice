using Challenges.Kyu5.FirstNonRepeatingChar;

namespace Tests.Kyu5.FirstNonRepeatingChar;

public class SampleTests
{
    public static IEnumerable<object[]> basicData = new[]
    {
        new [] { "a", "a" },
        new [] { "stress", "t" },
        new [] { "moonmen", "e" }
    };

    [Theory]
    [MemberData(nameof(basicData))]
    public void Basic(string input, string expected)
    {
        Assert.Equal(expected, Kata.FirstNonRepeatingLetter(input));
    }
}