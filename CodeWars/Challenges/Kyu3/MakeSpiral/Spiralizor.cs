namespace Challenges.Kyu3.MakeSpiral;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/534e01fbbb17187c7e0000c6">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/60355d6f76fcfb0001710a55/groups/64812a1bdb1cd40001135b56">here</see>
/// </summary>
public class Spiralizor
{
    public static int[,] Spiralize(int size)
    {
        var output = new int[size, size];

        var edge = size;
        (int y, int x) cursor = (0, -1);
        
        for (var i = 0; i < size; i++)
        {
            var side = i % 4;

            //edge decreases in length closer to center on every odd index. Pattern is [0]:size, [1]:-1, [3,5+]:-2
            if ((i & 1) == 1)
            {
                edge -= i switch
                {
                    < 3 => 1,
                    _ => 2
                };
            }
            

            //swap horizontal/vertical edges and direction
            ref var axis = ref (((side & 1) == 0) ? ref cursor.x : ref cursor.y);
            var step = (side < 2) ? 1 : -1;
            
            for (var j = 0; j < edge; j++)
            {
                axis += step;
                
                output[cursor.y, cursor.x] = 1;
            }
        }

        return output;  
    }
}