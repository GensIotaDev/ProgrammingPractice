namespace Challenges.Kyu4.PyramidSlideDown;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/551f23362ff852e2ab000037">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/57572ea9e8284a797500003b/groups/577f49fde55533f53f000093">here</see>
/// </summary>
public class PyramidSlideDown
{
    public static int LongestSlideDown(int[][] pyramid)
    {
        for (var i = pyramid.Length - 2; i >= 0; i--)
        {
            for (var j = 0; j < pyramid[i].Length; j++)
            {
                pyramid[i][j] += Math.Max(pyramid[i + 1][j], pyramid[i + 1][j + 1]);
            }
        }

        return pyramid[0][0];
    }
}