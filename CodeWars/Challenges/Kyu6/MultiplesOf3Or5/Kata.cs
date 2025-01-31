namespace Challenges.Kyu6.MultiplesOf3Or5;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/514b92a657cdc65150000006">Kata</see>
/// </summary>
public static class Kata
{
    public static int Solution(int value)
    {
        // Magic Happens
        if(value < 0) return 0;
    
        //iterate multiples of 3 then 5
        //if multiple of both, add to hashset for next loop to skip
    
        int total = 0;
        HashSet<int> shared = new HashSet<int>();
    
        for(int i = 3; i < value; i += 3)
        {
            total += i;
            if(i % 5 == 0)
            {
                shared.Add(i);
            }
        }
    
        for(int i = 5; i < value; i+= 5)
        {
            if(!shared.Contains(i))
            {
                total += i;  
            }
        }
    
        return total;
    }
}