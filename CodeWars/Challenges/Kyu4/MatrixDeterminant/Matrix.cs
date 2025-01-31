namespace Challenges.Kyu4.MatrixDeterminant;

using System;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/52a382ee44408cea2500074c">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d6566d78e41b60001ba70c2/groups/6334c857c000b2000196e682">here</see>
/// </summary>
public class Matrix
{
    public static int Determinant(int[][] matrix)
    {
        if (matrix.Length == 1) return matrix[0][0];

        int determinant = 0;

        int n = matrix.Length;
        for (var col = 0; col < n; col++)
        {
            var minor = BuildMinorMatrix(matrix, col);

            var sign = ((col & 1) == 0) ? 1 : -1;
            determinant += sign * matrix[0][col] * Determinant(minor);
        }

        return determinant;
    }
  
    private static int[][] BuildMinorMatrix(int[][] matrix, int colId)
    {
        int n = matrix.Length;

        int[][] minor = new int[n-1][];

        for (int row = 1; row < n; row++)
        {
            var rowItem = new int[n - 1];
            if (colId == 0)
            {
                Array.Copy(matrix[row], 1, rowItem, 0, n - 1);
            }
            else if (colId == n - 1)
            {
                Array.Copy(matrix[row], 0, rowItem, 0, n - 1);
            }
            else
            {
                Array.Copy(matrix[row], 0, rowItem, 0, colId);
                Array.Copy(matrix[row], colId + 1, rowItem, colId, (n - 1) - colId);
            }

            minor[row - 1] = rowItem;
        }

        return minor;
    }
}