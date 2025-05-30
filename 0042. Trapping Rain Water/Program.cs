class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test Cases
        int[] heights1 = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        int[] heights2 = { 4, 2, 0, 3, 2, 5 };
        int[] heights3 = { 0 };
        int[] heights4 = { 1, 0 };
        int[] heights5 = { 1, 0, 1 };

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Heights: ");
        program.printIntArray(heights1);
        Console.WriteLine("Output: " + program.Trap(heights1));
        Console.WriteLine("Expected: 6\n");

        Console.WriteLine("Test 2:");
        Console.Write("Heights: ");
        program.printIntArray(heights2);
        Console.WriteLine("Output: " + program.Trap(heights2));
        Console.WriteLine("Expected: 9\n");

        Console.WriteLine("Test 3:");
        Console.Write("Heights: ");
        program.printIntArray(heights3);
        Console.WriteLine("Output: " + program.Trap(heights3));
        Console.WriteLine("Expected: 0\n");

        Console.WriteLine("Test 4:");
        Console.Write("Heights: ");
        program.printIntArray(heights4);
        Console.WriteLine("Output: " + program.Trap(heights4));
        Console.WriteLine("Expected: 0\n");

        Console.WriteLine("Test 5:");
        Console.Write("Heights: ");
        program.printIntArray(heights5);
        Console.WriteLine("Output: " + program.Trap(heights5));
        Console.WriteLine("Expected: 1\n");
    }

    public void printIntArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (i + 1 == array.Length)
            {
                Console.WriteLine(array[i]);
            }
            else
            {
                Console.Write(array[i] + ", ");
            }
        }
    }

    public int Trap(int[] height)
    {
        //Total number of water trapped
        int result = 0;

        //Arrays to store the max height to the left and right of each element
        int[] prefix = new int[height.Length];
        int[] suffix = new int[height.Length];

        //Build the left max array
        prefix[0] = height[0];
        for (int i = 1; i < height.Length; i++)
        {
            prefix[i] = Math.Max(prefix[i - 1], height[i]);
        }

        //Build the right max array
        suffix[height.Length - 1] = height[height.Length - 1];
        for (int i = height.Length - 2; i >= 0; i--)
        {
            suffix[i] = Math.Max(suffix[i + 1], height[i]);
        }

        //Calculate water trapped at each index
        for (int i = 1; i < height.Length - 1; i++)
        {
            int minMatchingHeight = Math.Min(prefix[i], suffix[i]);
            if (minMatchingHeight > height[i])
            {
                result += minMatchingHeight - height[i];
            }
        }

        return result;
    }
}