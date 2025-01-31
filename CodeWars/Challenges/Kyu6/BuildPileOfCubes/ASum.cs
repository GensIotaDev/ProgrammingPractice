namespace Challenges.Kyu6.BuildPileOfCubes;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5592e3bd57b64d00f3000047">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5592e3c9e02dadfb50000048/groups/5a0bf63ea1fc7887f500109f">here</see>
/// </summary>
public class ASum {
	
    public static long findNb(long m) {
		
        long n = 1;
      
        while(m > 0)
        {
            m -= n * n * n;
            n++;
        }
    
        if(m == 0)
            return n - 1;
        else
            return -1;
    }
	
}