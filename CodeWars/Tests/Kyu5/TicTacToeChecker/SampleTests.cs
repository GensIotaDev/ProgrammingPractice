using Challenges.Kyu5.TicTacToeChecker;

namespace Tests.Kyu5.TicTacToeChecker;

public class SampleTests
{
    public static IEnumerable<object[]> BoardData = new[]
    {
        new object[]
        {
            new [,]
            {
                { 1, 1, 1 },
                { 0, 2, 2 },
                { 0, 0, 0 }
            },
            1
        },
        new object[]
        {
            new [,]
            {
                { 2, 2, 2 },
                { 0, 1, 1 },
                { 1, 0, 0 }
            },
            2
        },
        new object[]
        {
            new [,]
            {
                { 1, 2, 1 },
                { 1, 1, 2 },
                { 2, 2, 0 }
            },
            -1
        }
    };

    [Theory]
    [MemberData(nameof(BoardData))]
    public void TestState(int[,] board, int expected)
    {
        var ticTacToe = new TicTacToe();
        Assert.Equal(expected, ticTacToe.IsSolved(board));
    }
}