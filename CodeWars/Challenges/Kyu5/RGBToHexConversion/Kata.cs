namespace Challenges.Kyu5.RGBToHexConversion;

using System;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/513e08acc600c94f01000001">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/59956835a82c795f9d000004/groups/612526b3cafa9100011b7d67">here</see>
/// </summary>
public class Kata
{
    public static string Rgb(int r, int g, int b) 
    {
        r = Math.Clamp(r, 0, 255);
        g = Math.Clamp(g, 0, 255);
        b = Math.Clamp(b, 0, 255);
      
        int fused = (r << 16) | (g << 8) | b;
    
        return fused.ToString("X6");
    }
}