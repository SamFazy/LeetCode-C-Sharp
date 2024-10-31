class Program
{
    public static void Main(String[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Make arrays for testing
        int[] array1 = { -1, 2, 1, -4 };
        int[] array2 = { 0, 0, 0 };
        int[] array3 = { 4, 0, 5, -5, 3, 3, 0, -4, -5 };

        //Get the results and print
        Console.WriteLine("Test 1:");
        Console.WriteLine("Result - " + program.ThreeSumClosest(array1, 1).ToString());
        Console.WriteLine("Expected - 2\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Result - " + program.ThreeSumClosest(array2, 1).ToString());
        Console.WriteLine("Expected - 0\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine("Result - " + program.ThreeSumClosest(array3, -2).ToString());
        Console.WriteLine("Expected - -2\n");
    }

    public int ThreeSumClosest(int[] nums, int target)
    {
        //Int that will be manipulated and returned
        int result = 0;

        //Check that nums is larger than 2
        if (!(nums.Length > 2))
        {
            return result;
        }

        //Sort the array
        Array.Sort(nums);

        int total = 0;
        bool firstLoop = true;

        //Loop through and calculate all possibilities
        for(int i = 0; i < nums.Length - 2; i++)
        {
            for(int j = i + 1; j < nums.Length - 1; j++)
            {
                for( int k = j + 1; k < nums.Length; k++)
                {
                    if(firstLoop != true)
                    {
                        //Get the total of the 3 numbers added together
                        total = nums[i] + nums[j] + nums[k];

                        //Checks if the current number is closer to the target number than what is in result
                        if(total == target)
                        {
                            result = total;
                        }
                        else if (total > target && result > target && (total - target) < (result - target))
                        {
                            result = total;
                        }
                        else if(total < target && result < target && ((total - target) * -1 < (result - target) * -1))
                        {
                            result = total;
                        }

                        else if (total < target && result > target && (total - target) * -1 < (result - target))
                        {
                            result = total;
                        }
                        else if (total > target && result < target && (total - target) < (result - target) * -1)
                        {
                            result = total;
                        }
                    }
                    else
                    {
                        result = nums[i] + nums[j] + nums[k];
                        firstLoop = false;
                    }
                }
            }
        }

        return result;
    }
}