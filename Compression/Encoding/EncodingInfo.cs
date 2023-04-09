namespace CodingTheory.Compression.Encoding;

public readonly struct EncodingInfo
{
    public readonly string Data;
    public readonly Dictionary<char, string> Dictionary;

    public EncodingInfo(string data, Dictionary<char, string> dictionary)
    {
        Dictionary = dictionary;
        Data = data;
    }
}