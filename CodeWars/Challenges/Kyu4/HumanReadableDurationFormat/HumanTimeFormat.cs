namespace Challenges.Kyu4.HumanReadableDurationFormat;

using System.Collections.Generic;
using System.Text;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/52742f58faf5485cae000b9a">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5a2e31d863ed22c2610005c5/groups/633fc46bff92830001484e04">here</see>
/// </summary>
public class HumanTimeFormat{
  
    private const int MinuteToSeconds = 60;
    private const int HourToSeconds = 60 * MinuteToSeconds;
    private const int DayToSeconds = 24 * HourToSeconds;
    private const int YearToSeconds = 365 * DayToSeconds;
  
    public static string formatDuration(int seconds){
        if (seconds == 0) return "now";

        List<string> parts = new();

        var AddIfExists = (int value, string type) =>
        {
            if(value > 0) parts.Add($"{value} {type}{((value > 1) ? "s" : string.Empty)}");
        };

        var year = seconds / YearToSeconds;
        AddIfExists(year, "year");

        var day = (seconds / DayToSeconds) % 365;
        AddIfExists(day, "day");

        var hour = (seconds / HourToSeconds) % 24;
        AddIfExists(hour, "hour");

        var minute = (seconds / MinuteToSeconds) % 60;
        AddIfExists(minute, "minute");

        var second = seconds % MinuteToSeconds;
        AddIfExists(second, "second");

        StringBuilder builder = new();
        for (var i = 0; i < parts.Count; i++)
        {
            if (i == 0)
            {
                builder.Append(parts[i]);
            }
            else if (i == parts.Count - 1)
            {
                builder.Append($" and {parts[i]}");
            }
            else
            {
                builder.Append($", {parts[i]}");
            }
        }

        return builder.ToString();
    }
}