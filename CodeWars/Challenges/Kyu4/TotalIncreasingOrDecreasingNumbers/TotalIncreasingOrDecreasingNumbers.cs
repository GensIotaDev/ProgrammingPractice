namespace Challenges.Kyu4.TotalIncreasingOrDecreasingNumbers;

using System;
using System.Numerics;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/55b195a69a6cc409ba000053">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/56af870498909a38cb000181/groups/633fa7961bd678000100056d">here</see>
/// </summary>
public class TotalIncreasingOrDecreasingNumbers
{
    private static List<BigInteger[]> Memo = new()
    {
        new BigInteger[]
        {
            100, 54, 1, 2, 3, 4, 5, 6, 7, 8 //[0] - group total, [1] - nested series summation, [2...9] increasing number count from digits 8 to 1, disregard 9 due to constant 0 
        }
    };
  
    public static BigInteger TotalIncDec(int x)
    {
        if (x == 0) return 1;
        if (x == 1) return 10;

        //build unmemoized levels 
        for (var i = Memo.Count; i < (x - 1); i++)
        {
            var prevGroup = Memo[i - 1];
            var currentGroup = new BigInteger[10];

            BigInteger total = 0;
            for (var g = 2; g < currentGroup.Length; g++)
            {
                var gValue = (prevGroup[g] + 1) + currentGroup[g - 1];
                currentGroup[g] = gValue;
                total += gValue;
            }

            currentGroup[1] = total + prevGroup[1] + 9; //9 digit declining; nested sum [from 2->10]
            
            currentGroup[0] = (2 * total) + prevGroup[1] + prevGroup[0] + 9; //mult by 2 as [1..8] inc/dec is mirrored along diagonal; 9 is the repeated digit
            
            Memo.Add(currentGroup);
        }
        
        return Memo[x-2][0];
    }
}