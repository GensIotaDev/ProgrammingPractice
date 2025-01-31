using Challenges.Kyu5.PascalToSnake;

namespace Tests.Kyu5.PascalToSnake;

public class SampleTests
{
    [Theory]
    [InlineData("TestController", "test_controller")]
    [InlineData("ThisIsBeautifulDay", "this_is_beautiful_day")]
    [InlineData("Am7Days", "am7_days")]
    [InlineData("My3CodeIs4TimesBetter", "my3_code_is4_times_better")]
    [InlineData("ArbitrarilySendingDifferentTypesToFunctionsMakesKatasCool", "arbitrarily_sending_different_types_to_functions_makes_katas_cool")]
    public void Basic(string input, string expected)
    {
        Assert.Equal(expected, Kata.ToUnderscore(input));
    }

    [Theory]
    [InlineData(1, "1")]
    public void BasicNumbers(int input, string expected)
    {
        Assert.Equal(expected, Kata.ToUnderscore(input));
    }
}