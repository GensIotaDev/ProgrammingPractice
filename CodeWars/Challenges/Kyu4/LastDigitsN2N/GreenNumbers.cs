using System.Numerics;

namespace Challenges.Kyu4.LastDigitsN2N;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/584dee06fe9c9aef810001e8">Kata</see>
/// Submission - WIP
/// </summary>
public class GreenNumbers
{

    private static List<BigInteger> henselRoots = new (5000)
    {
        0, 1, 5, 6
    };
    
    private static int last_power = 1;
    private const int @base = 10;

    private static void Hen(int n)
    {
        BigInteger n_five = 5;
        BigInteger n_six = 6;

        int k = 1;
        while (henselRoots.Count <= n)
        {
            var threshold = BigInteger.Pow(10, k);
            
            var tenP = BigInteger.Pow(10, k + 1);
            n_five = (-2 * BigInteger.Pow(n_five, 3) + 3 * BigInteger.Pow(n_five, 2)) % tenP;
            n_six = tenP + 1 - n_five;

            if (n_six < n_five)
            {
                if(n_six > threshold) henselRoots.Add(n_six);
                if(n_five > threshold) henselRoots.Add(n_five);
            }
            else
            {
                if(n_five > threshold) henselRoots.Add(n_five);
                if(n_six > threshold) henselRoots.Add(n_six);
            }

            k++;
        }
    }
    
    private static void Hensel(int power)
    {
        BigInteger mod = BigInteger.Pow(@base, power);
        BigInteger threshold = BigInteger.Pow(@base, power - 1);
        
        List<BigInteger> newRoots = new();
        foreach (var root in henselRoots[^2..]) // core hensel lemma algo
        {
            for (var i = 0; i < @base; i++)
            {
                BigInteger newI = i * threshold + root;
                BigInteger newRoot = (BigInteger.Pow(newI, 2) - newI) % mod;
                
                if (newRoot == 0 && newI > threshold)
                {
                    newRoots.Add(newI);
                } 
            }
        }
        
        //swap if out of order
        if (newRoots.Count > 1 && newRoots[0] > newRoots[1])
        {
            (newRoots[0], newRoots[1]) = (newRoots[1], newRoots[0]);
        }
        henselRoots.AddRange(newRoots);
    }
    
    public static BigInteger Get(int n)
    {
        // while (henselRoots.Count <= n)
        // {
        //     Hensel(++last_power);
        // }
        Hen(n);
        
        return henselRoots[n];
    }
}