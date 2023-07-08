using System.Diagnostics.CodeAnalysis;

namespace Practice.Tasks;

public class OwnEqualityComparer<T> :
    IEqualityComparer<T>
{
    private static OwnEqualityComparer<T>? _instance;

    private OwnEqualityComparer() {}

    public static OwnEqualityComparer<T> Instance =>
        _instance ??= new OwnEqualityComparer<T>();

    public bool Equals(T? x, T? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Equals(y);
    }

    public int GetHashCode(T? obj)
    {
        return obj.GetHashCode();
    }
}