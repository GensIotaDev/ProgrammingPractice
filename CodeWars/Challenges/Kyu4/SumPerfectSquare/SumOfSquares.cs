namespace Challenges.Kyu4.SumPerfectSquare;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5a3af5b1ee1aaeabfe000084">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d618352e4ba560001397f27/groups/67fd7cba48a5df065c6742c2">here</see>
/// </summary>
public class SumOfSquares
{
    //based on Lagrange's four-square theorem
    public static int NSquaresFor(int n)
    {
        if (IsPerfect(n)) return 1;

        //result is 4 if number = 4^k(8m + 7)
        while ((n & 3) == 0)
        {
            n >>= 2;
        }
        if ((n & 7) == 7) return 4;

        //sum of 2 perfect squares
        int root = (int)Math.Sqrt(n);
        for (var i = 1; i < root + 1; i++)
        {
            if (IsPerfect(n - i * i)) return 2;
        }

        return 3;
        
        bool IsPerfect(int val)
        {
            int root = (int)Math.Sqrt(val);
            return root * root == val;
        }
    }
}