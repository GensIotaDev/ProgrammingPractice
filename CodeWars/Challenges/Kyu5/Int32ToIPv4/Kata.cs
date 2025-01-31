namespace Challenges.Kyu5.Int32ToIPv4;

using static System.String;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/52e88b39ffb6ac53a400022e">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/599cc2dd697998dfec001407/groups/633862265324230001682ce9">here</see>
/// </summary>
public class Kata
{
    private const uint OctetMask = 0b11111111;
    private const string IPv4Format = "{0}.{1}.{2}.{3}";
  
    public static string UInt32ToIP(uint ip)
    {
        var octets = new object[4]; //string.format(_,param) only works with string/object arrays without additional boxing

        for (var i = octets.Length; i > 0; i--)
        {
            octets[i - 1] = ip & OctetMask;
            ip >>= 8;
        }

        return Format(IPv4Format, octets);
    }
}