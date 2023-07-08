namespace Practice.Tasks;

public static class EnumerableExtensions
{

    private static IEnumerable<IEnumerable<T>> GetArrayCombinations<T>(
        this IEnumerable<T> collection, 
        int k)
    {
        return k == 0 ? new[] { Array.Empty<T>() } : collection.SelectMany((e, i) =>
            collection
            .Skip(i)
            .GetArrayCombinations(k - 1)
            .Select(c => (new[] {e})
            .Concat(c)));
    }

    private static void CheckDistinct<T>(
        this IEnumerable<T> collection, 
        IEqualityComparer<T> comparer)
    {
        if(collection.Distinct(comparer).Count() != collection.Count())
        {
            throw new ArgumentException("There are duplicate elements in the collection: ", nameof(collection));
        }
    }

    private static void CheckNullArgs<T>(
        this IEnumerable<T> collection,
        IEqualityComparer<T> comparer)
    {
        if(collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        if(comparer == null)
        {
            throw new ArgumentNullException(nameof(comparer));
        }
    }

    public static IEnumerable<IEnumerable<T>> GenCombination<T>(
        this IEnumerable<T> collection, 
        int k, 
        IEqualityComparer<T> comparer)
    {
        CheckNullArgs(collection, comparer);

        CheckDistinct(collection, comparer);

        foreach(var item in GetArrayCombinations(collection, k))
        {
            yield return item;
        }
    }

    public static IEnumerable<IEnumerable<T>> GenSubset<T>(
        this IEnumerable<T> collection, 
        IEqualityComparer<T> comparer)
    {
        CheckNullArgs(collection, comparer);

        CheckDistinct(collection, comparer);

        var enumerable = collection.ToArray();

        var subset = Enumerable
            .Range(0, 1 << enumerable.Length)
            .Select(index => enumerable.Where((type, element) => (index & (1 << element)) != 0).ToArray());

        foreach(var item in subset)
        {
            yield return item;
        }
    }

    private static IEnumerable<IEnumerable<T>> GetArrayPerms<T>(
        this IEnumerable<T> collection)
    {
        if(collection.Count() == 1 || collection.Count() == 0)
        {
            return new[] { collection };
        }

        return collection.SelectMany(v => GetArrayPerms(collection.Where(x => !x.Equals(v))), (v, p) => p.Prepend(v));
    }

    public static IEnumerable<IEnumerable<T>> GenPermutations<T>(
        this IEnumerable<T> collection, 
        IEqualityComparer<T> comparer)
    {
        CheckNullArgs(collection, comparer);

        CheckDistinct(collection, comparer);

        foreach(var item in GetArrayPerms(collection))
        {
            yield return item;
        }
    }
}