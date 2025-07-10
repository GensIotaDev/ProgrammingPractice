namespace Challenges.Kyu4.ExpandingDependencyChains;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/56293ae77e20756fc500002e">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/562a30efaf4f5a48c2000126/groups/67a3ef62be01153bd012fdcd">here</see>
/// </summary>
public class Kata
{
    public class Node
    {
        public string Name { get; }
        public HashSet<Node> Dependencies { get; } = new();

        public int degree = 0;
        public Node(string name)
        {
            Name = name;
        }

        public string[] FlattenDependencies()
        {
            HashSet<string> dependencies = new();
            foreach (var dependency in Dependencies)
            {
                dependencies.Add(dependency.Name);
                dependencies.UnionWith(dependency.FlattenDependencies());
            }
            return dependencies.ToArray();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
    
    public static Dictionary<string, string[]> ExpandDependencies(Dictionary<string, string[]> dependencies)
    {
        Dictionary<string, Node> nodes = new();
        
        //build graph
        foreach (var key in dependencies.Keys)
        {
            nodes.Add(key, new Node(key));
        }

        foreach (var (key, deps) in dependencies)
        {
            Node node = nodes[key];
            foreach (var d in deps)
            {
                Node td = nodes[d];
                node.Dependencies.Add(td);
                td.degree++;
            }
        }
        
        //check cycles by using topological sort
        Queue<Node> queue = new();
        foreach (var node in nodes.Values)
        {
            if (node.degree == 0)
            {
                queue.Enqueue(node);
            }
        }

        List<Node> topologicalOrder = new();
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            topologicalOrder.Add(node);

            foreach (var dep in node.Dependencies)
            {
                dep.degree--;
                if (dep.degree == 0)
                {
                    queue.Enqueue(dep);
                }
            }
        }

        //contains cycle
        if (topologicalOrder.Count != nodes.Count) throw new InvalidOperationException();
        
        return topologicalOrder.ToDictionary(item => item.Name, item => item.FlattenDependencies());
    }
}