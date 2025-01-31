using Challenges.Kyu5.MaxiumSubarray;

namespace Tests.Kyu5.MaxiumSubarray;

public class SampleTests
{
    public static IEnumerable<object[]> ArrayData = new[]
    {
        new object[]
        {
            new int[]{-2, 1, -3, 4, -1, 2, 1, -5, 4},
            6
        },
        new object[]
        {
            new []{ 0 },
            0
        }
    };

    [Theory]
    [MemberData(nameof(ArrayData))]
    public void Basic(int[] input, int expected)
    {
        Assert.Equal(expected, Kata.MaxSequence(input));
    }
}