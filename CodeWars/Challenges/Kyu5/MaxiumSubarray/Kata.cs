namespace Challenges.Kyu5.MaxiumSubarray;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5c3cc5112ce7350001676069/groups/64c33408dfd0e10001879d59">here</see>
/// </summary>
public static class Kata
{
    public static int MaxSequence(int[] arr) 
    { 
        var localMax = 0;
        var globalMax = int.MinValue;

        foreach (var t in arr)
        {
            localMax = Math.Max(t, t + localMax);
            if (localMax > globalMax) globalMax = localMax;
        }

        return (arr.Length == 0)? 0 : globalMax;
    }
}