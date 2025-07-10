using Challenges.Kyu4.SumPerfectSquare;

namespace Tests.Kyu4.SumPerfectSquare;
using Xunit.Abstractions;

public class SampleTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public SampleTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Theory]
    [InlineData(15, 4)]
    [InlineData(16, 1)]
    [InlineData(17, 2)]
    [InlineData(18, 2)]
    [InlineData(19, 3)]
    public void Valid(int n, int expected)
    {
        Assert.Equal(expected, SumOfSquares.NSquaresFor(n));
    } 
}