using System.Numerics;
using Challenges.Kyu5.LastDigitLargeNumber;

namespace Tests.Kyu5.LastDigitLargeNumber;

public class SampleTests
{
    public static IEnumerable<object[]> BasicData = new object[][]
    {
        new object[] { 4, 4, 1 },
        new object[] { 6, 4, 2 },
        new object[] { 9, 9, 7 },
        new object[] { 0, 10, BigInteger.Pow(10, 10) },
        new object[] { 6, BigInteger.Pow(2, 200), BigInteger.Pow(2, 300)},
        new object[] { 7, BigInteger.Parse("3715290469715693021198967285016729344580685479654510946723"), BigInteger.Parse("68819615221552997273737174557165657483427362207517952651") },
    };

    [Theory]
    [MemberData(nameof(BasicData))]
    public void Basic(int expected, BigInteger a, BigInteger e)
    {
        Assert.Equal(expected, LastDigit.GetLastDigit(a, e));
    }

    [Fact]
    public void XPowZero()
    {
        foreach (var d in Enumerable.Range(0, 9))
        {
            Assert.Equal(1, LastDigit.GetLastDigit(d, 0));
        }
    }
}