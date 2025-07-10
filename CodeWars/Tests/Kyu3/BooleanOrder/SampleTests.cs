using System.Numerics;
using Challenges.Kyu3.BooleanOrderSolution;

namespace Tests.Kyu3.BooleanOrderSolution;

public class SampleTests
{
    [Theory]
    [InlineData("tft", "^&", 2)]
    [InlineData("ttftff", "|&^&&", 16)]
    [InlineData("ttftfftf", "|&^&&||", 339)]
    [InlineData("ttftfftft", "|&^&&||^", 851)]
    [InlineData("ttftfftftf", "|&^&&||^&", 2434)]
    [InlineData("ttftfftftffttfftftftfftft", "|&^&&||^&&^^|&&||^&&||&^", 945766470799)]
    public void Test(string operands, string operators, BigInteger expected)
    {
        BooleanOrder order = new BooleanOrder(operands, operators);
        Assert.Equal(expected, order.Solve());
    }
}