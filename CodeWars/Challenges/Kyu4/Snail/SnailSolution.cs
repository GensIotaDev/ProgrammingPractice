namespace Challenges.Kyu4.Snail;

using System;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d703840d58c8500012da8bd/groups/62b2ac32a527d500014e2919">here</see>
/// </summary>
public class SnailSolution
{
    enum SnailState
    {
        X = 0,
        Y,
        MinusX,
        MinusY
    }
   
    public static int[] Snail(int[][] array)
    {
        if (array.Length == 0 || array[0].Length == 0) return Array.Empty<int>();

        int[] result = new int[array.Length * array[0].Length];
        int layerCount = (int) Math.Ceiling(array.Length / 2.0);

        bool isEven = array.Length % 2 == 0;

        SnailState state = SnailState.X;
        int layer = 0;
        int index = 0;
        while (layer < layerCount)
        {
            EdgeIterate(layer, array.Length, (i) =>
            {
                result[index++] = state switch
                {
                    SnailState.X => array[layer][i],
                    SnailState.Y => array[i][^(layer + 1)],
                    SnailState.MinusX => array[^(layer + 1)][^(i + 1)],
                    SnailState.MinusY => array[^(i + 1)][layer],
                    _ => throw new ArgumentException("Unexpected value")
                };
            });

            if (state == SnailState.MinusY) layer++;

            state = (SnailState)(((int)state + 1) % 4);
        }

        if (!isEven)
        {
            int middle = array.Length / 2;
            result[^1] = array[middle][middle];
        }

        return result;      
    }
  
    private static void EdgeIterate(int layer, int length, Action<int> action)
    {
        for (int i = layer; i < length - 1 - layer; i++)
        {
            action(i);
        }
    }
}