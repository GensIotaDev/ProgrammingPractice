using Challenges.Retired.ValidParentheses;

namespace Tests.Retired.ValidParentheses;

public class SampleTests
{
    [Theory]
    [InlineData(true, "()")]
    [InlineData(false, ")((((")]
    public void Basic(bool expected, string input)
    {
        Assert.Equal(expected, Parentheses.ValidParentheses(input));
    }
    
}