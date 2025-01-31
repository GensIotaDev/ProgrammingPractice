using Challenges.Kyu5.NotVerySecure;

namespace Tests.Kyu5.NotVerySecure;

public class SampleTests
{
    public static IEnumerable<object[]> BasicData => new List<object[]>
    {
        new object[]
        {
            "Mazinkaiser",
            true
        },
        new object[]
        {
            "hello world_",
            false
        },
        new object[]
        {
            "PassW0rd",
            true
        },
        new object[]
        {
            "     ",
            false
        }
    };

    [Theory]
    [MemberData(nameof(BasicData))]
    public void Basic(string input, bool expected)
    {
        Assert.Equal(expected, Kata.Alphanumeric(input));
    }
}