class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Create test cases
        int[] test1 = { 100, 4, 200, 1, 3, 2 };
        int[] test2 = { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
        int[] test3 = { 1, 0, 1, 2 };
        int[] test4 = { 100, 101, 102, 1, 2, 3, 103, 104, 105, 106 };
        int[] test5 = { 42 };
        int[] test6 = { 3, 5, 7, 9, 11 };

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: Nums = ");
        program.PrintIntArray(test1);
        Console.Write("Output: ");
        Console.WriteLine(program.LongestConsecutive(test1));
        Console.WriteLine("Expected: 4\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: Nums = ");
        program.PrintIntArray(test2);
        Console.Write("Output: ");
        Console.WriteLine(program.LongestConsecutive(test2));
        Console.WriteLine("Expected: 9\n");

        Console.WriteLine("Test 3:");
        Console.Write("Input: Nums = ");
        program.PrintIntArray(test3);
        Console.Write("Output: ");
        Console.WriteLine(program.LongestConsecutive(test3));
        Console.WriteLine("Expected: 3\n");

        Console.WriteLine("Test 4:");
        Console.Write("Input: Nums = ");
        program.PrintIntArray(test4);
        Console.Write("Output: ");
        Console.WriteLine(program.LongestConsecutive(test4));
        Console.WriteLine("Expected: 7\n");

        Console.WriteLine("Test 5:");
        Console.Write("Input: Nums = ");
        program.PrintIntArray(test5);
        Console.Write("Output: ");
        Console.WriteLine(program.LongestConsecutive(test5));
        Console.WriteLine("Expected: 1\n");

        Console.WriteLine("Test 6:");
        Console.Write("Input: Nums = ");
        program.PrintIntArray(test6);
        Console.Write("Output: ");
        Console.WriteLine(program.LongestConsecutive(test6));
        Console.WriteLine("Expected: 1\n");
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

    public int LongestConsecutive(int[] nums)
    {
        //Check if array is empty
        if(nums.Length == 0) {  return 0; }

        //Create hashset to hold the elements
        HashSet<int> numsSet = new HashSet<int>(nums);

        //Variables
        int longestLength = 1;

        //Iterate over HashSet
        foreach (int num in numsSet)
        {
            //Identify first number in set
            if((!numsSet.Contains(num - 1)) && numsSet.Contains(num + 1))
            {
                int currentNum = num;
                int currentLength = 1;

                //Check streak of numbers
                while(numsSet.Contains(currentNum + 1))
                {
                    currentLength++;
                    currentNum++;
                }

                //If current streak is larger than longest
                if (currentLength > longestLength)
                {
                    longestLength = currentLength;
                }
            }
        }

        return longestLength;
    }
}