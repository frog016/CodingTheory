namespace CodingTheory.Compression;

public interface ICompressor
{
    Task Compress(string path, string archiveName);
    Task Decompress(string path, string fileName);
}