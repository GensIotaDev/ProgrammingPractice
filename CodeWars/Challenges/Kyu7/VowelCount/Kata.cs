namespace Challenges.Kyu7.VowelCount;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/54ff3102c1bad923760001f3">Kata</see>
/// Submission link missing
/// </summary>
public static class Kata
{
    public static int GetVowelCount(string str)
    {
        int vowelCount = 0;

        foreach(var letter in str)
        {
            switch(letter)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    vowelCount++;
                    break;
            }
        }

        return vowelCount;
    }
}