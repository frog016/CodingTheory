namespace CodingTheory.Compression;

public class Node
{
    public readonly char? Symbol;
    public readonly int Frequency;
    public readonly Node LeftParent;
    public readonly Node RightParent;

    public List<byte> Code { get; set; } = new();

    public Node(char symbol, int frequency)
    {
        Symbol = symbol;
        Frequency = frequency;
    }

    public Node(Node leftParent, Node rightParent, int frequency)
    {
        LeftParent = leftParent;
        RightParent = rightParent;
        Frequency = frequency;
    }

    public override string ToString()
    {
        return Symbol.HasValue ? $"{Symbol.Value}" : $"{LeftParent}{RightParent}";
    }
}