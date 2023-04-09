using System.Text;
using CodingTheory.Compression.Data;
using CodingTheory.Extensions;

namespace CodingTheory.Compression.Encoding;

public class HuffmanEncoder : IDataEncoder
{
    public EncodingInfo Encode(string data)
    {
        var frequencies = data.CalculateElementsFrequency();
        var rootNode = HuffmanTree.Create(frequencies);
        var encoding = HuffmanTree.Traverse(rootNode);

        return ConvertSymbolsToEncoding(data, encoding);
    }

    public string Decode(EncodingInfo data)
    {
        var codeBuilder = new StringBuilder();
        var resultBuilder = new StringBuilder();
        var dictionary = data.Dictionary.Revert();

        foreach (var encodedSymbol in data.Data)
        {
            codeBuilder.Append(encodedSymbol);
            if (!dictionary.TryGetValue(codeBuilder.ToString(), out var symbol)) 
                continue;

            resultBuilder.Append(symbol);
            codeBuilder.Clear();
        }

        return resultBuilder.ToString();
    }

    private static EncodingInfo ConvertSymbolsToEncoding(string fileData, Dictionary<char, string> encoding)
    {
        var builder = new StringBuilder();
        foreach (var symbol in fileData)
            builder.Append(encoding[symbol]);

        return new EncodingInfo(builder.ToString(), encoding);
    }
}