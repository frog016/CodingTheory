using System.Text;
using EncodingInfo = CodingTheory.Encoding.EncodingInfo;

namespace CodingTheory.Compression.Parsing;

public class EncodingParser : IParser<EncodingInfo>
{
    public string ElementSeparator => "_";
    public string KeyValueSeparator => ":";

    public string ParseTo(EncodingInfo encoding)
    {
        var builder = new StringBuilder();
        builder.Append(DictionaryTo(encoding.Dictionary));
        builder.Append('\n');
        builder.Append(encoding.Data);

        return builder.ToString();
    }

    public EncodingInfo ParseFrom(string data)
    {
        var splitData = data.Split('\n');
        var dictionary = DictionaryFrom(splitData[0]);

        return new EncodingInfo(splitData[1], dictionary);
    }

    private string DictionaryTo(Dictionary<char, string> dictionary)
    {
        var parsedDictionary = dictionary.Select(pair => $"{pair.Key}{KeyValueSeparator}{pair.Value}");
        return string.Join(ElementSeparator, parsedDictionary);
    }

    private Dictionary<char, string> DictionaryFrom(string data)
    {
        return data
            .Split(ElementSeparator)
            .Select(pairs => pairs.Split(KeyValueSeparator))
            .ToDictionary(splitPair => splitPair[0][0], splitPair => splitPair[1]);
    }
}