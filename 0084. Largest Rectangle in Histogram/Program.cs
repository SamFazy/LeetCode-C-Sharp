class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test cases
        int[] heights1 = { 2, 1, 5, 6, 2, 3 };
        int[] heights2 = { 2, 4 };

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: ");
        program.printIntArray(heights1);
        Console.WriteLine("Output: " + program.LargestRectangleArea(heights1));
        Console.WriteLine("Expected: 10\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: ");
        program.printIntArray(heights2);
        Console.WriteLine("Output: " + program.LargestRectangleArea(heights2));
        Console.WriteLine("Expected: 4\n");

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

    public int LargestRectangleArea(int[] heights)
    {
        int largestArea = 0;

        //Stores the indices
        Stack<int> stack = new Stack<int>();

        //Loops over all elements monotonically increasing
        for (int i = 0; i < heights.Length; i++) 
        {
            //Maintain increasing order
            while (stack.Count > 0 && heights[i] < heights[stack.Peek()])
            {
                int top = stack.Pop();
                int height = heights[top];
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                int area = height * width;
                largestArea = Math.Max(largestArea, area);
            }

            stack.Push(i);
        }

        //Process remaining
        while (stack.Count > 0)
        {
            int top = stack.Pop();
            int height = heights[top];
            int width = stack.Count == 0 ? heights.Length : heights.Length - stack.Peek() - 1;
            int area = height * width;
            largestArea = Math.Max(largestArea, area);
        }

        return largestArea;
    }
}