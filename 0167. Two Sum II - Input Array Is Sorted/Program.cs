class Program
{
    public static void Main(string[] args)
    {
        //Create instance of Program
        Program program = new Program();

        //Test Cases
        int[] numbers1 = { 2, 7, 11, 15 };
        int target1 = 9;

        int[] numbers2 = { 2, 3, 4 };
        int target2 = 6;

        int[] numbers3 = { -1, 0 };
        int target3 = -1;

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine("Input: ");
        Console.Write("Numbers: ");
        program.printIntArray(numbers1);
        Console.WriteLine("Target: " + target1);
        Console.Write("Output: ");
        program.printIntArray(program.TwoSum(numbers1, target1));
        Console.WriteLine("Expected: 1, 2\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Input: ");
        Console.Write("Numbers: ");
        program.printIntArray(numbers2);
        Console.WriteLine("Target: " + target2);
        Console.Write("Output: ");
        program.printIntArray(program.TwoSum(numbers2, target2));
        Console.WriteLine("Expected: 1, 3\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine("Input: ");
        Console.Write("Numbers: ");
        program.printIntArray(numbers3);
        Console.WriteLine("Target: " + target3);
        Console.Write("Output: ");
        program.printIntArray(program.TwoSum(numbers3, target3));
        Console.WriteLine("Expected: 1, 2\n");

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

    public int[] TwoSum(int[] numbers, int target)
    {
        //Pointer 1 moving right
        int i = 0;

        //Pointer 2 moving left
        int j = numbers.Length - 1;

        //Loops until finds answer
        while(numbers[i] + numbers[j] != target)
        {
            //Gets current sum
            int current = numbers[i] + numbers[j];

            //If current sum is larger than target
            if(current > target)
            {
                j--;
            }
            //If current sum is smaller than target
            else
            {
                i++;
            }
        }

        //Add results to array
        int[] result = { i + 1, j + 1 };

        return result;
    }
}