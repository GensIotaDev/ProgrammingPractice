namespace Challenges.Kyu5.MoveZerosToEnd;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/52597aa56021e91c93000cb0">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/599cafd844d2f92c9e000133/groups/63e250d01375d40001aba089">here</see>
/// </summary>
public class Kata
{
    public static int[] MoveZeroes(int[] arr)
    {
        var nArr = new int[arr.Length];
    
        var fastIdx = 0;
        var slowIdx = 0;
        var backfillIdx = arr.Length - 1;
    
        while(fastIdx < arr.Length)
        {
            if(arr[fastIdx] == 0)
            {
                nArr[backfillIdx--] = 0;
            }
            else
            {
                nArr[slowIdx++] = arr[fastIdx];
            }
      
            fastIdx++;
        }
    
        return nArr;
    }
}