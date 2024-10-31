class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Create test cases
        string test1 = "()";
        string test2 = "()[]{}";
        string test3 = "(]";
        string test4 = "([])";
        string test5 = "([)]";
        string test6 = "([q])";
        string test7 = "){";
        string test8 = "([}}])";

        //Get results and print
        Console.WriteLine("Test 1:");
        Console.WriteLine("Input: " + test1);
        Console.WriteLine("Output: " + program.IsValid(test1).ToString());
        Console.WriteLine("Expected: True\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Input: " + test2);
        Console.WriteLine("Output: " + program.IsValid(test2).ToString());
        Console.WriteLine("Expected: True\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine("Input: " + test3);
        Console.WriteLine("Output: " + program.IsValid(test3).ToString());
        Console.WriteLine("Expected: False\n");

        Console.WriteLine("Test 4:");
        Console.WriteLine("Input: " + test4);
        Console.WriteLine("Output: " + program.IsValid(test4).ToString());
        Console.WriteLine("Expected: True\n");

        Console.WriteLine("Test 5:");
        Console.WriteLine("Input: " + test5);
        Console.WriteLine("Output: " + program.IsValid(test5).ToString());
        Console.WriteLine("Expected: False\n");

        Console.WriteLine("Test 6:");
        Console.WriteLine("Input: " + test6);
        Console.WriteLine("Output: " + program.IsValid(test6).ToString());
        Console.WriteLine("Expected: False\n");

        Console.WriteLine("Test 7:");
        Console.WriteLine("Input: " + test7);
        Console.WriteLine("Output: " + program.IsValid(test7).ToString());
        Console.WriteLine("Expected: False\n");

        Console.WriteLine("Test 8:");
        Console.WriteLine("Input: " + test8);
        Console.WriteLine("Output: " + program.IsValid(test8).ToString());
        Console.WriteLine("Expected: False\n");
    }

    public bool IsValid(string s)
    {
        //Contditions to return false
        if(s == null || s.Length < 2 || s.Length >= 10000 || s.Length % 2 == 1)
        {
            return false;
        }

        //Create counters
        int numOpening = 0;
        int numClosing = 0;

        //Create stack
        Stack<char> stack = new Stack<char>();

        //Loop through string
        for (int i = 0; i < s.Length; i++)
        {
            //Check for opening bracket
            if ((s[i] == '(') || (s[i] == '[') || (s[i] == '{'))
            {
                stack.Push(s[i]);
                numOpening++;
            }

            //Check for closing with proper opening
            else if ((s[i] == ')') && stack.Count != 0 && stack.Peek() == '(')
            {
                stack.Pop();
            }
            else if ((s[i] == ']') && stack.Count != 0 && stack.Peek() == '[')
            {
                stack.Pop();
            }
            else if ((s[i] == '}') && stack.Count != 0 && stack.Peek() == '{')
            {
                stack.Pop();
            }

            //Check for not valid character
            else if (s[i] != '(' && s[i] != ')' && s[i] != '[' && s[i] != ']' && s[i] != '{' && s[i] != '}')
            {
                return false;
            }

            //Closing brackets
            if (s[i] == ')' || s[i] == ']' || s[i] == '}')
            {
                numClosing++;
            }
        }

        //Check to see if the stack is empty
        if(stack.Count == 0 && numOpening == numClosing)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}