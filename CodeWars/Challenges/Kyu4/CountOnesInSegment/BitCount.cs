using System.Numerics;

namespace Challenges.Kyu4.CountOnesInSegment;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/596d34df24a04ee1e3000a25">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d6e2e2f476ab3000189b02a/groups/68066c9538911dda5c932cde">here</see>
/// </summary>
public class BitCount
{
    private static readonly BigInteger[] CountCache = new BigInteger[64];

    static BitCount()
    {
        /*
         * for n bits (with last value having all bits set, 2^(n+1) - 1, ie. n = 3 => 111),
         * the cumulative total of set bits is f(n) = (n * 2^n / 2)
         */
        BigInteger multMask = 1;
        for (var n = 0; n < CountCache.Length; n++)
        {
            CountCache[n] = ((n + 1) * (multMask <<= 1)) >> 1;
        }
    }
  
    public static BigInteger CountOnes(long left, long right)
    {
        //right (inclusive) - left (inclusive)
        return Count(right) - Count(left - 1);
        
        BigInteger Count(long val)
        {
            if (val <= 0) return 0;
            
            int bit = (int)Math.Log2(val);
            long mask = 1L << bit;
            if (val + 1 == mask << 1) return CountCache[bit];
            
            BigInteger total = 0;
            while (val > 0)
            {
                bool isSet = (val & mask) != 0;
                if (isSet)
                {
                    if (bit == 0)
                    {
                        total += 1;
                        break;
                    }
                    
                    long boxEdge = mask - 1; // last value before nth bit is 1
                    total += CountCache[bit - 1];
                    total += val - boxEdge; // how many numbers with leading 1 from current to max value of previous bit
                    val -= mask; //shrink zone

                }

                mask >>= 1;
                bit--;
            }

            return total;
        }
    }
}