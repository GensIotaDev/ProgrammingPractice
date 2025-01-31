using System.Text;

namespace Challenges.Kyu5.Rot13;

using System;
using System.Linq;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/530e15517bc88ac656000716">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5996a634e06bbf2b5a000569/groups/63e3129660fc660001e0a0a4">here</see>
/// </summary>
public class Kata
{
    public static string Rot13(string message)
    {
        var builder = new StringBuilder();

        foreach (var c in message)
        {
            var cToAdd = c;
            if (char.IsLetter(c))
            {
                var charOffset = 'a';
                if (char.IsUpper(c))
                {
                    charOffset = 'A';
                }

                cToAdd = (char)((((c - charOffset) + 13) % 26) + charOffset);
            }

            builder.Append(cToAdd);
        }

        return builder.ToString();
    }
}