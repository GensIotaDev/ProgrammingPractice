namespace Challenges.Kyu5.HumanReadableTime;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/52685f7382004e774f0001f7">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5577091ee9be66dce500004c/groups/5c44ea845c58920001529f0e">here</see>
/// </summary>
public static class TimeFormat
{
    public static string GetReadableTime(int seconds)
    {
        var hours = seconds / 3600;
        seconds -= hours * 3600;

        var minutes = seconds / 60;
        seconds -= minutes * 60;

        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }
}