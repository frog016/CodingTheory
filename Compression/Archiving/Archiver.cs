using CodingTheory.Compression.Encoding;
using CodingTheory.Compression.Parsing;

namespace CodingTheory.Compression.Archiving;

public class Archiver : ICompressor
{
    private readonly IDataEncoder _encoder;
    private readonly IParser<EncodingInfo> _parser;

    public Archiver(IDataEncoder encoder, IParser<EncodingInfo> parser)
    {
        _encoder = encoder;
        _parser = parser;
    }

    public async Task Compress(string path, string archiveName)
    {
        var data = await File.ReadAllTextAsync(path);
        var encoded = _encoder.Encode(data);
        var parsedFile = _parser.ParseTo(encoded);

        await WriteAllText(archiveName, parsedFile);
    }

    public async Task Decompress(string path, string fileName)
    {
        var data = await File.ReadAllTextAsync(path);
        var encoding = _parser.ParseFrom(data);
        var decoded = _encoder.Decode(encoding);

        await WriteAllText(fileName, decoded);
    }

    private static Task WriteAllText(string path, string content)
    {
        if (!File.Exists(path))
            File.Create(path);

        return File.WriteAllTextAsync(path, content);
    }
}