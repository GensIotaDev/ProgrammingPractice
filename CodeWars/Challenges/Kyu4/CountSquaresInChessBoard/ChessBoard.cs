namespace Challenges.Kyu4.CountSquaresInChessBoard;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5bc6f9110ca59325c1000254">Kata</see>
/// Submission - WIP
/// </summary>
public class ChessBoard
{
    public static Dictionary<int, int> Count(int[][] b)
    {
        int max = b.GetLength(0);
        int[,] subgroups = new int[max, max];

        Dictionary<int,int> output = new Dictionary<int,int>();
        for (int size = 2; size <= max; size++)
        {
            int full = 1 << size;
            int end = max - (size - 1);
            int count = 0;
            for (int y = 0; y < end; y++)
            {
                for (int x = 0; x < end; x++)
                {
                    int total = b[y][x] + b[y][x + 1] + b[y + 1][x] + b[y + 1][x + 1];
                    subgroups[y, x] = total;
                    if (total == full) count++;
                }
            }
            
            if(count > 0) output.Add(size, count);
        }
        
        return output;
    }
}