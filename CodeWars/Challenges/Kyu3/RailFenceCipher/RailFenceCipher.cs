namespace Challenges.Kyu3.RailFenceCipher;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/58c5577d61aefcf3ff000081">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d712e8b19977500018f09f5/groups/64cd5a3cf0489f0001406df6">here</see>
/// </summary>
public class RailFenceCipher
{
    private delegate void InnerCipher(int railIndex, int outputIndex);
   
    public static string Encode(string s, int n)
    {
        var output = new char[s.Length];

        Cipher(n, s.Length, (railIndex, outputIndex) =>
        {
            output[outputIndex] = s[railIndex];
        });

        return new string(output);
    }

    public static string Decode(string s, int n)
    {
        var output = new char[s.Length];

        Cipher(n, s.Length, (railIndex, inputIndex) =>
        {
            output[railIndex] = s[inputIndex];
        });

        return new string(output);
    }
  
    private static void Cipher(int railCount, int outputLength, InnerCipher body)
    {
        var maxStep = 2 * (railCount - 1);

        var index = 0;
        for (var rail = 0; rail < railCount; rail++)
        {
            int StepFunc(int step)
            {
                if (rail == 0 || rail == railCount - 1) return maxStep;
                return Math.Abs(step - maxStep);
            }

            var step = 2 * rail;

            for (var i = rail; i < outputLength; i += step = StepFunc(step))
            {
                body(i, index++);
            }
        }
    }
}