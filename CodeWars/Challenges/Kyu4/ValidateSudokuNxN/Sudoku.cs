namespace Challenges.Kyu4.ValidateSudokuNxN;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/540afbe2dc9f615d5e000425">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5998a17bec08e21786001353/groups/64c1c19dbc94d100018200f7">here</see>
/// </summary>
public class Sudoku
{
    private readonly int[][] _board;
  
    public Sudoku(int[][] sudokuData)
    {
        _board = sudokuData;
    }

    public bool IsValid()
    {    
        var n = _board.GetLength(0);
        if (n == 0) return false;

        var dim = (int)Math.Sqrt(n);

        var smallBoard = new int[dim];
        var nSum = (n * (n + 1)) / 2;
        for (var row = 0; row < n; row++)
        {
            if (_board[row].Length != n) return false;

            var total = 0;
            for (var col = 0; col < n; col++)
            {
                var val = _board[row][col];
                total += val;

                ref var group = ref smallBoard[col / dim];
                group += val;

                if (total > nSum || group > nSum) return false;
            }

            if (total != nSum) return false;
            if ((row + 1) % dim == 0)
            {
                if (smallBoard.Any(x => x != nSum)) return false;
                smallBoard = new int[dim];
            }
        }

        return true;
    }
}