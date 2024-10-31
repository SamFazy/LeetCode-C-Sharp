class Program
{
    static void Main(string[] args)
    {
        //Make instance of program
        Program program = new Program();

        //Create arrays for output
        int[] array1 = { 1, 3 };
        int[] array2 = { 2 };

        int[] array3 = { 1, 2 };
        int[] array4 = { 3, 4 };

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine(program.FindMedianSortedArrays(array1, array2));

        Console.WriteLine("Test 2:");
        Console.WriteLine(program.FindMedianSortedArrays(array3, array4));
    }

    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        //Create array containing the 2 arrays
        int[] array = nums1.Concat(nums2).ToArray();

        //Sort the array to ascending order
        array = array.OrderBy(num => num).ToArray();

        //Array length is even
        if(array.Length % 2 == 0)
        {
            //Average the 2 middle values to get median
            int num = array.Length / 2;

            int num1 = array[num - 1];
            int num2 = array[num];

            double median = (num1 + num2) / 2.0;

            //Return median
            return median;
        }
        //Array length is odd
        else
        {
            //Get the middle value
            int num = array.Length / 2;
            double median = array[num];

            //Return median
            return median;
        }
    }
}