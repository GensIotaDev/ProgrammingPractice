using Challenges.Kyu4.BreadcrumbGenerator;

namespace Tests.Kyu4.BreadcrumbGenerator;

public class SampleTests
{
    [Theory]
    [InlineData("mysite.com/pictures/holidays.html", " : ", "<a href=\"/\">HOME</a> : <a href=\"/pictures/\">PICTURES</a> : <span class=\"active\">HOLIDAYS</span>")]
    [InlineData("mysite.com/very-long-url-to-make-a-silly-yet-meaningful-example/example.asp", " > ", "<a href=\"/\">HOME</a> > <a href=\"/very-long-url-to-make-a-silly-yet-meaningful-example/\">VLUMSYME</a> > <span class=\"active\">EXAMPLE</span>")]
    [InlineData("https://www.linkedin.com/in/giacomosorbi", " * " ,"<a href=\"/\">HOME</a> * <a href=\"/in/\">IN</a> * <span class=\"active\">GIACOMOSORBI</span>")]
    public void Valid(string url, string separator, string expected)
    {
        Assert.Equal(expected, Kata.GenerateBC(url, separator));
    }
}