namespace Sorting;

public sealed class HeapSort<T> :
    AbstractSorting<T>
{
    public override T[] Sort(T[] collection, SortingMethod mode, Comparison<T> comparison)
    {
        if(collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        if(comparison == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }

        var size = collection.Length;

        for(int i = size / 2 - 1; i >= 0; --i)
        {
            Heapify(collection, size, i, mode, comparison);
        }

        for(int i = size - 1; i >= 0; --i)
        {
            (collection[0], collection[i]) = (collection[i], collection[0]);
            Heapify(collection, i, 0, mode, comparison);
        }

        return collection;
    }

    private static void Heapify(
        T[] collection,
        int size,
        int i,
        SortingMethod mode,
        Comparison<T> comparison)
    {
        var largestOrSmallest = i;
        var left = 2 * i + 1;
        int right = 2 * i + 2;

        if(left < size && (mode == SortingMethod.Ascending 
            ? comparison(collection[left], collection[largestOrSmallest]) > 0
            : comparison(collection[left], collection[largestOrSmallest]) < 0))
        {
            largestOrSmallest = left;
        }

        if(right < size && (mode == SortingMethod.Ascending 
            ? comparison(collection[left], collection[largestOrSmallest]) > 0
            : comparison(collection[left], collection[largestOrSmallest]) < 0))
        {
            largestOrSmallest = right;
        }

        if(largestOrSmallest != i)
        {
            (collection[i], collection[largestOrSmallest]) = (collection[largestOrSmallest], collection[i]);
            Heapify(collection, size, largestOrSmallest, mode, comparison);
        }
    }
}