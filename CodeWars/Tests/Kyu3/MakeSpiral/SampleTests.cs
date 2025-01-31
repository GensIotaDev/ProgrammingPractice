using Challenges.Kyu3.MakeSpiral;

namespace Tests.Kyu3.MakeSpiral;

public class SampleTests
{
    public static IEnumerable<object[]> BasicData => new List<object[]>
    {
        new object[]
        {
            5,
            new int[,]
            {
                {1, 1, 1, 1, 1},
                {0, 0, 0, 0, 1},
                {1, 1, 1, 0, 1},
                {1, 0, 0, 0, 1},
                {1, 1, 1, 1, 1}
            }
        },
        new object[]
        {
            8,
            new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1, 1},
                {0, 0, 0, 0, 0, 0, 0, 1},
                {1, 1, 1, 1, 1, 1, 0, 1},
                {1, 0, 0, 0, 0, 1, 0, 1},
                {1, 0, 1, 0, 0, 1, 0, 1},
                {1, 0, 1, 1, 1, 1, 0, 1},
                {1, 0, 0, 0, 0, 0, 0, 1},
                {1, 1, 1, 1, 1, 1, 1, 1}
            }
        }
    };

    [Theory]
    [MemberData(nameof(BasicData))]
    public void Basic(int input, int[,] expected)
    {
        Assert.Equal(expected, Spiralizor.Spiralize(input));
    }
}