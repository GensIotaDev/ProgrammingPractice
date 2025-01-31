namespace Toolbox_Tests.Hamming;
using Toolbox;

public class DistanceTests
{
    [Theory]
    [InlineData("karolin", "kathrin", 3)]
    [InlineData("karolin", "kerstin", 3)]
    public void Strings(string from, string to, int expected)
    {
        Assert.Equal(expected, Hamming.Distance(from, to));
    }

    [Theory]
    [InlineData(0b0000,  0b1111, 4)]
    public void BinaryX86(int from, int to, int expected)
    {
        Assert.Equal(expected, Hamming.Distance(from, to));
    }
}