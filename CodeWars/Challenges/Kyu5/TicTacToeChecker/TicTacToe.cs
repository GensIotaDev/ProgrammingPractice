namespace Challenges.Kyu5.TicTacToeChecker;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/525caa5c1bf619d28c000335">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/56a1b62ceb07a6fb3900001e/groups/64c1e120bc94d1000182051c">here</see>
/// </summary>
public class TicTacToe
{
    private const int Dimensions = 3;
    private static readonly ushort[] WinMasks = new ushort[]
    {
        //diagonal
        0b100010001,
        0b001010100,
        //vertical
        0b001001001,
        0b010010010,
        0b100100100,
        //horizontal
        0b000000111,
        0b000111000,
        0b111000000
    };
  
    public int IsSolved(int[,] board)
    {
        var playerFlags = new ushort[3];

        for (var i = 0; i < Dimensions; i++)
        {
            for (var j = 0; j < Dimensions; j++)
            {
                playerFlags[board[i, j]] |= (ushort)(1 << ((i * Dimensions) + j));
            }
        }

        for (var player = 1; player < playerFlags.Length; player++)
        {
            if (WinMasks.Any(mask => (playerFlags[player] & mask) == mask)) return player;
        }
        if (playerFlags[0] == 0) return 0;
        return -1;
    }
}