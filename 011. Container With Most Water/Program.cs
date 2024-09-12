class Program
{
    static void Main(string[] args)
    {
        //Make instance of program
        Program program = new Program();

        //Make arrays
        int[] a1 = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        int[] a2 = { 1, 1 };
        int[] a3 = { 0, 0 };
        int[] a4 = { 2, 3, 4, 5, 18, 17, 6 };

        //Get test results
        Console.WriteLine("Test 1:");
        Console.WriteLine("Result - " + program.MaxArea(a1));
        Console.WriteLine("Expected - 49\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Result - " + program.MaxArea(a2));
        Console.WriteLine("Expected - 1\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine("Result - " + program.MaxArea(a3));
        Console.WriteLine("Expected - 0\n");

        Console.WriteLine("Test 4:");
        Console.WriteLine("Result - " + program.MaxArea(a4));
        Console.WriteLine("Expected - 17\n");
    }

    public int MaxArea(int[] height)
    {
        //Variables
        int largestArea = 0;
        int left = 0;
        int right = height.Length - 1;
        
        while(left < right)
        {
            //Calculate distance between left and right point
            int distance = right - left;

            //Calculate the area using the shorter line height
            int minHeight = Math.Min(height[left], height[right]);
            int area = distance * minHeight;

            //Check if new area is larger than largestArea
            if(area > largestArea)
            {
                largestArea = area;
            }

            //Move side inward that is pointing to the smaller element
            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        
        return largestArea;
    }
}