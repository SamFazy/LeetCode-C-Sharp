using static System.Net.Mime.MediaTypeNames;

class Program
{
    public static void Main(string[] args)
    {
        //Create insatnce of program
        Program program = new Program();

        //Create test cases
        int[] array1 = { 1, 2, 3, 1 };
        int[] array2 = { 1, 2, 3, 4 };
        int[] array3 = { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: ");
        program.printArray(array1);
        Console.WriteLine("Output: " + program.ContainsDuplicate(array1).ToString());
        Console.WriteLine("Expected: True\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: ");
        program.printArray(array2);
        Console.WriteLine("Output: " + program.ContainsDuplicate(array2).ToString());
        Console.WriteLine("Expected: False\n");

        Console.WriteLine("Test 3:");
        Console.Write("Input: ");
        program.printArray(array3);
        Console.WriteLine("Output: " + program.ContainsDuplicate(array3).ToString());
        Console.WriteLine("Expected: True\n");
    }

    public bool ContainsDuplicate(int[] nums)
    {
        if (nums.Length <= 1)
        {
            return false;
        }

        //Convert nums to a hashset
        HashSet<int> hashSet = new HashSet<int>(nums);

        //Hash doesnt hold duplicate 
        if (hashSet.Count != nums.Length)
        {
            //Do nothing
        }
        else 
        {
            return false;
        }

        //Check if number is larger than 1000000000 or smaller than -1000000000
        foreach (int num in hashSet)
        {
            if(num > 1000000000 || num < -1000000000)
            {
                return false;
            }
        }

        return true;
    }

    //Used to print the int array for result output
    public void printArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (i == array.Length - 1)
            {
                Console.Write(array[i] + "\n");
            }
            else
            {
                Console.Write(array[i] + ", ");
            }
        }
    }
}