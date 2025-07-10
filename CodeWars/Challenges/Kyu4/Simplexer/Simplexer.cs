using System.Collections;

namespace Challenges.Kyu4.SimplexerSolution;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/54b8204dcd7f514bf2000348">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5b6996cbc0b29b9aa9002369/groups/6813d3213e6e22fa39ac10b7">here</see>
/// </summary>
public class Token : IEquatable<Token>
{
    private string text { get; }
    private string type { get; }

    public Token(string text, string type)
    {
        this.text = text;
        this.type = type;
    }


    public bool Equals(Token? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return text == other.text && type == other.type;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Token)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(text, type);
    }

    public static bool operator ==(Token? left, Token? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Token? left, Token? right)
    {
        return !Equals(left, right);
    }
}

public abstract class Iterator<T> : IEnumerator<T>
{
    private object? _current;
    private T _current1;

    public abstract T Current { get; }
    public abstract bool MoveNext();

    public void Reset()
    {
    }

    T IEnumerator<T>.Current => _current1;

    object? IEnumerator.Current => _current;

    public void Dispose()
    {
    }
}

public class Simplexer : Iterator<Token>
{
    private int currentPos = 0;
    private string buffer;
        
    private (string text, string type) tokenRaw = (string.Empty, string.Empty);
    public Simplexer(string buffer)
    {
        this.buffer = buffer;
    }

    public override bool MoveNext()
    {
        if (string.IsNullOrEmpty(buffer)) return false;
        if (currentPos >= buffer.Length) throw new IndexOutOfRangeException();
        
        tokenRaw = buffer[currentPos] switch
        {
            _ when ExtractSingle(Whitespace, out var whitespace, true) => (whitespace, "whitespace"),
            _ when ExtractInt(out var @int) => (@int, "integer"),
            _ when ExtractConstKey(Booleans, out var @bool) => (@bool, "boolean"),
            _ when ExtractString(out var @string) => (@string, "string"),
            _ when ExtractSingle(Operators, out var @operator) => (@operator, "operator"),
            _ when ExtractConstKey(Keywords, out var keyword) => (keyword, "keyword"),
            _ when ExtractIdentifier(out var identifier) => (identifier, "identifier"),
            _ => throw new NotImplementedException()
        };
        currentPos += tokenRaw.text.Length;

        return tokenRaw is not (text: "", type: "" );
}

    public override Token Current => tokenRaw is not (text: "", type: "" ) ? new Token(tokenRaw.text, tokenRaw.type) : throw new Exception();

    bool ExtractSingle(char[] options, out string value, bool greedy = false)
    {
        value = string.Empty;
        int pos = currentPos;

        while (pos < buffer.Length && options.Contains(buffer[pos]))
        {
            pos++;
            if (!greedy) break;
        }
        if (pos == currentPos) return false;

        value = buffer[currentPos..pos];
        return true;
    }

    bool ExtractConstKey(string[] options, out string value)
    {
        char t = buffer[currentPos];
        for (var i = 0; i < options.Length; i++)
        {
            if (currentPos + options[i].Length <= buffer.Length && t == options[i][0] && buffer[currentPos..(currentPos + options[i].Length)] == options[i])
            {
                value = options[i];
                return true;
            }
        }

        value = string.Empty;
        return false;
    }

    bool ExtractInt(out string value)
    {
        int pos = currentPos;
        while (pos < buffer.Length)
        {
            if (buffer[pos] is >= '0' and <= '9') pos++;
            else break;
        }

        value = pos - currentPos > 0? buffer[currentPos..pos] : string.Empty;
        
        return value.Length != 0;
    }

    bool ExtractString(out string value)
    {
        value = string.Empty;
        if (buffer[currentPos] != '\"') return false;
        
        int end = buffer.IndexOf('\"', currentPos + 1);
        value = end == -1 ? buffer[currentPos..] : buffer[currentPos..(end + 1)];
        return true;
    }
    
    bool ExtractIdentifier(out string value)
    {
        value = string.Empty;
        
        int end = currentPos;
        while (end < buffer.Length)
        {
            char t = buffer[end];
            if (end == currentPos && char.IsAsciiDigit(t)) break;
            if (char.IsAsciiLetterOrDigit(t) || t is '_' or '$')
            {
                end++;
                continue;
            }

            break;
        }

        value = end != currentPos ? buffer[currentPos..end] : string.Empty;
        return end != currentPos;
    }
    
    private static readonly char[] Whitespace = [' ', '\t', '\n'];
    private static readonly string[] Booleans = ["true", "false"];
    private static readonly char[] Operators = ['+', '-', '*', '/', '%', '(', ')', '='];
    private static readonly string[] Keywords = ["if", "else", "for", "while", "return", "func", "break"];
}