using Challenges.Kyu5.LazyRepeater;

namespace Tests.Kyu5.LazyRepeater;

public class SampleTests
{
    [Theory]
    [InlineData("abc")]
    public void Basic(string str)
    {
        var loop = new char[5];
        var func = Kata.MakeLooper(str);
        
        for (var i = 0; i < loop.Length; i++)
        {
            loop[i] = func();
        }
        
        Assert.Equal("abcab", new string(loop));
    }
}