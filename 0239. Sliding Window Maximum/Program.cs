using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test cases
        int[] test1Nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int test1Int = 3;

        int[] test2Nums = { 1 };
        int test2Int = 1;

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: \nNums = ");
        program.PrintIntArray(test1Nums);
        Console.WriteLine($"Int = {test1Int}");
        Console.Write("Output: ");
        program.PrintIntArray(program.MaxSlidingWindow(test1Nums, test1Int));
        Console.WriteLine("Expected: 3, 3, 5, 5, 6, 7\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: \nNums = ");
        program.PrintIntArray(test2Nums);
        Console.WriteLine($"Int = {test2Int}");
        Console.Write("Output: ");
        program.PrintIntArray(program.MaxSlidingWindow(test2Nums, test2Int));
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

    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        //Holds results
        int[] result = new int[nums.Length - (k - 1)];

        var maxElement = new PriorityQueue<Item, int>();

        //Right pointer
        int right = 0;

        //Populate the first window
        while (right < k)
        {
            maxElement.Enqueue(new Item { Index = right, Priority = nums[right] * -1 }, nums[right] * -1);
            right++;
        }

        //Window start
        int i = 0;

        //Add first result
        result[i] = -maxElement.Peek().Priority;

        //Slide window
        while (right < nums.Length)
        {
            //Add element
            maxElement.Enqueue(new Item { Index = right, Priority = -nums[right] }, -nums[right]);

            //Slide window
            i++;

            //Remove items outside the window
            while (maxElement.Peek().Index < i)
            {
                maxElement.Dequeue();
            }

            //Assign max of current window
            result[i] = -maxElement.Peek().Priority;

            right++;
        }

        return result;
    }

    class Item
    {
        public int Index { get; set; }
        public int Priority { get; set; }
    }
}