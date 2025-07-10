using System.Numerics;
using Challenges.Kyu4.LastDigitsN2N;

namespace Tests.Kyu4.LastDigitsN2N;

public class SampleTests
{
    public static IEnumerable<object[]> BigData = new List<object[]>
    {
        new object[]
        {
            1,
            new BigInteger(1)
        },
        new object[]
        {
            2,
            new BigInteger(5)
        },
        new object[]
        {
            3,
            new BigInteger(6)
        },
        new object[]
        {
            4,
            new BigInteger(25)
        },
        new object[]
        {
            12,
            new BigInteger(2890625)
        },
        new object[]
        {
            13,
            new BigInteger(7109376)
        },
        new object[]
        {
            100,
            BigInteger.Parse("6188999442576576769103890995893380022607743740081787109376")
        },
        new object[]
        {
            110,
            BigInteger.Parse("9580863811000557423423230896109004106619977392256259918212890625")
        },
        new object[]
        {
            1000,
            BigInteger.Parse("9580863811000557423423230896109004106619977392256259918212890625")
        },
        new object[]
        {
            4000,
            BigInteger.Parse("9580863811000557423423230896109004106619977392256259918212890625")
        },
    };
    
    [Theory]
    [MemberData(nameof(BigData))]
    public void Basic(int input, BigInteger expected)
    {
        Assert.Equal(expected, GreenNumbers.Get(input));
    }
}