using Challenges.Kyu4.ObservedPin;

namespace Tests.Kyu4.ObservedPin;

public class SimpleTests
{
    [Theory]
    [InlineData("8", new []{"5", "7", "8", "9", "0"})]
    [InlineData("11", new []{"11", "22", "44", "12", "21", "14", "41", "24", "42"})]
    [InlineData("007", new []{"004", "007", "008", "084", "087", "088", "804", "807", "808", "884", "887", "888"})]
    [InlineData("369", new []{"339","366","399","658","636","258","268","669","668","266","369","398","256","296","259","368","638","396","238","356","659","639","666","359","336","299","338","696","269","358","656","698","699","298","236","239"})]
    public void Basic(string observed, string[] expected)
    {
        var actual = Kata.GetPINs(observed);
        actual.Sort();
        Array.Sort(expected);
        
        Assert.Equal(expected, actual);
    }
}