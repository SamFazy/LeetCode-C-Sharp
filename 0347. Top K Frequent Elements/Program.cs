using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Create test cases
        int[] test1 = { 1, 1, 1, 2, 2, 3 };
        int test1k = 2;

        int[] test2 = { 1 };
        int test2k = 1;

        int[] test3 = { -1, -1 };
        int test3k = 1;

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: Nums = ");
        program.PrintIntArray(test1);
        Console.WriteLine("K = " + test1k);
        Console.Write("Output: ");
        program.PrintIntArray(program.TopKFrequent(test1, test1k));
        Console.WriteLine("Expected: 1, 2\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: Nums = ");
        program.PrintIntArray(test2);
        Console.WriteLine("K = " + test2k);
        Console.Write("Output: ");
        program.PrintIntArray(program.TopKFrequent(test2, test2k));
        Console.WriteLine("Expected: 1\n");

        Console.WriteLine("Test 3:");
        Console.Write("Input: Nums = ");
        program.PrintIntArray(test3);
        Console.WriteLine("K = " + test3k);
        Console.Write("Output: ");
        program.PrintIntArray(program.TopKFrequent(test3, test3k));
        Console.WriteLine("Expected: -1\n");
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

    public int[] TopKFrequent(int[] nums, int k)
    {
        //Sort the array
        Array.Sort(nums);

        //Create dictionary. Key = number, Value = occurance
        Dictionary<int, int> numberOccurance = new Dictionary<int, int>();

        //Create variables to hold current element and occurance
        int currentNum = nums[0];
        int occurance = 0;

        //Go over each element and populate dictionary
        for (int i = 0; i < nums.Length; i++)
        {
            if(currentNum == nums[i])
            {
                occurance++;
            }
            else
            {
                //Add collected data to results
                numberOccurance.Add(currentNum, occurance);

                //Reset occurance
                occurance = 1;

                //Switch currentNum to new number
                currentNum = nums[i];
            }
        }

        //Add collected data to results
        numberOccurance.Add(currentNum, occurance);

        //Sort the dictionary by its values
        var sortedByOccurance = numberOccurance
            .OrderByDescending(entry => entry.Value)
            .ToDictionary(entry => entry.Key, entry => entry.Value);

        //Create results array
        int[] results = new int[k];

        //Populate results from sortedByOccurance dictionary
        for (int i = 0; i < k; i++)
        {
            results[i] = sortedByOccurance.ElementAt(i).Key;
        }

        return results;
    }
}