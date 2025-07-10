using Challenges.Kyu4.SimplexerSolution;

namespace Tests.Kyu4.SimplexerSolution;

public class SampleTests
{
    [Fact]
    public void Single()
    {
        // Identifier
        Simplexer lexer = new Simplexer("x");
        Assert.True(lexer.MoveNext());
        Assert.Equal(lexer.Current, new Token("x", "identifier"));

        // Boolean
        lexer = new Simplexer("true");
        Assert.True(lexer.MoveNext());
        Assert.Equal(lexer.Current, new Token("true", "boolean"));
      
        // Integer
        lexer = new Simplexer("12345");
        Assert.True(lexer.MoveNext());
        Assert.Equal(lexer.Current, new Token("12345", "integer"));

        // String
        lexer = new Simplexer("\"Hello\"");
        Assert.True(lexer.MoveNext());
        Assert.Equal(lexer.Current, new Token("\"Hello\"", "string"));

        // Keyword
        lexer = new Simplexer("break");
        Assert.True(lexer.MoveNext());
        Assert.Equal(lexer.Current, new Token("break", "keyword"));
    }
    
    [Fact]
    public void Statement()
    {
        Simplexer lexer = new Simplexer("return x + 1");
        var expected = new Token[]
        {
            new Token("return", "keyword"),
            new Token(" ", "whitespace"),
            new Token("x", "identifier"),
            new Token(" ", "whitespace"),
            new Token("+", "operator"),
            new Token(" ", "whitespace"),
            new Token("1", "integer")
        };

        Token[] arr = ToArray(lexer);
        Assert.Equivalent(expected, arr);
    }

    [Fact]
    public void Statement2()
    {
        Simplexer lexer = new Simplexer("if(x = 5) y = x / 5 + 1 else if(x = false) y = 0 else return y");
        var expected = new Token[]
        {
            new Token("if", "keyword"),
            new Token("(", "operator"),
            new Token("x", "identifier"),
            new Token(" ", "whitespace"),
            new Token("=", "operator"),
            new Token(" ", "whitespace"),
            new Token("5", "integer"),
            new Token(")", "operator"),
            new Token(" ", "whitespace"),
            new Token("y", "identifier"),
            new Token(" ", "whitespace"),
            new Token("=", "operator"),
            new Token(" ", "whitespace"),
            new Token("x", "identifier"),
            new Token(" ", "whitespace"),
            new Token("/", "operator"),
            new Token(" ", "whitespace"),
            new Token("5", "integer"),
            new Token(" ", "whitespace"),
            new Token("+", "operator"),
            new Token(" ", "whitespace"),
            new Token("1", "integer"),
            new Token(" ", "whitespace"),
            new Token("else", "keyword"),
            new Token(" ", "whitespace"),
            new Token("if", "keyword"),
            new Token("(", "operator"),
            new Token("x", "identifier"),
            new Token(" ", "whitespace"),
            new Token("=", "operator"),
            new Token(" ", "whitespace"),
            new Token("false", "boolean"),
            new Token(")", "operator"),
            new Token(" ", "whitespace"),
            new Token("y", "identifier"),
            new Token(" ", "whitespace"),
            new Token("=", "operator"),
            new Token(" ", "whitespace"),
            new Token("0", "integer"),
            new Token(" ", "whitespace"),
            new Token("else", "keyword"),
            new Token(" ", "whitespace"),
            new Token("return", "keyword"),
            new Token(" ", "whitespace"),
            new Token("y", "identifier")
        };

        Token[] arr = ToArray(lexer);
        Assert.Equivalent(expected, arr);
    }
    
    private Token[] ToArray(Simplexer lexer)
    {
        List<Token> tokens = new List<Token>();
        while (lexer.MoveNext()) tokens.Add(lexer.Current);
        return tokens.ToArray();
    }
}