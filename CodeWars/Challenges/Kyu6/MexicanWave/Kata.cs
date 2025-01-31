namespace Challenges.Kyu6.MexicanWave;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/58f5c63f1e26ecda7e000029">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/58f5e10bebf2e9afa9000a67/groups/612726b58c4af00001218437">here</see>
/// </summary>
public class Kata
{
    public List<string> wave(string str)
    {
        List<string> waveOutput = new List<string>();
        for(int i = 0; i < str.Length; i++)
        {
            if('a' <= str[i] && str[i] <= 'z')
            {
                char[] arr = str.ToCharArray();
                arr[i] = (char)(str[i] - 32);
                
                waveOutput.Add(new string(arr));
            }
        }
          
        return waveOutput;
    }
}