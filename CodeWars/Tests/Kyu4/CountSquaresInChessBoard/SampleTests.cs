using Challenges.Kyu4.CountSquaresInChessBoard;

namespace Tests.Kyu4.CountSquaresInChessBoard;

public class SampleTests
{
    public static IEnumerable<object[]> BoardData = new List<object[]>
    {
        new object[]
        {
            new int[][]
            {
                [1,1],
                [1,1]
            },
            new Dictionary<int,int>{ [2] = 1 }
        },
        new object[]
        {
            new int[][]
            {
                [0,1],
                [1,1]
            },
            new Dictionary<int,int>( )
        },
        new object[]
        {
            new int[][]
            {
                [1,1,1],
                [1,1,1],
                [1,1,1]
            },
            new Dictionary<int,int>{ [2] = 4, [3] = 1 }
        },
        new object[]
        {
            new int[][]
            {
                [1,1,1],
                [1,0,1],
                [1,1,1]
            },
            new Dictionary<int,int>()
        },
        new object[]
        {
            new int[][]
            {
                [0,1,1,1,1],
                [1,1,1,1,1],
                [1,1,1,1,1],
                [0,1,1,0,1],
                [1,1,1,1,1]
            },
            new Dictionary<int,int>{ [2] = 9, [3] = 2 }
        }
    };

    [Theory]
    [MemberData(nameof(BoardData))]
    public void CheckTests(int[][] board, Dictionary<int,int> expected)
    {
        var actual = ChessBoard.Count(board);
        
        Assert.All(expected, item => Assert.Equal(actual[item.Key],item.Value));
    }
}