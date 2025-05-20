class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine("Input: 1");
        Console.Write($"Output: ");
        program.printList(program.GenerateParenthesis(1));
        Console.WriteLine();

        Console.WriteLine("Test 2:");
        Console.WriteLine("Input: 2");
        Console.Write($"Output: ");
        program.printList(program.GenerateParenthesis(2));
        Console.WriteLine();

        Console.WriteLine("Test 3:");
        Console.WriteLine("Input: 3");
        Console.Write($"Output: ");
        program.printList(program.GenerateParenthesis(3));
        Console.WriteLine();

        Console.WriteLine("Test 4:");
        Console.WriteLine("Input: 4");
        Console.Write($"Output: ");
        program.printList(program.GenerateParenthesis(4));
        Console.WriteLine();
    }

    public void printList(IList<string> strings)
    {
        foreach (string s in strings) 
        {
            Console.Write(s + ", ");
        }

        Console.WriteLine();
    }

    public IList<string> GenerateParenthesis(int n)
    {
        //Create list of strings to hold result
        IList<string> result = new List<string>();

        result = GenerateParenthesisCombinations(n * 2, "", 0, 0);

        return result;
    }

    //Helper method
    public static List<string> GenerateParenthesisCombinations(int n, string current, int numOpen, int numClosed)
    {
        //List to collect results
        List<string> resultList = new List<string>();

        //If n = 0, full string is done
        if (n == 0)
        {
            //Check if there are the same amount of open and closed brackets
            if (numOpen != numClosed)
            {
                return resultList;
            }

            //If all ends up good, return and add to list
            resultList.Add(current);
            return resultList;
        }

        //Try adding '('
        resultList.AddRange(GenerateParenthesisCombinations(n - 1, current + "(", numOpen + 1, numClosed));

        //Make sure there wont be more closed brackets than open if we add a closed
        if (!((numClosed + 1) > numOpen))
        {
            //Try adding ')'
            resultList.AddRange(GenerateParenthesisCombinations(n - 1, current + ")", numOpen, numClosed + 1));
        }

        //Returns all results
        return resultList;
    }
}