class Program
{
    static void Main(string[] args)
    {
        //Make instance of program
        Program program = new Program();

        //Tests and results
        Console.WriteLine("Test 1:");
        Console.WriteLine("Result - " + program.IsMatch("aa", "a"));
        Console.WriteLine("Expected - false\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Result - " + program.IsMatch("aa", "a*"));
        Console.WriteLine("Expected - true\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine("Result - " + program.IsMatch("ab", ".*"));
        Console.WriteLine("Expected - true\n");

        Console.WriteLine("Test 4:");
        Console.WriteLine("Result - " + program.IsMatch("abcd", "abcd"));
        Console.WriteLine("Expected - true\n");

        Console.WriteLine("Test 5:");
        Console.WriteLine("Result - " + program.IsMatch("abcdabcd", "abcd.*"));
        Console.WriteLine("Expected - true\n");

        Console.WriteLine("Test 6:");
        Console.WriteLine("Result - " + program.IsMatch("abcd", "abc"));
        Console.WriteLine("Expected - false\n");

        Console.WriteLine("Test 7:");
        Console.WriteLine("Result - " + program.IsMatch("aab", "c*a*b"));
        Console.WriteLine("Expected - true\n");
    }

    //Main function
    public bool IsMatch(string s, string p)
    {
        return isMatchRecursion(s, p, 0, 0);
    }

    //Recursive helper function
    private bool isMatchRecursion(string s, string p, int sIndex, int pIndex)
    {
        //Check if has reached the end
        if(pIndex >= p.Length)
        {
            return sIndex >= s.Length;
        }

        //Checks if current character match uncluding '.'
        bool isFirstMatch = (sIndex < s.Length) && (p[pIndex] == '.' || s[sIndex] == p[pIndex]);

        //If next char is '*'
        if (pIndex + 1 < p.Length && p[pIndex + 1] == '*')
        {
            //'*' matches zero or more occurrences of the preceding character || The preceding character matches and continues to match more occurrences
            return isMatchRecursion(s, p, sIndex, pIndex + 2) || (isFirstMatch && isMatchRecursion(s, p, sIndex + 1, pIndex));
        }
        else
        {
            //Match current characters and proceed to the next characters
            return isFirstMatch && isMatchRecursion(s, p, sIndex + 1, pIndex + 1);
        }
    }
}