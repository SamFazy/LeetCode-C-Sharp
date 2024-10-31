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
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");

        //Create arrays
        int[] array2 = { 3, 2, 4 };
        result = program.TwoSum(array2, 6);

        //Print result
        Console.WriteLine("Test 2:");
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");

        //Create arrays
        int[] array3 = { 3, 3 };
        result = program.TwoSum(array3, 6);

        //Print result
        Console.WriteLine("Test 3:");
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");


        //Create arrays
        int[] array4 = { 3, 2, 3 };
        result = program.TwoSum(array4, 6);

        //Print result
        Console.WriteLine("Test 4:");
        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");
    }

    public int[] TwoSum(int[] nums, int target)
    {
        //Make result array
        int[] result = new int[2];

        //Loop through the array
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                //If 2 different elements equal target return result
                if (nums[i] + nums[j] == target && i != j)
                {
                    //Result
                    result[0] = i;
                    result[1] = j;
                    return result;
                }
            }
        }

        return result;
    }
}