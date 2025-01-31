namespace Challenges.Kyu6.TheSupermarketQueue;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/57b06f90e298a7b53d000a86">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/582eea43dc3dd23db9000059/groups/61271fc23921a5000165d391">here</see>
/// </summary>
public class Kata
{
    public class Till
    {
      private readonly Queue<int> queue;
      public int CustomerTime { get; private set; } = 0;
      public bool IsActive
      {
        get
        {
          return CustomerTime > 0;
        }
      }
      
      public Till(Queue<int> queue)
      {
        this.queue = queue;
      }
      
      public void ResolveTimestep(int value)
      {
        CustomerTime = CustomerTime - value;
        
        if(CustomerTime <= 0)
        {
          GetNewCustomer();
        }
      }
      
      public void GetNewCustomer()
      {
        if(queue.TryDequeue(out int value))
        {
          CustomerTime = value;
        }
      }
    }
    public static long QueueTime(int[] customers, int n)
    {
      Queue<int> customerQueue = new Queue<int>(customers);
      LinkedList<Till> tills = new LinkedList<Till>();      
      
      //initial optimization to prevent massive idle till count at beginning
      int activeTills = Math.Min(customers.Length, n);
      for(int i = 0; i < activeTills; i++)
      {
        Till t = new Till(customerQueue);
        t.GetNewCustomer();
        
        tills.AddLast(t);
      }
      
      int totalTime = 0;
      
      while(tills.Count > 0)
      {
        //find smallest time
        int smallestTime = int.MaxValue;
        foreach(Till t in tills)
        {
          if(t.CustomerTime != 0)
          {
            smallestTime = Math.Min(t.CustomerTime, smallestTime);
          }
        }

        //remove smallest from all tills, add time to total
        foreach(Till t in tills)
        {
          t.ResolveTimestep(smallestTime);
        }
        totalTime += smallestTime;
        
        //optimize active till list
        //remove inactive
        var node = tills.First;
        while(node != null)
        {
          var next = node.Next;
          if(!node.Value.IsActive)
          {
            tills.Remove(node);
          }
          node = next;
        }
      }
      
      return totalTime;
    }
}