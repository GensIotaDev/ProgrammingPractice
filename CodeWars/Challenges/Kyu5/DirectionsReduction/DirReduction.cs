namespace Challenges.Kyu5.DirectionsReduction;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/550f22f4d758534c1100025a">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/55197efdd5b36a8ad300005e/groups/63e2860d1375d40001abac28">here</see>
/// </summary>
public class DirReduction {
  
    public static string[] dirReduc(String[] arr) 
    {
        //Note: directions are not checked for case; assume upper

        var reduced = new List<string>();

        foreach (var dir in arr)
        {
            if (reduced.Count == 0)
            {
                reduced.Add(dir);
                continue;
            }

            var last = reduced[^1];
            if ((last == "NORTH" && dir == "SOUTH") ||
                (last == "SOUTH" && dir == "NORTH") ||
                (last == "EAST" && dir == "WEST") ||
                (last == "WEST" && dir == "EAST"))
            {
                reduced.RemoveAt(reduced.Count - 1);
            }
            else
            {
                reduced.Add(dir);
            }
        }

        return reduced.ToArray();
    }
}