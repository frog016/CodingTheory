namespace CodingTheory.Compression.Data;

public static class HuffmanTree
{
    public static Node Create(Dictionary<char, int> frequencies)
    {
        var frequencyPairs = frequencies.Select(pair => (new Node(pair.Key, pair.Value), pair.Value));
        var queue = new PriorityQueue<Node, int>(frequencyPairs);

        while (queue.Count > 1)
        {
            var firstSmallestNode = queue.Dequeue();
            var secondSmallestNode = queue.Dequeue();

            var nextNode = new Node(firstSmallestNode, secondSmallestNode, firstSmallestNode.Frequency + secondSmallestNode.Frequency);
            queue.Enqueue(nextNode, nextNode.Frequency);
        }

        return queue.Dequeue();
    }

    public static Dictionary<char, string> Traverse(Node rootNode)
    {
        var queue = new Queue<Node>(new[] { rootNode });
        var leafs = new List<Node>();

        while (queue.TryDequeue(out var node))
        {
            if (node.Symbol.HasValue)
            {
                leafs.Add(node);
                continue;
            }

            queue.Enqueue(AddCodeForParent(node, node.LeftParent, 0));
            queue.Enqueue(AddCodeForParent(node, node.RightParent, 1));
        }

        return leafs.ToDictionary(key => key.Symbol.Value, value => string.Join("", value.Code));
    }

    private static Node AddCodeForParent(Node node, Node parent, byte code)
    {
        parent.Code.AddRange(node.Code);
        parent.Code.Add(code);
        return parent;
    }
}