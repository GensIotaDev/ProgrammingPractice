namespace Challenges.Kyu7.UnflattenList;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/57e2dd0bec7d247e5600013a">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/57e2eb50bad1743cab000046/groups/64c29587307b62000198c729">here</see>
/// </summary>
public class Kata
{
    public static object[] Unflatten(int[] flatArray)
    {
        var list = new List<object>();
        for (var i = 0; i < flatArray.Length; i++)
        {
            var n = flatArray[i];

            if (n < 3) list.Add(n);
            else
            {
                var length = Math.Min(i + n, flatArray.Length);
                list.Add(flatArray[i..length]);
                i += n - 1;
            }
        }

        return list.ToArray();
    }
}