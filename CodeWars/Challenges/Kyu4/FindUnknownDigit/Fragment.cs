namespace Challenges.Kyu4.FindUnknownDigit;

public class Fragment
{
    public const int LeadingMask = 0b10_000_000_000;
    public int Flags { get; } = 0;

    private readonly int _value;
    private readonly int[] _missing;

    public Fragment(string rune)
    {
        var missing = new List<int>();
        for (var i = 0; i < rune.Length; i++)
        {
            var c = rune[^(i + 1)];
            var dMult = (int)Math.Pow(10, i);

            switch (c)
            {
                case '?':
                    missing.Add(dMult);
                    if(rune.Length > 1)
                    {
                        Flags |= LeadingMask; 
                    }
                    break;
                case '-':
                    _value *= -1;
                    break;
                default:
                    var digit = c - '0';
                    _value += digit * dMult;
                    Flags |= 1 << digit;
                    Flags &= ~LeadingMask;
                    break;
            }
        }
        _missing = missing.ToArray();
    }

    public int Encode(int value)
    {
        var total = _missing.Sum(t => t * value);

        return (_value < 0)? _value - total : _value + total;
    }
}