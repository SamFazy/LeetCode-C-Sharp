using System.Collections.Immutable;

class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Create test cases
        string test1S = "anagram";
        string test1T = "nagaram";

        string test2S = "rat";
        string test2T = "car";

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine("Input: S = " + test1S + ", T = " + test1T);
        Console.WriteLine("Output: " + program.IsAnagram(test1S, test1T));
        Console.WriteLine("Expected: True\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Input: S = " + test2S + ", T = " + test2T);
        Console.WriteLine("Output: " + program.IsAnagram(test2S, test2T));
        Console.WriteLine("Expected: False\n");
    }

    public bool IsAnagram(string s, string t)
    {
        //Check to make sure they are the same length
        if (s.Length != t.Length)
        {
            return false;
        }

        //Turn both into an array
        char[] arrayS = s.ToCharArray();
        char[] arrayT = t.ToCharArray();

        //Sort both arrays
        Array.Sort(arrayS);
        Array.Sort(arrayT);

        if(arrayS.SequenceEqual(arrayT))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}