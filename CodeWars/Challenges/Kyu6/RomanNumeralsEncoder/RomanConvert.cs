namespace Challenges.Kyu6.RomanNumeralsEncoder;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/51b62bf6a9c58071c600001b">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/58a3ee9c45affb655e000375/groups/6125e31179a9e70001528beb">here</see>
/// </summary>
public class RomanConvert
{
    private static (int,string)[] SymbolMap = new (int, string)[]
    {
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I")
    };
  
    public static string Solution(int n)
    {
        List<string> result = new List<string>();
    
        int symbolIndex = 0;
        while(n != 0)
        {
            (int, string) symbol = SymbolMap[symbolIndex];
            if(n >= symbol.Item1)
            {
                result.Add(symbol.Item2);
                n -= symbol.Item1;
            }
            else
            {
                symbolIndex++;
            }
        }
    
        return String.Join(string.Empty, result);
    }
}