using Challenges.Kyu4.ValidateSudokuNxN;

namespace Tests.Kyu4.ValidateSudoku;

public class SampleTests
{
    public static IEnumerable<object[]> SudokuData = new List<object[]>
    {
        new object[]
        {
            new []
            {
                new [] {7,8,4, 1,5,9, 3,2,6},
                new [] {5,3,9, 6,7,2, 8,4,1},
                new [] {6,1,2, 4,3,8, 7,5,9},
    
                new [] {9,2,8, 7,1,5, 4,6,3},
                new [] {3,5,7, 8,4,6, 1,9,2},
                new [] {4,6,1, 9,2,3, 5,8,7},
      
                new [] {8,7,6, 3,9,4, 2,1,5},
                new [] {2,4,3, 5,6,1, 9,7,8},
                new [] {1,9,5, 2,8,7, 6,3,4} 
            },
            true
        },
        new object[]
        {
            new []
            {
                new [] {1,4, 2,3},
                new [] {3,2, 4,1},
    
                new [] {4,1, 3,2},
                new [] {2,3, 1,4}
            },
            true
        },
        new object[]
        {
            new []
            {
                new [] {1,2,3, 4,5,6, 7,8,9},
                new [] {1,2,3, 4,5,6, 7,8,9},
                new [] {1,2,3, 4,5,6, 7,8,9},
    
                new [] {1,2,3, 4,5,6, 7,8,9},
                new [] {1,2,3, 4,5,6, 7,8,9},
                new [] {1,2,3, 4,5,6, 7,8,9},
      
                new [] {1,2,3, 4,5,6, 7,8,9},
                new [] {1,2,3, 4,5,6, 7,8,9},
                new [] {1,2,3, 4,5,6, 7,8,9}
            },
            false
        },
        new object[]
        {
            new []
            {
                new [] {1,2,3,4,5},
                new [] {1,2,3,4},
    
                new [] {1,2,3,4},
                new [] {1}
            },
            false
        }
    };

    [Theory]
    [MemberData(nameof(SudokuData))]
    public void IsValid(int[][] data, bool expected)
    {
        var sudoku = new Sudoku(data);
        Assert.Equal(expected, sudoku.IsValid());
    }
}