namespace Sorting;

public sealed class MergeSort<T> :
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

        return MSort(collection, 0, collection.Length - 1, mode, comparison);
    }

    private static void Merge(
        T[] collection,
        int minIndex,
        int middleIndex,
        int maxIndex,
        SortingMethod mode,
        Comparison<T> comparison)
    {
        var left = minIndex;
        var right = middleIndex + 1;
        var tempArray = new T[maxIndex - minIndex + 1];
        var index = 0;

        while((left <= middleIndex) && (right <= maxIndex))
        {
            if(mode == SortingMethod.Ascending 
                ? comparison(collection[left], collection[right]) < 0
                : comparison(collection[left], collection[right]) > 0)
            {
                tempArray[index] = collection[left];
                left++;
            }
            else
            {
                tempArray[index] = collection[right];
                right++;
            }

            index++;
        }

        for(var i = left; i <= middleIndex; ++i)
        {
            tempArray[index] = collection[i];
            index++;
        }

        for(var i = right; i <= maxIndex; ++i)
        {
            tempArray[index] = collection[i];
            index++;
        }

        for(var i = 0; i < tempArray.Length; ++i)
        {
            collection[minIndex + i] = tempArray[i];
        }
    }

    private static T[] MSort(
        T[] collection,
        int minIndex,
        int maxIndex,
        SortingMethod mode,
        Comparison<T> comparison)
    {
        if(minIndex < maxIndex)
        {
            var middleIndex = (minIndex + maxIndex) / 2;
            MSort(collection, minIndex, middleIndex, mode, comparison);
            MSort(collection, middleIndex + 1, maxIndex, mode, comparison);
            Merge(collection, minIndex, middleIndex, maxIndex, mode, comparison);
        }

        return collection;
    }
}