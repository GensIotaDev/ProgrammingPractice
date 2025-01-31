namespace Challenges.Kyu8.EvenOrOdd;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/53da3dbb4a5168369a0000fe">Kata</see>
/// Submission link missing
/// </summary>
public class SolutionClass
{
    public static string EvenOrOdd(int number)
    {
        return ((number & 1) == 1) ? "Odd" : "Even";
    }
}