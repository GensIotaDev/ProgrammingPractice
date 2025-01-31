namespace Challenges.Kyu4.DecodeMorseCodeAdvanced;

using System;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/54b72c16cd7f5154e9000457">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d612414344de60001df1e50/groups/61b7001a33337c0001c7b6fb">here</see>
/// </summary>
public class MorseCodeDecoder
{
    public static string DecodeBits(string bits)
    {
        //remove leading/trailing zeros
        int first = bits.IndexOf('1');
        int last = bits.LastIndexOf('1');

        bits = bits.Substring(first, last - first + 1);
      
        //determine time step size
        int step = FindSmallestRun(bits);

        StringBuilder morseChar = new StringBuilder();

        int zero_stretch = 0;
        int one_stretch = 0;
        for(int i = 0; i < bits.Length; i += step)
        {
            char c = bits[i];

            if(c == '1')
            {
                zero_stretch = 0;
                one_stretch++;

                if (i + step < bits.Length) continue;
            }
            else
            {
                zero_stretch++;
            }

            if(one_stretch == 1)
            {
                morseChar.Append(".");
                one_stretch = 0;
            }
            else if(one_stretch == 3)
            {
                morseChar.Append("-");
                one_stretch = 0;
            }
            else if(zero_stretch == 3 && morseChar.Length > 0)
            {
                morseChar.Append(" ");
            }
            else if(zero_stretch == 7 && morseChar.Length > 0)
            {
                morseChar.Append("  ");
            }
        }

        return morseChar.ToString();
    }

    public static string DecodeMorse(string morseCode)
    {
        string[] words = morseCode.Split(" ");

        StringBuilder sentence = new StringBuilder();
        foreach(string c in words)
        {
            if(string.IsNullOrWhiteSpace(c))
            {
                if(!char.IsWhiteSpace(sentence[sentence.Length - 1]))
                {
                    sentence.Append(" ");
                }
            }
            else
            {
                sentence.Append(MorseCode.Get(c));
            }
        }

        return sentence.ToString();
    }
  
    private static int FindSmallestRun(string bits)
    {
        Regex rx = new Regex("(0+)|(1+)");

        int min = int.MaxValue;
        foreach(Match m in rx.Matches(bits))
        {
            min = Math.Min(min, m.Length);
        }

        return min;
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