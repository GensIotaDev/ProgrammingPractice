using System.Numerics;
using Challenges.Kyu4.FuscFunctionPt2;
using Xunit.Abstractions;

namespace Tests.Kyu4.FuscFunctionPt2;

public class SampleTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public SampleTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test()
    {
        BigInteger n = 21;//9007199254740991L;
        var ans = FuscSolution.Fusc(n);

        _testOutputHelper.WriteLine($"{n} - {ans}");
        Assert.True(true);
    }
}