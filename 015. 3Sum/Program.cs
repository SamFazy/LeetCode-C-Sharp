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
    }

    public IList<IList<int>> ThreeSum(int[] nums)
    {
        //List to populate to hold final result
        IList<IList<int>> result = new List<IList<int>>();

        //Check that nums is larger than 2
        if (!(nums.Length > 2))
        {
            return result;
        }

        //Sort numbers in array in ascending order
        QuickSort(0, nums.Length - 1);

        //Put array into dictionary hash map
        Dictionary<int, int> hashMap = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++)
        {
            if (!hashMap.ContainsKey(nums[i]))
            {
                hashMap[nums[i]] = i;
            }
        }

        bool alreadyExists = false;

        //Find all of the combinations of numbers that can equal 0
        for (int i = 0; i < nums.Length - 2; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                //Number we are looking for
                int contains = ((nums[i] + nums[j]) * -1);

                if (hashMap.ContainsKey(contains))
                {
                    //Get the index of the recived number and check if its index is larger than j
                    int index = hashMap[contains];

                    if (index <= j)
                    {
                        if (index + 2 < nums.Length && index == i && (nums[index] == nums[index + 1] && nums[index + 1] != nums[index + 2]))
                        {
                            continue;
                        }
                        else if (index + 1 < nums.Length && hashMap.ContainsKey(nums[index + 1]) && hashMap[nums[index]] == hashMap[nums[index + 1]])
                        {

                        }
                        else if (index + 2 < nums.Length && hashMap.ContainsKey(nums[index + 2]) && hashMap[nums[index]] == hashMap[nums[index + 2]])
                        {

                        }
                        else
                        {
                            continue;
                        }
                    }

                    //Create new list
                    IList<int> newList = new List<int>();

                    if (hashMap.ContainsKey(nums[i]))
                    {
                        newList.Add(nums[i]);
                    }
                    if (hashMap.ContainsKey(nums[j]))
                    {
                        newList.Add(nums[j]);
                    }
                    newList.Add(contains);

                    //Check if there is already a list thats the same
                    foreach (IList<int> list in result)
                    {
                        if (newList.Contains(list[0]) && newList.Contains(list[1]) && newList.Contains(list[2]))
                        {
                            alreadyExists = true;
                            break;
                        }
                        else
                        {
                            alreadyExists = false;
                        }
                    }

                    //Add new list to results lists
                    if (alreadyExists == false)
                    {
                        result.Add(newList);
                    }

                    //Skips numbers that are duplicate to save time
                    while (nums.Length > j + 1 && nums[j + 1] == nums[j])
                    {
                        j++;
                    }
                }
            }
        }
        return result;


        void QuickSort(int low, int high)
        {
            if (low < high)
            {
                int pivot = nums[high];
                int i = low - 1;

                for (int j = low; j < high; j++)
                {
                    if (nums[j] < pivot)
                    {
                        i++;
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
                int tempPivot = nums[i + 1];
                nums[i + 1] = nums[high];
                nums[high] = tempPivot;

                QuickSort(low, i);
                QuickSort(i + 2, high);
            }
        }
    }

    public void PrintResult(IList<IList<int>>lists)
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
}