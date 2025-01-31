using Challenges.Kyu8.EvenOrOdd;

namespace Tests.Kyu8.EvenOrOdd;

public class SampleTests
{
    [Fact]
    public void Basic()
    {
        Assert.Equal("Even", SolutionClass.EvenOrOdd(2));
        Assert.Equal("Odd", SolutionClass.EvenOrOdd(1));
        Assert.Equal("Even", SolutionClass.EvenOrOdd(0));
        Assert.Equal("Odd", SolutionClass.EvenOrOdd(7));
        Assert.Equal("Odd", SolutionClass.EvenOrOdd(-1));
    }
}