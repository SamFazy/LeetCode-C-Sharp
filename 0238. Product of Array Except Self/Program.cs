class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Create test cases
        int[] test1 = { 1, 2, 3, 4 };
        int[] test2 = { -1, 1, 0, -3, 3 };
        int[] test3 = { 1, 1, 1, 1, 1 };

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: Nums = ");
        program.PrintIntArray(test1);
        Console.Write("Output: ");
        program.PrintIntArray(program.ProductExceptSelf(test1));
        Console.WriteLine("Expected: 24, 12, 8, 6\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: Nums = ");
        program.PrintIntArray(test1);
        Console.Write("Output: ");
        program.PrintIntArray(program.ProductExceptSelf(test2));
        Console.WriteLine("Expected: 0, 0, 9, 0, 0\n");

        Console.WriteLine("Test 3:");
        Console.Write("Input: Nums = ");
        program.PrintIntArray(test1);
        Console.Write("Output: ");
        program.PrintIntArray(program.ProductExceptSelf(test3));
        Console.WriteLine("Expected: 1, 1, 1, 1, 1\n");
    }

    //Prints int array
    public void PrintIntArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (i == array.Length - 1)
                Console.WriteLine(array[i]);
            else
                Console.Write(array[i] + ", ");
        }
    }

    public int[] ProductExceptSelf(int[] nums)
    {
        //Create array to hold the result
        int[] result = new int[nums.Length];

        //First element of result = 0
        result[0] = 1;

        //Prefix calculations
        for (int i = 1; i < nums.Length; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];
        }

        //Initialize postfix
        int postfix = 1;

        //Calculate postfix and update array
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            result[i] = result[i] * postfix;
            postfix *= nums[i];
        }

        return result;
    }

}