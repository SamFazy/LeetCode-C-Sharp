class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Create test cases
        string[] test1 = { "2", "1", "+", "3", "*" };
        string[] test2 = { "4", "13", "5", "/", "+" };
        string[] test3 = { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
        string[] test4 = { "3", "4", "+", "2", "*", "7", "/" };
        string[] test5 = { "5", "1", "2", "+", "4", "*", "+", "3", "-" };
        string[] test6 = { "3", "4", "/", "2", "+", "7", "/" };

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: ");
        program.printArray(test1);
        Console.WriteLine($"Output: {program.EvalRPN(test1)}");
        Console.WriteLine("Expected: 9\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: ");
        program.printArray(test2);
        Console.WriteLine($"Output: {program.EvalRPN(test2)}");
        Console.WriteLine("Expected: 6\n");

        Console.WriteLine("Test 3:");
        Console.Write("Input: ");
        program.printArray(test3);
        Console.WriteLine($"Output: {program.EvalRPN(test3)}");
        Console.WriteLine("Expected: 22\n");

        Console.WriteLine("Test 4:");
        Console.Write("Input: ");
        program.printArray(test4);
        Console.WriteLine($"Output: {program.EvalRPN(test4)}");
        Console.WriteLine("Expected: 2\n");

        Console.WriteLine("Test 5:");
        Console.Write("Input: ");
        program.printArray(test5);
        Console.WriteLine($"Output: {program.EvalRPN(test5)}");
        Console.WriteLine("Expected: 14\n");

        Console.WriteLine("Test 6:");
        Console.Write("Input: ");
        program.printArray(test6);
        Console.WriteLine($"Output: {program.EvalRPN(test6)}");
        Console.WriteLine("Expected: 0\n");

    }

    public void printArray(string[] array)
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

    public int EvalRPN(string[] tokens)
    {
        //Create stacks to hold nums and operators
        Stack<int> nums = new Stack<int>();
        Stack<string> operators = new Stack<string>();

        //Loop through string tokens and calculate total
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "+" || tokens[i] == "-" || tokens[i] == "*" || tokens[i] == "/")
            {
                operators.Push(tokens[i]);

                int num1 = 0;
                int num2 = 0;

                //Possible operator calculations
                switch (tokens[i])
                {
                    case "+":
                        num1 = nums.Pop();
                        num2 = nums.Pop();
                        nums.Push(num2 + num1);
                        break;
                    case "-":
                        num1 = nums.Pop();
                        num2 = nums.Pop();
                        nums.Push(num2 - num1);
                        break;
                    case "*":
                        num1 = nums.Pop();
                        num2 = nums.Pop();
                        nums.Push(num2 * num1);
                        break;
                    case "/":
                        num1 = nums.Pop();
                        num2 = nums.Pop();
                        nums.Push(num2 / num1);
                        break;
                }

                operators.Pop();
            }
            else
            {
                nums.Push(int.Parse(tokens[i]));
            }
        }
        return nums.Pop();
    }
}