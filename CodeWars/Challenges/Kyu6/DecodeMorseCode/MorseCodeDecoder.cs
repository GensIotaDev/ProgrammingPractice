namespace Challenges.Kyu6.DecodeMorseCode;

using System.Text;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/54b724efac3d5402db00065e">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/559342f3c59ab013b1000060/groups/61b65d8ceb9b9d0001727479">here</see>
/// </summary>
class MorseCodeDecoder
{
    public static string Decode(string morseCode)
    {
        StringBuilder word = new StringBuilder();
        StringBuilder sentence = new StringBuilder();
    
        char[] codes = { '-', '.' };
    
        int end = 0;
        while(end != -1)
        {
            //find start of char
            int start = morseCode.IndexOfAny(codes, end);
            if (start == -1) break;

            //start new word if 3+ space separator
            if(start - end >= 3)
            {
                if(sentence.Length > 0)
                {
                    sentence.Append(" ");
                }
                sentence.Append(word.ToString());
                word.Clear();
            }

            //find end
            end = morseCode.IndexOf(' ', start);

            string c;
            if(end == -1)
            {
                c = morseCode.Substring(start);
            }
            else
            {
                c = morseCode.Substring(start, end - start);
            }

            //decode char
            c = MorseCode.Get(c);
            word.Append(c);
        }

        //add final word
        if(word.Length != 0)
        {
            if(sentence.Length > 0)
            {
                sentence.Append(" ");
            }
            sentence.Append(word.ToString());
        }

        return sentence.ToString();
    }
}

//NOTE: Mock class for utility included in Kata environment
public static class MorseCode
{
    private static Dictionary<string, string> mapping = new();
    public static string Get(string code)
    {
        return mapping[code];
    }
}