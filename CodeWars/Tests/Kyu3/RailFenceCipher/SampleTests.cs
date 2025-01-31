using Kata = Challenges.Kyu3.RailFenceCipher.RailFenceCipher;

namespace Tests.Kyu3.RailFenceCipher;

public class SampleTests
{
    [Theory]
    [InlineData("WEAREDISCOVEREDFLEEATONCE", 3, "WECRLTEERDSOEEFEAOCAIVDEN")]
    [InlineData("Hello, World!", 3, "Hoo!el,Wrdl l")]
    [InlineData("Hello, World!", 4, "H !e,Wdloollr")]
    [InlineData("", 3, "")]
    public void EncodeBasic(string input, int rails, string expected)
    {
        Assert.Equal(expected, Kata.Encode(input, rails));
    }
    
    [Theory]
    [InlineData("WECRLTEERDSOEEFEAOCAIVDEN", 3, "WEAREDISCOVEREDFLEEATONCE")]
    [InlineData("H !e,Wdloollr", 4, "Hello, World!")]
    [InlineData("", 3, "")]
    public void DecodeBasic(string input, int rails, string expected)
    {
        Assert.Equal(expected, Kata.Decode(input, rails));
    }
}