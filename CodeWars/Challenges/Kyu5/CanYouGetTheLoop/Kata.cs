namespace Challenges.Kyu5.CanYouGetTheLoop;

using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/52a89c2ea8ddc5547a000863">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/55937c83091cf8643e0000e7/groups/6334b921c000b2000196e32b">here</see>
/// </summary>
public class Kata{
    public static int getLoopSize(LoopDetector.Node startNode)
    {
        HashSet<LoopDetector.Node> nodeSet = new();
        LoopDetector.Node current = startNode;

        //find the loop
        while (true)
        {
            nodeSet.Add(current);
            if (nodeSet.Contains(current.next)) break;

            current = current.next;
        }

        //count loop
        int count = 1;
        LoopDetector.Node stop = current;
        while (current.next != stop)
        {
            count++;
            current = current.next;
        }

        return count;
    }
}

//Mock class from Kata
public class LoopDetector
{
    public class Node
    {
        public Node next;
    }
}