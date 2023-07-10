namespace Sorting;

public abstract class AbstractSorting<T>
{
    public enum SortingMethod
    {
        Ascending,
        Descending
    }

    public abstract T[] Sort(T[] collection, SortingMethod mode, Comparison<T> comparison);
}
