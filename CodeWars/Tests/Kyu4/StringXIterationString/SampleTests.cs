using Challenges.Kyu4.StringXIterationString;
using Xunit.Abstractions;

namespace Tests.Kyu4.StringXIterationString;

public class SampleTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public SampleTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Basic()
    {
        int length = 100;
        for (int i = 1; i < length; i++)
        {
            char[] word = new char[i];
            for (int j = 0; j < i; j++)
            {
                word[j] = (char)('a' + j);
            }
            
            string w = new string(word);
            Test(w);
        }
        
        Assert.True(true);

        void Test(string str)
        {
            long count = 0;
            string output = str;
            do
            {
                output = JomoPipi.StringFunc(output, 1);
                count++;
            }while(output != str);
            _testOutputHelper.WriteLine($"[{str.Length}] - {str} - [{count}]");
        }
    }

    [Theory]
    [InlineData("String", 3, "nrtgSi")]
    [InlineData("Ohh Man God Damn", 7, " nGOnmohaadhMD  ")]
    [InlineData("Ohh Man God Damnn", 19, "haG mnad MhO noDn")]
    public void PositiveXIterator(string input, long iterations, string expected)
    {
        string actual = JomoPipi.StringFunc(input, iterations);
        
        Assert.Equal(expected, actual);
    }
}