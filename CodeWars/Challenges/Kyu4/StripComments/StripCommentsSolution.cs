namespace Challenges.Kyu4.StripComments;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/51c8e37cee245da6b40000bd">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d63e99b78b4a200014e6d4c/groups/64cc643f3dac04000159772e">here</see>
/// </summary>
public class StripCommentsSolution
{
    public static string StripComments(string text, string[] commentSymbols)
    {
        var lines = text.Split('\n');
        var symbols = commentSymbols.Select(s => s[0]).ToArray();
        
        for (var i = 0; i < lines.Length; i++)
        {
            var index = lines[i].IndexOfAny(symbols);
            if (index != -1) lines[i] = lines[i][..index];
            
            lines[i] = lines[i].TrimEnd();
        }

        return string.Join('\n', lines);
    }
}