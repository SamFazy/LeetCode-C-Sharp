class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test cases
        int[] test1 = { 73, 74, 75, 71, 69, 72, 76, 73 };
        int[] test2 = { 30, 40, 50, 60 };
        int[] test3 = { 30, 60, 90 };

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: ");
        program.printIntArray(test1);
        Console.Write("Output: ");
        program.printIntArray(program.DailyTemperatures(test1));
        Console.WriteLine("Expected: 1, 1, 4, 2, 1, 1, 0, 0");
        Console.WriteLine();

        Console.WriteLine("Test 2:");
        Console.Write("Input: ");
        program.printIntArray(test2);
        Console.Write("Output: ");
        program.printIntArray(program.DailyTemperatures(test2));
        Console.WriteLine("Expected: 1, 1, 1, 0");
        Console.WriteLine();

        Console.WriteLine("Test 3:");
        Console.Write("Input: ");
        program.printIntArray(test3);
        Console.Write("Output: ");
        program.printIntArray(program.DailyTemperatures(test3));
        Console.WriteLine("Expected: 1, 1, 0");
        Console.WriteLine();
    }

    public void printIntArray(int[] array)
    {
        for(int i = 0; i < array.Length; i++)
        {
            if(i + 1 == array.Length)
            {
                Console.WriteLine(array[i]);
            }
            else
            {
                Console.Write(array[i] + ", ");
            }
        }
    }

    public int[] DailyTemperatures(int[] temperatures)
    {
        //Create stack of temperatures
        Stack<int> stack = new Stack<int>();

        //Create result list to populate
        int[] result = new int[temperatures.Length];

        //Loop over all elements
        for (int i = 0; i < temperatures.Length; i++)
        {
            //When the current number is larger than the top of the stack
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                //Pop to maintain decreasing order
                int prevIndex = stack.Pop();

                //Number of days waited
                result[prevIndex] = i - prevIndex;
            }

            //Store index
            stack.Push(i);
        }

        return result;
    }
}