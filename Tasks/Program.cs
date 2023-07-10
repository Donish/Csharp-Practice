using Practice.Tasks;
using Sorting;

class Program
{
    static void Main(string[] args)
    {
        #region Task1

        Console.WriteLine("Task #1:");
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
        Console.WriteLine();

        #endregion

        Console.WriteLine("Task #2:");
        Task2();
        Console.WriteLine();

        Console.WriteLine("Task #3:");
        Task3();
        Console.WriteLine();

    }

    private static void PrintArray<T>(T[] array)
    {
        Console.Write("[ ");
        for(int i = 0; i < array.Length; ++i)
        {
            if(i == array.Length - 1)
            {
                Console.Write(array[i]);
            }
            else
            {
                Console.Write($"{array[i]}, ");
            }
        }
        Console.Write(" ]");
    }
    private static void Task2()
    {
        try
        {

            var arrGenCombination = new int[] {1, 2, 3}.GenCombination(2, OwnEqualityComparer<int>.Instance);
            Console.WriteLine("Generation of Combinations:");
            foreach(var item in arrGenCombination)
            {
                var arr = item.ToArray();
                PrintArray(arr);
            }
            Console.WriteLine();

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

        try
        {
            var arrGenSubset = new int[] {1, 2}.GenSubset(OwnEqualityComparer<int>.Instance);
            Console.WriteLine("Generation of Subset:");
            foreach(var item in arrGenSubset)
            {
                var arr = item.ToArray();
                PrintArray(arr);
            }
            Console.WriteLine();
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

        try
        {
            var arrGenPermutations = new int[] {1, 2, 3}.GenPermutations(OwnEqualityComparer<int>.Instance);
            Console.WriteLine("Generation of Permutations:");
            foreach(var item in arrGenPermutations)
            {
                var arr = item.ToArray();
                PrintArray(arr);
            }
            Console.WriteLine();
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
    }

    private static void Task3()
    {
        try
        {
            Comparison<OwnType> comparison = OwnTypeComparer.Compare;

            var array = new[] { new OwnType(5, "123"), new OwnType(1, "234"), new OwnType(8, "5342"), new OwnType(12, "123"), 
                new OwnType(3, "567"), new OwnType(21, "789")};

            var intArray = new[] {23, 544, 21, 554, 5432, 21, 123, 5, 2};

            #region first

            
            Console.WriteLine("Insertion Sort:");
            array.Sort(AbstractSorting<OwnType>.SortingMethod.Ascending, new InsertionSort<OwnType>());
            PrintArray(array);

            Console.WriteLine($"{Environment.NewLine}Select Sort:");
            array.Sort(AbstractSorting<OwnType>.SortingMethod.Descending, new InsertionSort<OwnType>(), OwnTypeComparer.Instance);
            PrintArray(array);

            Console.WriteLine($"{Environment.NewLine}HeapSort:");
            intArray.Sort(AbstractSorting<int>.SortingMethod.Ascending, new HeapSort<int>());
            PrintArray(intArray);

            Console.WriteLine($"{Environment.NewLine}QuickSort:");
            array.Sort(AbstractSorting<OwnType>.SortingMethod.Ascending, new QuickSort<OwnType>(), (IComparer<OwnType>)OwnTypeComparer.Instance);
            PrintArray(array);

            Console.WriteLine($"{Environment.NewLine}MergeSort:");
            array.Sort(AbstractSorting<OwnType>.SortingMethod.Descending, new MergeSort<OwnType>(), comparison);
            PrintArray(array);
            Console.WriteLine();


            #endregion
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
    }
}
