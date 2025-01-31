namespace Challenges.Kyu4.SortBinaryTreeByLevels;

using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/52bef5e3588c56132c0003bc">Kata</see>
/// Submission link missing even with valid submission
/// </summary>
class Kata
{
    public static List<int> TreeByLevels(Node node)
    {
        List<int> ret = new List<int>();
        if (node is null) return ret;

        var queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.TryDequeue(out Node n))
        {
            ret.Add(n.Value);

            if(n.Left != null) queue.Enqueue(n.Left);
            if(n.Right != null) queue.Enqueue(n.Right);
        }

        return ret;
    }
}

//Mock class for Kata
class Node
{
    public Node Left, Right;
    public int Value;
}