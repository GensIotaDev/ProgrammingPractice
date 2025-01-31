namespace Challenges.Kyu4.SimpleFun27_RectangleRotation;

using System;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5886e082a836a691340000c3">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/58cb78015cbc444e70001bdd/groups/633b1b6461a8dc000192fd2c">here</see>
/// </summary>
public class Kata
{
    //half distance from diagonal points of 1x1 square
    private static readonly double Root2 = Math.Sqrt(2.0);
      
    public int RectangleRotation(int a, int b){
        //from center to parallel edge, number of half segments
        var x = (int) ((0.5 * a) * Root2);
        var y = (int) ((0.5 * b) * Root2);

        //points along 2*Root2 spacing
        var centerX = 2 * (int)(0.5 * x) + 1;
        var centerY = 2 * (int)(0.5 * y) + 1;

        //points along Root2 spacing
        var offsetX = 2 * (int)(0.5 * (x + 1));
        var offsetY = 2 * (int) (0.5 * (y + 1));

        return (centerX * centerY) + (offsetX * offsetY);
    }
}