using Kata = Challenges.Kyu4.RangeExtraction; 

namespace Tests.Kyu4.RangeExtraction;

public class SampleTests
{
    public static IEnumerable<object[]> RangeData = new[]
    {
        new object[]
        {
            new [] { 1, 2 },
            "1,2"
        },
        new object[]
        {
            new [] { 1, 2, 3 },
            "1-3"
        },
        new object[]
        {
            new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 },
            "-6,-3-1,3-5,7-11,14,15,17-20"
        },
        new object[]
        {
            new[] { -3, -2, -1, 2, 10, 15, 16, 18, 19, 20 },
            "-3--1,2,10,15,16,18-20"
        }
    };

    [Theory]
    [MemberData(nameof(RangeData))]
    public void Basic(int[] input, string expected)
    {
        Assert.Equal(expected, Kata.RangeExtraction.Extract(input));
    }
}