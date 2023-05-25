namespace CodingTheory.Encoding;

public interface IDataEncoder
{
    EncodingInfo Encode(string data);
    string Decode(EncodingInfo data);
}