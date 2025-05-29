using System.ComponentModel;

class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Make arrays for testing
        int[] array1 = { -1, 0, 1, 2, -1, -4 };
        int[] array2 = { 0, 1, 1 };
        int[] array3 = { 0, 0, 0 };
        int[] array4 = { 1, 2, 1, -4 };
        int[] array5 = { -1, 2, -1, -4 };
        int[] array6 = { -1, 0, 1, 2, -1, -3 };
        int[] array7 = { 1, 2, -2, -1 };
        int[] array8 = { -1, 0, 1, 0 };
        int[] array9 = { -2, 0, 1, 1, 2 };
        int[] array10 = { 2, -3, 0, -2, -5, -5, -4, 1, 2, -2, 2, 0, 2, -4, 5, 5, -10 };

        //Get the results and print
        Console.WriteLine("Test 1:");
        Console.Write("Result - ");
        program.PrintResult(program.ThreeSum(array1));
        Console.WriteLine();
        Console.WriteLine("Expected - [-1,-1,2][-1,0,1]\n");

        Console.WriteLine("Test 2:");
        Console.Write("Result - ");
        program.PrintResult(program.ThreeSum(array2));
        Console.WriteLine();
        Console.WriteLine("Expected - []\n");

        Console.WriteLine("Test 3:");
        Console.Write("Result - ");
        program.PrintResult(program.ThreeSum(array3));
        Console.WriteLine();
        Console.WriteLine("Expected - [0,0,0]\n");

        Console.WriteLine("Test 4:");
        Console.Write("Result - ");
        program.PrintResult(program.ThreeSum(array4));
        Console.WriteLine();
        Console.WriteLine("Expected - []\n");

        Console.WriteLine("Test 5:");
        Console.Write("Result - ");
        program.PrintResult(program.ThreeSum(array5));
        Console.WriteLine();
        Console.WriteLine("Expected - [-1,-1,2]\n");

        Console.WriteLine("Test 6:");
        Console.Write("Result - ");
        program.PrintResult(program.ThreeSum(array6));
        Console.WriteLine();
        Console.WriteLine("Expected - [-3,1,2][-1,-1,2][-1,0,1]\n");

        Console.WriteLine("Test 7:");
        Console.Write("Result - ");
        program.PrintResult(program.ThreeSum(array7));
        Console.WriteLine();
        Console.WriteLine("Expected - []\n");

        Console.WriteLine("Test 8:");
        Console.Write("Result - ");
        program.PrintResult(program.ThreeSum(array8));
        Console.WriteLine();
        Console.WriteLine("Expected - [-1,0,1]\n");

        Console.WriteLine("Test 9:");
        Console.Write("Result - ");
        program.PrintResult(program.ThreeSum(array9));
        Console.WriteLine();
        Console.WriteLine("Expected - [-2,0,2],[-2,1,1]\n");

        Console.WriteLine("Test 10:");
        Console.Write("Result - ");
        program.PrintResult(program.ThreeSum(array10));
        Console.WriteLine();
        Console.WriteLine("Expected - [-10,5,5],[-5,0,5],[-4,2,2],[-3,-2,5],[-3,1,2],[-2,0,2]\n");
    }

    public void PrintResult(IList<IList<int>> lists)
    {
        foreach (IList<int> list in lists)
        {
            Console.Write("[");
            for (int i = 0; i < list.Count; i++)
            {
                if (!(i + 1 == list.Count))
                {
                    Console.Write(list[i].ToString() + ",");
                }
                else
                {
                    Console.Write(list[i].ToString());
                }
            }
            Console.Write("]");
        }
    }

    public IList<IList<int>> ThreeSum(int[] nums)
    {
        //List to populate to hold final result
        IList<IList<int>> result = new List<IList<int>>();

        //Sort the nums array
        Array.Sort(nums);

        //Go over each element in the array
        for (int i = 0; i < nums.Length - 2; i++) 
        {
            //Skip duplicate elements for i
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            //Elements to help iterate
            int j = i + 1;
            int k = nums.Length - 1;

            //Check other elements in array
            while(j < k) 
            {
                //Sum of all elements
                int sum = nums[i] + nums[j] + nums[k];

                //If found a 3Sum of 0
                if (sum == 0)
                {
                    //Add to list
                    IList<int> list = new List<int> { nums[j], nums[i], nums[k] };
                    result.Add(list);

                    //Skip duplicates for j and k
                    while (j < k && nums[j] == nums[j + 1])
                    {
                        j++;
                    }

                    while (j < k && nums[k] == nums[k - 1]) 
                    { 
                        k--; 
                    }

                    j++;
                    k--;
                }

                //Increase j if sum is larger than 0
                else if (sum < 0)
                {
                    j++;
                }
                //Decrease j if sum is larger than 0
                else
                {
                    k--;
                }
            }
        }

        return result;
    }
}