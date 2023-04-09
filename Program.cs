using CodingTheory.Compression;
using CodingTheory.Compression.Archiving;
using CodingTheory.Compression.Encoding;
using CodingTheory.Compression.Parsing;

namespace CodingTheory;

public class Application
{
    public static readonly Path InitialPath = new(FolderPath, "LargeFile.txt");
    public static readonly Path EncodedPath = new(FolderPath, "encoded.txt");
    public static readonly Path DecodedPath = new(FolderPath, "decoded.txt");

    private const string FolderPath = @"D:\C#\CodingTheory\CodingTheory\TestData\";

    public static void Main()
    {
        LaunchArchiver();
        Console.ReadKey();
    }

    private static async void LaunchArchiver()
    {
        var compressor = CreateCompressor();
        await compressor.Compress(InitialPath.Full, EncodedPath.Full);
        Console.WriteLine($"File {InitialPath.Short} compressed to {EncodedPath.Short}.");

        await compressor.Decompress(EncodedPath.Full, DecodedPath.Full);
        Console.WriteLine($"File {EncodedPath.Short} decompressed to {DecodedPath.Short}.");
        Console.WriteLine("You can close the console by pressing any key.");
    }

    private static ICompressor CreateCompressor()
    {
        var encoder = new HuffmanEncoder();
        var parser = new EncodingParser();
        return new Archiver(encoder, parser);
    }

    public class Path
    {
        public readonly string Full;
        public readonly string Short;

        public Path(string folder, string fileName)
        {
            Full = folder + @"\" + fileName;
            Short = fileName;
        }
    }
}