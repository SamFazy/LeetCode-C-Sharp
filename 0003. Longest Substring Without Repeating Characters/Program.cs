using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        //Make instance of program
        Program program = new Program();

        //Strings to test with
        string s1 = "abcabcbb";
        string s2 = "bbbbb";
        string s3 = "pwwkew";
        string s4 = " ";
        string s5 = "";
        string s6 = "au";
        string s7 = "dvdf";

        //Print output
        Console.WriteLine("Test 1:");
        Console.WriteLine(program.LengthOfLongestSubstring(s1));

        Console.WriteLine("Test 2:");
        Console.WriteLine(program.LengthOfLongestSubstring(s2));

        Console.WriteLine("Test 3:");
        Console.WriteLine(program.LengthOfLongestSubstring(s3));

        Console.WriteLine("Test 4:");
        Console.WriteLine(program.LengthOfLongestSubstring(s4));

        Console.WriteLine("Test 5:");
        Console.WriteLine(program.LengthOfLongestSubstring(s5));

        Console.WriteLine("Test 6:");
        Console.WriteLine(program.LengthOfLongestSubstring(s6));

        Console.WriteLine("Test 7:");
        Console.WriteLine(program.LengthOfLongestSubstring(s7));
    }

    public int LengthOfLongestSubstring(string s)
    {
        //Create List to hold letters
        List<char> letters = new List<char>();

        //Variables
        int maxCount = 0;
        int count;

        //Loops through each letter in s
        for (int i = 0; i < s.Length; i++)
        {
            //Clear list before checking substring
            letters.Clear();

            //Start counting from current character
            count = 0;

            //Compare each letter in letters to current letter in s
            foreach (char c in s.Substring(i))
            {
                //If letter does exist in s
                if (letters.Contains(c))
                    break;

                //Add letter and increase count
                letters.Add(c);
                count++;
            }

            //Sets max count to count if count is larger than max count
            if (maxCount < count)
                maxCount = count;
        }

        //Return result
        return maxCount;
    }
}