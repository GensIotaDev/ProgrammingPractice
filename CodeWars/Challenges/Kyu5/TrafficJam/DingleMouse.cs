namespace Challenges.Kyu5.TrafficJam;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5a26073ce1ce0e3c01000023">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d8fde0ae229ae00013ad059/groups/64c28397c7028000015ea71a">here</see>
/// </summary>
public class Dinglemouse
{
    private const char Target = 'X';
    
    public static string TrafficJam(string mainRoad, string[] sideStreets)
    {
      
        var flow = Merge(mainRoad, string.Empty, Target);
        for (var i = 0; i < sideStreets.Length; i++)
        {
            var street = sideStreets[^(i+1)];
            if(string.IsNullOrEmpty(street)) continue;
          
            flow = Merge(flow ?? mainRoad, street.Reverse(), Target, sideStreets.Length - i);
        }
      
        return new string(flow?.ToArray() ?? Array.Empty<char>());
    }
    
    private static IEnumerable<char> Merge(IEnumerable<char> left, IEnumerable<char> right, char target, int start = 0)
    {
        using var lor = left.GetEnumerator();
        using var ror = right.GetEnumerator();

        var l = lor.MoveNext();
        var r = ror.MoveNext();
        var c = '0';
        do
        {
            if (l)
            {
                c = lor.Current;
                yield return c;
                if (c == target) yield break;
                
                l = lor.MoveNext();

                if (--start > 0) continue;
            }

            if (r)
            {
                c = ror.Current;
                yield return c;
                if(c == target) yield break;
                
                r = ror.MoveNext();
            }
        } while (l || r);
    }
}