namespace Challenges.Kyu5.FirstNonRepeatingChar;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/52bc74d4ac05d0945d00054e">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/57979abacc3dc4871c000040/groups/64cbe8fb9587bb0001823f43">here</see>
/// </summary>
public class Kata
{
    private class LetterData
    {
        public char actual;
        public int position;
        public int count;
    }
  
    public static string FirstNonRepeatingLetter(string s)
    {
        var letters = new Dictionary<char, LetterData>();

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];

            var lower = char.ToLower(c);
            if (letters.TryGetValue(lower, out var data))
            {
                data.position = i;
                data.count++;
            }
            else
            {
                letters.Add(lower, new LetterData
                {
                    actual = c,
                    position = i,
                    count = 1
                });
            }
        }

        var first = letters.Values.Where(x => x.count == 1).MinBy(x => x.position);

        return first?.actual.ToString() ?? string.Empty;
    }
}