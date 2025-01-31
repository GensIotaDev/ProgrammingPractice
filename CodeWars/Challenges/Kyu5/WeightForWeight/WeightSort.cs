using System.Text;

namespace Challenges.Kyu5.WeightForWeight;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/55c6126177c9441a570000cc">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/55c6235c08a2e3bca60000a7/groups/64cc0bca9587bb00018245c4">here</see>
/// </summary>
public class WeightSort {
	
    public static string orderWeight(string strng) 
    {
        var weights = new List<(int weight, string original)>();

        var weight = 0;
        var startIdx = 0;
        for (var i = 0; i < strng.Length; i++)
        {
            var c = strng[i];
            if (c is ' ')
            {
                weights.Add((weight, strng[startIdx..i]));
                weight = 0;
                startIdx = i + 1;
            }
            else
            {
                weight += c - '0';
            }
        }
        weights.Add((weight, strng[startIdx..]));

        var orderedWeights = weights.OrderBy(w => w.weight).ThenBy(w => w.original).Select(w => w.original);
        var builder = new StringBuilder();
        builder.AppendJoin(' ', orderedWeights);

        return builder.ToString();
    }
}