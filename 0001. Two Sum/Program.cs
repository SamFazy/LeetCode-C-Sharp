class Program
{
    static void Main(string[] args)
    {
        //Create instance of Program
        Program program = new Program();

        //Create arrays
        int[] array1 = { 2, 7, 11, 15 };
        var result = program.TwoSum(array1, 9);

        //Print result
        Console.WriteLine("Test 1:");
        Console.Write("Output: ");
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\nExpected: 0, 1\n");

        //Create arrays
        int[] array2 = { 3, 2, 4 };
        result = program.TwoSum(array2, 6);

        //Print result
        Console.WriteLine("Test 2:");
        Console.Write("Output: ");
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\nExpected: 1, 2\n");

        //Create arrays
        int[] array3 = { 3, 3 };
        result = program.TwoSum(array3, 6);

        //Print result
        Console.WriteLine("Test 3:");
        Console.Write("Output: ");
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\nExpected: 0, 1\n");


        //Create arrays
        int[] array4 = { 3, 2, 3 };
        result = program.TwoSum(array4, 6);

        //Print result
        Console.WriteLine("Test 4:");
        Console.Write("Output: ");
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\nExpected: 0, 2\n");

        //Print result
        int[] array5 = { 0, 4, 3, 0 };
        result = program.TwoSum(array5, 0);

        Console.WriteLine("Test 5:");
        Console.Write("Output: ");
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\nExpected: 0, 3\n");
    }

    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        //Populate dictionary
        map[nums[0]] = 0;

        //Loop through all elements
        for (int i = 1; i < nums.Length; i++)
        {
            if (map.ContainsKey(target - nums[i]))
            {
                return new int[] { map[target - nums[i]], i  };
            }
            else
            {
                map[nums[i]] = i;
            }
        }

        return new int[] { };
    }
}