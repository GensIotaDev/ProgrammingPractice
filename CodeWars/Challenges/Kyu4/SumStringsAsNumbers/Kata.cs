namespace Challenges.Kyu4.SumStringsAsNumbers;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5324945e2ece5e1f32000370">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/553a8610f3cc94c5e40000cb/groups/64cd20bf0b4c8b0001b1f5ad">here</see>
/// </summary>
public static class Kata
{
    public static string sumStrings(string a, string b)
    {
        var digits = new char[Math.Max(a.Length, b.Length) + 1];

        bool aFlag, bFlag;
        for (var i = 0; (aFlag = i < a.Length) | (bFlag = i < b.Length); i++)
        {
            var endIdx = i + 1;
            var sum = (aFlag ? a[^endIdx] - '0' : 0) + 
                      (bFlag ? b[^endIdx] - '0' : 0) + 
                      ((digits[^endIdx] == '\0')? 0 : digits[^endIdx] - '0');

            if (sum > 9)
            {
                digits[^(endIdx + 1)] = '1';
                sum -= 10;
            }

            digits[^endIdx] = (char)(sum + '0');
        }

        var leadingNum = Array.FindIndex(digits, c => c is not ('\0' or '0'));
        return new string(digits[leadingNum..]);
    }
}