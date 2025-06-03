class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test cases
        int[] test1 = { 7, 1, 5, 3, 6, 4 };
        int[] test2 = { 7, 6, 4, 3, 1 };
        int[] test3 = { 3, 11, 6, 0, 7, 9 };
        int[] test4 = { 12, 2, 5, 1, 4, 10 };
        int[] test5 = { 8, 0, 3, 6, 11, 1 };
        int[] test6 = { 5, 5, 5, 5, 5, 5 };
        int[] test7 = { 12, 10, 8, 6, 4, 2 };
        int[] test8 = { 9, 8, 6, 7, 3, 1 };

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: ");
        program.printIntArray(test1);
        Console.WriteLine("Output: " + program.MaxProfit(test1));
        Console.WriteLine("Expected: 5\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: ");
        program.printIntArray(test2);
        Console.WriteLine("Output: " + program.MaxProfit(test2));
        Console.WriteLine("Expected: 0\n");

        Console.WriteLine("Test 3:");
        Console.Write("Input: ");
        program.printIntArray(test3);
        Console.WriteLine("Output: " + program.MaxProfit(test3));
        Console.WriteLine("Expected: 9\n");

        Console.WriteLine("Test 4:");
        Console.Write("Input: ");
        program.printIntArray(test4);
        Console.WriteLine("Output: " + program.MaxProfit(test4));
        Console.WriteLine("Expected: 9\n");

        Console.WriteLine("Test 5:");
        Console.Write("Input: ");
        program.printIntArray(test5);
        Console.WriteLine("Output: " + program.MaxProfit(test5));
        Console.WriteLine("Expected: 11\n");

        Console.WriteLine("Test 6:");
        Console.Write("Input: ");
        program.printIntArray(test6);
        Console.WriteLine("Output: " + program.MaxProfit(test6));
        Console.WriteLine("Expected: 0\n");

        Console.WriteLine("Test 7:");
        Console.Write("Input: ");
        program.printIntArray(test7);
        Console.WriteLine("Output: " + program.MaxProfit(test7));
        Console.WriteLine("Expected: 0\n");

        Console.WriteLine("Test 8:");
        Console.Write("Input: ");
        program.printIntArray(test8);
        Console.WriteLine("Output: " + program.MaxProfit(test8));
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

    public int MaxProfit(int[] prices)
    {
        //Variables
        int minBuyValue = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < prices.Length; i++ )
        {
            //Checks if max profit is smaller
            if(maxProfit < (prices[i] - minBuyValue))
            {
                maxProfit = prices[i] - minBuyValue;
            }

            //If the current value is smaller than the smallest selling price
            if (prices[i] < minBuyValue)
            {
                minBuyValue = prices[i];
            }
        }

        return maxProfit;
    }
}