namespace CodingTheory.Compression.Parsing;

public interface IParser<T>
{
    string ElementSeparator { get; }
    string KeyValueSeparator { get; }
    string ParseTo(T data);
    T ParseFrom(string data);
}