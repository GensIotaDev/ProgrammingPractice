using Challenges.Kyu7.DisemvowelTrolls;

namespace Tests.Kyu7.DisemvowelTrolls;

public class SampleTests
{
    [Theory]
    [InlineData("Ths wbst s fr lsrs LL!", "This website is for losers LOL!")]
    [InlineData("N ffns bt,\nYr wrtng s mng th wrst 'v vr rd", "No offense but,\nYour writing is among the worst I've ever read")]
    [InlineData("Wht r y,  cmmnst?", "What are you, a communist?")]
    public void Basic(string expected, string input)
    {
        Assert.Equal(expected, Kata.Disemvowel(input));
    }
}