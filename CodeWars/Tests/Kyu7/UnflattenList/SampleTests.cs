using Challenges.Kyu7.UnflattenList;

namespace Tests.Kyu7.UnflattenList;

public class SampleTests
{
    public static IEnumerable<object[]> ListData = new[]
    {
        new object[]
        {
            new [] { 3, 5, 2, 1},
            new object[] { new int[] {3, 5, 2}, 1}
        },
        new object[]
        {
            new [] { 1, 4, 5, 2, 1, 2, 4, 5, 2, 6, 2, 3, 3 },
            new object[] { 1, new int[] { 4,5,2,1 }, 2, new int[] { 4,5,2,6 }, 2, new int[] { 3, 3 } }
        }
    };

    [Theory]
    [MemberData(nameof(ListData))]
    public void Basic(int[] input, object[] expected)
    {
        Assert.Equal(expected, Kata.Unflatten(input));
    }
}