namespace Challenges.Kyu4.CountChangeCombo;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/541af676b589989aed0009e7">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5528694f6e62d34b78000145/groups/67ffca72d1082389cb344557">here</see>
/// </summary>
public class Kata
{
    public static int CountCombinations(int money, int[] coins)
    {
        return SubCount(money);
        
        int SubCount(int val, int lastIdx = 0)
        {
            int total = 0;
            if (val < 0) return 0;
            if (val == 0) return 1;
            
            for (; lastIdx < coins.Length; lastIdx++)
            {
                int coin = coins[lastIdx];
                int diff = val - coin;

                total += SubCount(diff, lastIdx);

            }
            
            return total;
        }
    }
}