namespace Practice.Tasks;

public class OwnTypeComparer :
    IComparer<OwnType>
{
    private static OwnTypeComparer? _instance;

    private OwnTypeComparer() {}

    public static OwnTypeComparer Instance
    {
        get
        {
            return _instance ??= new OwnTypeComparer();
        }
    }

// почему тут сравниваются строки и для чего нужен второй метод?
    public static int Compare(OwnType? x, OwnType? y)
    {
        if(ReferenceEquals(x, y)) return 0;
        if(ReferenceEquals(null, y)) return 1;
        if(ReferenceEquals(null, x)) return -1;

        return string.Compare(x.StringValue, y.StringValue, StringComparison.Ordinal);
    }

    int IComparer<OwnType>.Compare(OwnType? x, OwnType? y)
    {
        if(ReferenceEquals(x, y)) return 0;
        if(ReferenceEquals(null, y)) return 1;
        if(ReferenceEquals(null, x)) return -1;

        return string.Compare(x.StringValue, y.StringValue, StringComparison.Ordinal);
    }
}