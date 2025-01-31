using Challenges.Kyu5.TrafficJam;

namespace Tests.Kyu5.TrafficJam;

public class SampleTests
{
    public static IEnumerable<object[]> TrafficData = new[]
    {
        new object[]
        {
            "abcdefghijklmX",
            new []
                { "", "", "", "BBBBBB", "", "", "", "", "CCCCC" },
            "abcdBeBfBgBhBiBCjCkClCmCX"
        },
        new object[]
        {
            "abcdeXghi",
            new string[]
                { "", "", "CCCCC", "", "EEEEEEEEEE", "FFFFFF", "", "", "IIIIII" },
            "abcCdCeCECX"
        },
        new object[]
        {
            "abcdefX",
            Array.Empty<string>(),
            "abcdefX"
        },
        new object[]
        {
            "abcXdef",
            Array.Empty<string>(),
            "abcX"
        },
        new object[]
        {
            "Xabcdef",
            Array.Empty<string>(),
            "X"
        }
    };

    [Theory]
    [MemberData(nameof(TrafficData))]
    public void Order(string road, string[] streets, string expected)
    {
        Assert.Equal(expected, Dinglemouse.TrafficJam(road, streets));
    }
}