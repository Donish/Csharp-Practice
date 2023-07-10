namespace Sorting;

public sealed class SelectSort<T> :
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

        for(int i = 0; i < size; ++i)
        {
            var index = i;

            for(int j = 0; j < size; ++j)
            {
                if(mode == SortingMethod.Ascending 
                    ? comparison(collection[j], collection[index]) < 0
                    : comparison(collection[j], collection[index]) > 0)
                {
                    index = j;
                }
            }
            (collection[index], collection[i]) = (collection[i], collection[index]);
        }

        return collection;
    }
}