using System.ComponentModel;

class Program
{
    public static void Main(string[] args)
    {
        //Crate instance of program
        Program program = new Program();

        //Create test cases
        int[] testArray1 = { 1, 0, -1, 0, -2, 2 };
        int testTarget1 = 0;

        int[] testArray2 = { 2, 2, 2, 2, 2 };
        int testTarget2 = 8;

        int[] testArray3 = { -3, -1, 0, 2, 4, 5 };
        int testTarget3 = 0;

        int[] testArray4 = { 2, -4, -5, -2, -3, -5, 0, 4, -2 };
        int testTarget4 = -14;

        int[] testArray5 = { -2, -1, -1, 1, 1, 2, 2 };
        int testTarget5 = 0;

        int[] testArray6 = { 1000000000, 1000000000, 1000000000, 1000000000 };
        int testTarget6 = -294967296;

        int[] testArray7 = { 0, 0, 0, 1000000000, 1000000000, 1000000000, 1000000000 };
        int testTarget7 = 1000000000;

        //Get results and print
        Console.WriteLine("Test 1:");
        Console.Write("Input - ");
        Console.Write("Nums: ");
        foreach (int i in testArray1)
        { 
            Console.Write(i + " ");
        }
        Console.WriteLine("| Target: " + testTarget1.ToString());
        Console.Write("Result - ");
        program.PrintResult(program.FourSum(testArray1, testTarget1));
        Console.WriteLine();
        Console.WriteLine("Expected - [-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input - ");
        Console.Write("Nums: ");
        foreach (int i in testArray2)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("| Target: " + testTarget2.ToString());
        Console.Write("Result - ");
        program.PrintResult(program.FourSum(testArray2, testTarget2));
        Console.WriteLine();
        Console.WriteLine("Expected - [2,2,2,2]\n");

        Console.WriteLine("Test 3:");
        Console.Write("Input - ");
        Console.Write("Nums: ");
        foreach (int i in testArray3)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("| Target: " + testTarget3.ToString());
        Console.Write("Result - ");
        program.PrintResult(program.FourSum(testArray3, testTarget3));
        Console.WriteLine();
        Console.WriteLine("Expected - [-3,-1,0,4]\n");

        Console.WriteLine("Test 4:");
        Console.Write("Input - ");
        Console.Write("Nums: ");
        foreach (int i in testArray4)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("| Target: " + testTarget4.ToString());
        Console.Write("Result - ");
        program.PrintResult(program.FourSum(testArray4, testTarget4));
        Console.WriteLine();
        Console.WriteLine("Expected - [-5,-5,-4,0],[-5,-5,-2,-2],[-5,-4,-3,-2]\n");

        Console.WriteLine("Test 5:");
        Console.Write("Input - ");
        Console.Write("Nums: ");
        foreach (int i in testArray5)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("| Target: " + testTarget5.ToString());
        Console.Write("Result - ");
        program.PrintResult(program.FourSum(testArray5, testTarget5));
        Console.WriteLine();
        Console.WriteLine("Expected - [-2,-1,1,2],[-1,-1,1,1]\n");

        Console.WriteLine("Test 6:");
        Console.Write("Input - ");
        Console.Write("Nums: ");
        foreach (int i in testArray6)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("| Target: " + testTarget6.ToString());
        Console.Write("Result - ");
        program.PrintResult(program.FourSum(testArray6, testTarget6));
        Console.WriteLine();
        Console.WriteLine("Expected - []\n");

        Console.WriteLine("Test 7:");
        Console.Write("Input - ");
        Console.Write("Nums: ");
        foreach (int i in testArray7)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("| Target: " + testTarget7.ToString());
        Console.Write("Result - ");
        program.PrintResult(program.FourSum(testArray7, testTarget7));
        Console.WriteLine();
        Console.WriteLine("Expected - [0,0,0,1000000000]\n");
    }

    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        //Check if there are enough numbers in the array
        if(nums.Length < 4 || (target > 1000000000 || target < -1000000000))
        {
            return new List<IList<int>>();
        }

        //Create list to be populated
        IList<IList<int>> result = new List<IList<int>>();

        //Sort numbers in the array
        Array.Sort(nums);

        //Put array into dictionary hash map
        Dictionary<int, int> hashMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!hashMap.ContainsKey(nums[i]))
            {
                hashMap[nums[i]] = i;
            }
            if (nums[i] > 1000000000 || nums[i] < -1000000000)
            {
                return new List<IList<int>>();
            }
        }

        bool alreadyExists = false;

        //Find all combinations of for numbers that equal target
        for (int i = 0; i < nums.Length - 3; i++) //num1 (i)
        {
            for (int j = i + 1; j < nums.Length - 2; j++) //num2 (j)
            {
                for (int k = j + 1; k < nums.Length - 1; k++) //num3 (k)
                {
                    //Number we are looking for
                    int lookingFor = 0;

                    //Use try catch to make sure there is no overflow
                    try
                    {
                        lookingFor = checked(nums[i] + nums[j] + nums[k]);
                    }
                    catch(OverflowException e)
                    {
                        continue;
                    }
                    
                    if(lookingFor > target)
                    {
                        //lookingFor -= target;
                        lookingFor = (lookingFor - target) * -1;
                    }
                    else
                    {
                        lookingFor = target - lookingFor;
                    }

                    if(hashMap.ContainsKey(lookingFor))
                    {
                        //Get the index of the recived number and check if its index is larger than k
                        int index = hashMap[lookingFor];

                        if(index <= k)
                        {
                            //If index is the same as i, j, or k
                            if (nums[index] == nums[i] || nums[index] == nums[j] || nums[index] == nums[k])
                            {
                                //Check where the next value that is the same as lookingFor is located
                                int incrementNum = 0;
                                foreach(int num in nums)
                                {
                                    if (nums[index] == num)
                                    {
                                        index = incrementNum;
                                    }

                                    incrementNum++;
                                }

                                if(index == i || index == j || index == k)
                                {
                                    break;
                                }
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
                        if (hashMap.ContainsKey(nums[k]))
                        {
                            newList.Add(nums[k]);
                        }
                        newList.Add(lookingFor);

                        //Check if there is already a list that is the same
                        foreach(IList<int> list in result)
                        {
                            if ((list.Contains(newList[0]) && list.Contains(newList[1]) && list.Contains(newList[2]) && list.Contains(newList[3])) && (newList.Contains(list[0]) && newList.Contains(list[1]) && newList.Contains(list[2]) && newList.Contains(list[3])))
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
                        if(alreadyExists == false)
                        {
                            result.Add(newList);
                        }

                    }
                }
            }
        }
        return result;
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
}