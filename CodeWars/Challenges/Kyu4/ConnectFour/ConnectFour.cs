namespace Challenges.Kyu4.ConnectFour;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/56882731514ec3ec3d000009">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/56882c21462b8d1fe3000048/groups/64e485849fed9d0001aa5f94">here</see>
/// </summary>
public class ConnectFour
{
    private static readonly (ulong mask, int offset)[] WinMasks = 
    {
        (0b1000000010000000100000001ul, 24),   //vertical
        (0b1111ul, 1),                          //horizontal
        (0b1000000001000000001000000001ul, 9),  //right diagonal
        (0b1000000100000010000001ul, 7)         //left diagonal
    };
  
    public static string WhoIsWinner(List<string> piecesPositionList)
    {
        var boards = new Dictionary<string, ulong>();
        var height = 0;
        foreach (var play in piecesPositionList)
        {
            var column = play[0] - 'A';
            var player = play[2..];

            boards.TryGetValue(player, out var board);

            var offset = 3 * column; //Max height is 6 (3 bits)
            var tHeight = (height >> offset) & 0b111;

            var position = column + (8 * tHeight);
            board |= 1ul << position; //8x8 rows
            height = (height & ~(0b111 << offset)) | (tHeight + 1) << offset; //Set modified height
            boards[player] = board;

            //check winner
            foreach (var condition in WinMasks)
            {
                for (var i = 0; i < 4; i++)
                {
                    var maskOffset = position - (condition.offset * i);
                    if (maskOffset < 0) break;

                    var mask = condition.mask << maskOffset;
                    if ((board & mask) == mask) return player;
                }
            }
        }

        return "Draw";
    }
}