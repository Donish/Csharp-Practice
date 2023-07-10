namespace Practice.Tasks;

public class OwnType :
    IComparable,
    IComparable<OwnType>
{
    public int IntValue
    {
        get;

        private set;
    }

    public string StringValue
    {
        get;

        private set;
    }

    public OwnType(int @int, string @string)
    {
        IntValue = @int;
        StringValue = @string ?? throw new ArgumentNullException(nameof(@string));
    }

    public override string ToString()
    {
        return $"[ IntValue: {IntValue}, StringValue: {StringValue} ]";
    }

    public int CompareTo(OwnType? other)
    {
        if(other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }
        
        return IntValue.CompareTo(other.IntValue);
    }

    public int CompareTo(object? obj)
    {
        if(obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        if(obj is OwnType ot)
        {
            return CompareTo(ot);
        }

        throw new ArgumentException("Can't perform comparison operation", nameof(obj));
    }

}