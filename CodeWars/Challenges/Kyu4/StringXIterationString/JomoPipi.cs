namespace Challenges.Kyu4.StringXIterationString;


/// <summary>
/// For this <see href="https://www.codewars.com/kata/5ae64f28d2ee274164000118">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d7ef30415a9070001fbb0cc/groups/67f70ef809304755b3f0981d">here</see>
/// </summary>
public class JomoPipi
{
    public static string StringFunc(string s, long x)
    {
        int half = s.Length / 2;
        int end = s.Length - 1;

        int iterations = IterationsPerCycle();
        x %= iterations;
        if (x == 0) return s;

        char[] output = new char[s.Length];
        for (int i = 0; i < output.Length; i++)
        {
            int idx = PositionAtCycle(i, x);
            output[idx] = s[i];
        }
        return new string(output);
        
        int IterationsPerCycle()
        {
            int target = end;
            int current = end;

            int count = 0;
            do
            {
                current = NextPosition(current);
                count++;
            } while (current != target);

            return count;
        }

        int PositionAtCycle(int index, long cycle)
        {
            while (cycle-- > 0)
            {
                index = NextPosition(index);
            }
            return index;
        }
        int NextPosition(int index)
        {
            return index < half ? (2 * index) + 1 : (end - index) * 2;
        }
    }
}