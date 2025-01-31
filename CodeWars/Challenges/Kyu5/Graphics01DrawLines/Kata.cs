namespace Challenges.Kyu5.Graphics01DrawLines;

using System;
    
//Some general infos - you can use following preloaded "functions/vars" from the preloaded "Drawing"- Class:
//const int Width = 100, Height = 50; //Canvas size, here always fix, 0,0 is top,left
//static bool[,] Canvas; //your drawing Canvas with size [Width,Height], here you have to set your pixels;-)
//Clear() //clears Canvas for new drawing(s)
//ShowCanvas("Y", ref Drawing.Canvas) //here "Y" is the sign for your pixel as string output
    
//Example for drawing and showing the result - look at testcases (usable for own tests?):
//---------------------------------------------------------------------------------------
//Kata draw = new Kata();   //Canvas now has size 100x50, is empty and ready for drawing
//Drawing.Clear(); //clears Canvas (every pixel=false, after new not necessary)
//draw.drawLine(-100, -50, 200, 80); //your function: draw Line on Canvas and perhaps clip it (set Canvas pixels on true)
//Console.WriteLine(Drawing.ShowCanvas("Y", ref Drawing.Canvas)); //show Canvas/Image with your line in output window (symbol for pixel="Y")


/// <summary>
/// For this <see href="https://www.codewars.com/kata/569e0778f3b6ef81b7000046">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/569e25cee4f4f96b2a000030/groups/62448bc7be5665000100ccae">here</see>
/// </summary>
public class Kata
{
    //Drawing.Canvas[0, 0] = true; //example for single pixel at 0,0 = left, top corner
    public void drawLine(int x1, int y1, int x2, int y2)
    {
        float slope = (float)(y2 - y1) / (x2 - x1);
        float b = y1 - (slope * x1);
          
        int min = Math.Clamp(Math.Min(x1, x2), 0, Drawing.Width);
        int max = Math.Clamp(Math.Max(x1, x2), 0, Drawing.Width);
          
        for(int x = min; x < max; x += 1)
        {
            int y = (int)((slope * x) + b);
            
            if(0 <= y && y < Drawing.Height)
            {
                Drawing.Canvas[x, y] = true;
            }
        }
          
        Drawing.ShowCanvas("Y", ref Drawing.Canvas);
    }
}

//NOTE: Mock class for utility included in Kata environment
public static class Drawing
{
    public const int Width = 100;
    public const int Height = 50;
    
    public static bool[,] Canvas = new bool[Width, Height];
    
    public static void Clear()
    {
        Canvas = new bool[Width, Height];
    }

    public static void ShowCanvas(string title, ref bool[,] Canvas)
    {
        throw new NotImplementedException();
    }
}