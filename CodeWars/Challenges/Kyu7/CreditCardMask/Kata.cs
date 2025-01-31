using System.Text;

namespace Challenges.Kyu7.CreditCardMask;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5412509bd436bd33920011bc">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5518aa887bdaf859b5000027/groups/6124c03fc3b09c0001c6cee0">here</see>
/// </summary>
public static class Kata
{
    public static string Maskify(string cc)
    {
        int lastMaskIndex = cc.Length - 4;
        StringBuilder builder = new StringBuilder();
    
        for(int i = 0; i < cc.Length; i++)
        {
            if(i < lastMaskIndex)
            {
                builder.Append('#');
            }
            else
            {
                builder.Append(cc[i]);
            }
        }
    
        return builder.ToString();
    }
}