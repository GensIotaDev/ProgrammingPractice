namespace Challenges.Kyu5.SquareStrings;

using System;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/56fcc393c5957c666900024d">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/56fccb36ad55ef54a4000035/groups/6333288930cfde0001da5a1c">here</see>
/// </summary>
public class CodeDecode 
{
    public static string Code(string s) 
    {
        if (string.IsNullOrEmpty(s)) return string.Empty;
        
        var width = (int)(Math.Ceiling(Math.Sqrt(s.Length))); //non-perfect squares will have matrix one size larger

        var rotateBuffer = new char[((width + 1) * width) - 1]; //newline for every row minus last

        //inner [n x n] matrix rotate (without advanced math...)
        var amountWithFiller = width * width;
        for (var i = 0; i < amountWithFiller; i++)
        {
            var x = i % width;
            var y = i / width;

            var nX = width - y - 1;
            var nY = x;

            var value = (char) 11; // default filler
            if (i < s.Length)
            {
                value = s[i];
            }
            
            rotateBuffer[(nY * (width + 1)) + nX] = value;
        }

        //outer [n+1] column
        for (var i = width; i < rotateBuffer.Length; i += (width + 1))
        {
            rotateBuffer[i] = '\n';
        }
        
        return new string(rotateBuffer);
    }
    public static string Decode(string s) 
    {
        if (string.IsNullOrEmpty(s)) return string.Empty;
        
        var width = (int) Math.Sqrt(s.Length); //truncated square is the [nxn] without newlines

        var rotateBuffer = new char[width * width];

        var fillerCount = 0;
        for (var i = 0; i < s.Length; i++)
        {
            var y = i / (width + 1);
            var x = i % (width + 1);

            if (s[i] == '\n') continue;
            
            var nY = width - x - 1;
            var nX = y;

            var nIdx = (nY * width) + nX;
            if (s[i] == (char) 11)
            {
                fillerCount++;
            }
            rotateBuffer[nIdx] = s[i];
        }
        return new string(rotateBuffer[..^fillerCount]);
    }
}