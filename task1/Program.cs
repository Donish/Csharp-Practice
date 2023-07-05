using Task1;

class Program
{
    static void Main(string[] args)
    {
        Student obj = new Student();
        try
        {
            var obj1 = new Student("Zhuraev", "Donish", "Salohitdinovich", "М8О-213Б-21", "C#");
            obj = obj1;
        }
        catch(ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine(obj.Surname);
        Console.WriteLine(obj.Name);
        Console.WriteLine(obj.Patronymic);
        Console.WriteLine(obj.Group);
        Console.WriteLine(obj.Course);
        Console.WriteLine(obj.Year);

        var obj2 = new Student("Gosling", "Ryan", "Abdulmanapovich", "М8О-213Б-21", "GO");
        var obj3 = obj;
        Console.WriteLine(obj.ToString());
        try
        {
            Console.WriteLine(obj.Equals(obj2));
            Console.WriteLine(((IEquatable<Student>)obj).Equals(obj3));
            Console.WriteLine(obj.Equals("Zhuraev"));
        }
        catch(ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        var dictionary = new Dictionary<Student, string>();
        dictionary.Add(obj, "Donish");
        dictionary.Add(obj2, "Ryan");
        foreach (var item in dictionary)
        {
            Console.WriteLine($"key: {item.Key}, value: {item.Value}");
            Console.WriteLine($"HashCode: {item.Key.GetHashCode()}");
        }
        Console.WriteLine(obj.GetHashCode());

    }
}