using Challenges.Kyu4.CountChangeCombo;

namespace Tests.Kyu4.CountChangeCombo;

public class SampleTests
{
    [Theory]
    [InlineData(4, new []{1, 2}, 3)]
    [InlineData(10, new[]{5,2,3}, 4)]
    [InlineData(11, new[]{5, 7}, 0)]
    public void Valid(int money, int[] coins, int expected)
    {
        Assert.Equal(expected, Kata.CountCombinations(money, coins));
    }
}