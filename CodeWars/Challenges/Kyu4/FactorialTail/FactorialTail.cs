namespace Challenges.Kyu4.FactorialTailSolution;

using Prime = (int prime, int count);

/// <summary>
/// For this <see href="https://www.codewars.com/kata/55c4eb777e07c13528000021">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/595936e0a117ebb917000352/groups/6817147603c0454a84c0f0a9">here</see>
/// </summary>
public class FactorialTail
{
    public static int zeroes(int radix, int number)
    {
        var factors = GetPrimeFactors(radix);
        var output = int.MaxValue;

        foreach (var (prime, count) in factors)
        {
            output = Math.Min(output, CountPrimePowers(number, prime) / count);
        }
        
        return output;
    }

    private static List<Prime> GetPrimeFactors(int @base)
    {
        List<Prime> primes = new();

        for (int i = 2; @base != 1; i++)
        {
            if (@base % i == 0)
            {
                int count = 0;
                while (@base % i == 0)
                {
                    @base /= i;
                    count++;
                }
                primes.Add((i, count));
            }
        }
        return primes;
    }

    private static int CountPrimePowers(int n, int prime)
    {
        int count = 0;
        int nprime = prime;
        while (nprime <= n)
        {
            count += n / nprime;
            nprime *= prime;
        }
        return count;
    }
}