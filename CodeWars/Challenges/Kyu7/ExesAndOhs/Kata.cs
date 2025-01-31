namespace Challenges.Kyu7.ExesAndOhs;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/55908aad6620c066bc00002a">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/58f0207c71cc9556ce000057/groups/64c03356da358c0001bc7018">here</see>
/// </summary>
public static class Kata 
{
    public static bool XO (string input)
    {
        var total = 0;
        foreach(var c in input)
        {
            switch(c){
                case 'x' or 'X':
                    total++;
                    break;
                case 'o' or 'O':
                    total--;
                    break;
            }
        }
    
        return total == 0;
    }
}