namespace Practice.Tasks;

public class Student :
    IEquatable<Student>
{
    private const string NameDefault = "";
    private const string SurnameDefault = "";
    private const string PatronymicDefault = "";
    private const string GroupDefault = "М0О-000Б-00";
    private const string CourseDefault = "";
    private string _surname;
    private string _name;
    private string _patronymic;
    private string _group;
    private string _course;

    public Student(string surname = SurnameDefault, string name = NameDefault, string patronymic = PatronymicDefault, 
        string group = GroupDefault, string course = CourseDefault)
    {
        if(surname is null || name is null || patronymic is null || group is null || course is null)
        {
            throw new ArgumentNullException();
        }

        _surname = surname;
        _name = name;
        _patronymic = patronymic;
        _group = group;
        _course = course;
        Year = _group[4] - '0';
    }

    public string Surname
    {
        get
        { 
            return _surname;
        }

        set => _surname = value;
    }

    public string Name
    {
        get
        {
            return _name;
        }

        set => _name = value;
    }

    public string Patronymic
    {
        get
        {
            return _patronymic;
        }

        set => _patronymic = value;
    }

    public string Group
    {
        get
        {
            return _group;
        }

        set => _group = value;
    }

    public string Course
    {
        get
        {
            return _course;
        }

        set => _course = value;
    }

    public int Year
    {
        get;
    }

    public override string ToString()
    {
        return $"[ Surname: {_surname}, Name: {_name}, Patronymic: {_patronymic}, Group: {_group}, Course: {_course}]";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Surname, Name, Patronymic, Group, Course);
    }

    public override bool Equals(object? obj)
    {
        if(obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        if(obj is string @string)
        {
            throw new ArgumentException("Can't be compared to string!", nameof(obj));
        }

        if(obj is Student s)
        {
            return Equals(s);
        }

        return false;
    }

    public bool Equals(string? @string)
    {
        throw new ArgumentException("Can't be compared to string!", nameof(@string));
    }

    public bool Equals(Student? s)
    {
        if(s == null)
        {
            throw new ArgumentNullException(nameof(s));
        }

        return Surname.Equals(s.Surname) && Name.Equals(s.Name) && Patronymic.Equals(s.Patronymic) 
            && Group.Equals(s.Group) && Course.Equals(s.Course);
    }

    bool IEquatable<Student>.Equals(Student? other)
    {
        if(other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        if(other is Student)
        {
            return Equals(other);
        }

        return false;
    }
}