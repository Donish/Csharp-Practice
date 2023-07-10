namespace Sorting;

public sealed class InsertionSort<T> :
    AbstractSorting<T>
{
    
    public override T[] Sort(
        T[] collection, 
        SortingMethod mode, 
        Comparison<T> comparison)
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

        for(int i = 1; i < size; ++i)
        {
            var index = i;
            var currItem = collection[i];

            while(index > 0 && (mode == SortingMethod.Ascending ? comparison(currItem, collection[index - 1]) < 0
                : comparison(currItem, collection[index - 1]) > 0))
            {
                collection[index] = collection[index - 1];
                index--;
            }

            collection[index] = currItem;
        }

        return collection;
    }
}