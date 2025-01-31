namespace Challenges.Kyu5.GreedIsGood;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5270d0d18625160ada0000e4">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/553a846d1e0399d6f7000134/groups/64d573435fd4000001e8c080">here</see>
/// </summary>
public static class Kata
{
    public static int Score(int[] dice) 
    {
        var count = new int[6];
    
        var total = 0;
        foreach(var die in dice)
        {
            var c = ++count[die - 1];
            total += die switch {
                1 when c is 3 => 800, //1000 - previous 2 * 100
                1 => 100,
                2 when c is 3 => 200,
                3 when c is 3 => 300,
                4 when c is 3 => 400,
                5 when c is 3 => 400, //500 - previous 2 * 50
                5 => 50,
                6 when c is 3 => 600,
                _ => 0
            };
        }
    
        return total;
    }
}