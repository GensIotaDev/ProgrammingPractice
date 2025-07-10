using Kata = Challenges.Kyu4.FluentCalculator.FluentCalculator;
namespace Tests.Kyu4.FluentCalculator;

public class SampleTests
{
    [Fact]
    public void Basic()
    {
        var calculator = new Kata();
        Assert.Equal(58, (double)calculator.Six.Times.Six.Plus.Eight.DividedBy.Two.Times.Two.Plus.Ten.Times.Four.DividedBy.Two.Minus.Six);
        Assert.Equal(-11.972, (double)calculator.Zero.Minus.Four.Times.Three.Plus.Two.DividedBy.Eight.Times.One.DividedBy.Nine, 0.01);
    }
}