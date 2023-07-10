namespace Practice.Tasks;
using System.Runtime.Intrinsics.X86;
using Sorting;

public static class SortingExtensions
{

    private static void CheckNullArgs<T>(
        T[] collection,
        AbstractSorting<T> algorithm)
    {
        if(collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        if(algorithm == null)
        {
            throw new ArgumentNullException(nameof(algorithm));
        }
    }

    public static T[] Sort<T>(
        this T[] collection,
        AbstractSorting<T>.SortingMethod mode,
        AbstractSorting<T> algorithm) where T : IComparable<T>
    {
        CheckNullArgs(collection, algorithm);
        int Comparison(T x, T y) => x.CompareTo(y);

        return algorithm.Sort(collection, mode, Comparison);
    }

    public static T[] Sort<T>(
        this T[] collection,
        AbstractSorting<T>.SortingMethod mode,
        AbstractSorting<T> algorithm,
        IComparer<T> comparer)
    {
        CheckNullArgs(collection, algorithm);
        return algorithm.Sort(collection, mode, comparer.Compare);
    }

    public static T[] Sort<T>(
        this T[] collection,
        AbstractSorting<T>.SortingMethod mode,
        AbstractSorting<T> algorithm,
        Comparer<T> comparer)
    {
        CheckNullArgs(collection, algorithm);
        return algorithm.Sort(collection, mode, comparer.Compare);
    }

    public static T[] Sort<T>(
        this T[] collection,
        AbstractSorting<T>.SortingMethod mode,
        AbstractSorting<T> algorithm,
        Comparison<T> comparison)
    {
        CheckNullArgs(collection, algorithm);
        return algorithm.Sort(collection, mode, comparison);
    }
}