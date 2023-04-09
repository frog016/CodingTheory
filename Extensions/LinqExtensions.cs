namespace CodingTheory.Extensions;

public static class LinqExtensions
{
    public static Dictionary<T, int> CalculateElementsFrequency<T>(this IEnumerable<T> sequence) where T : notnull
    {
        var dictionary = new Dictionary<T, int>();
        foreach (var element in sequence)
        {
            var value = dictionary.TryGetValue(element, out var frequency) ? frequency : 0;
            dictionary[element] = value + 1;
        }

        return dictionary;
    }

    public static Dictionary<TValue, TKey> Revert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary) where TValue : notnull
    {
        return dictionary.ToDictionary(key => key.Value, value => value.Key);
    }
}