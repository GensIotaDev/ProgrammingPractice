namespace Challenges.Kyu6.CountSmilyFaces;

using System.Text.RegularExpressions;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/583203e6eb35d7980400002a">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5890d1f61da1d581cc000ff4/groups/61250d1c52154e0001fab964">here</see>
/// </summary>
public static class Kata
{
    public static int CountSmileys(string[] smileys) 
    {
        Regex rx = new Regex(@"[\:|\;][\-|\~|]?[\)|D]");

        int count = 0;
        foreach(string s in smileys)
        {
            if(rx.IsMatch(s))
                count++;
        }
    
        return count;
    }
}