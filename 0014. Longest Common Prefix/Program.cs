class Program
{
    static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Make arrays for testing
        string[] a1 = { "flower", "flow", "flight" };
        string[] a2 = { "dog", "racecar", "car" };

        //Get test results
        Console.WriteLine("Test 1:");
        Console.WriteLine("Result - " + program.LongestCommonPrefix(a1));
        Console.WriteLine("Expected - fl\n");

        //Get test results
        Console.WriteLine("Test 2:");
        Console.WriteLine("Result - " + program.LongestCommonPrefix(a2));
        Console.WriteLine("Expected - \n");
    }

    public string LongestCommonPrefix(string[] strs)
    {
        //Variables
        string result = "";
        int shortestLength = strs[0].Length;
        bool commonLetter = true;

        //Get length of shortest string
        foreach(string str in strs)
        {
            if(str.Length < shortestLength)
            {
                shortestLength = str.Length;
            }
        }

        //Create loop to find longest common prefix
        for(int i = 0; i < shortestLength; i++)
        {
            //Set common letter to true for start of the loop
            commonLetter = true;

            //Go through each letter and check if the current element matches the first string
            foreach(string str in strs)
            {
                if (strs[0][i] != str[i])
                {
                    commonLetter = false;
                }
            }

            //If not all strings current letter match, return result.
            if(commonLetter == false)
            {
                return result;
            }
            //Add current letter to result
            else
            {
                result += strs[0][i];
            }

        }

        return result;
    }
}