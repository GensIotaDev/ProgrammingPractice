namespace Challenges.Kyu4.ObservedPin;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5263c6999e0f40dee200059d">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5b4c9bfbe35052a1a2001f04/groups/648020f2db1cd40001132b07">here</see>
/// </summary>
public class Kata
{
    private static readonly int[][] AdjacentKeys = {
        new[] { 0, 8 },
        new[] { 1, 2, 4 },
        new[] { 1, 2, 3, 5 },
        new[] { 2, 3, 6 },
        new[] { 1, 4, 5, 7 },
        new[] { 2, 4, 5, 6, 8 },
        new[] { 3, 5, 6, 9 },
        new[] { 4, 7, 8 },
        new[] { 0, 5, 7, 8, 9 },
        new[] { 6, 8, 9 }
    };
  
    public static List<string> GetPINs(string observed)
    {
        var keyPresses = new int[observed.Length];
        var groupSizes = new int[observed.Length+1];
        groupSizes[0] = 1;
        groupSizes[^1] = 1;
        
        //split observed pin into separate keys and calculate size of combination sets
        for (var i = 0; i < observed.Length; i++)
        {
            var key = observed[^(i + 1)] - '0';
            keyPresses[i] = key;
            
            var adjKeys = AdjacentKeys[key];
            groupSizes[^(2 + i)] = groupSizes[^(1 + i)] * adjKeys.Length;
        }

        var combinations = new int[groupSizes[0]];
        
        //build combination 'tree' 
        foreach ((int depth, int[] keys) group in keyPresses.Select((value, i) => (i, AdjacentKeys[value])))
        {
            //each combination can be represented by a single (unique) integer
            var multiplier = (int)Math.Pow(10, group.depth);
            for (var i = 0; i < combinations.Length; i++)
            {
                //1d position for alternating key patterns based on 'tree' depth
                var x = (i / groupSizes[^(group.depth + 1)]) % group.keys.Length;
                combinations[i] += group.keys[x] * multiplier;
            }
        }
        
        return combinations.Select(c => c.ToString($"D{observed.Length}")).ToList();
    }
}