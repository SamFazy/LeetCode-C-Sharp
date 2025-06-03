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
        string s8 = "nfpdmpi";

        //Print output
        Console.WriteLine("Test 1:");
        Console.WriteLine("Output: " + program.LengthOfLongestSubstring(s1));
        Console.WriteLine("Expected: 3\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Output: " + program.LengthOfLongestSubstring(s2));
        Console.WriteLine("Expected: 1\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine("Output: " + program.LengthOfLongestSubstring(s3));
        Console.WriteLine("Expected: 3\n");

        Console.WriteLine("Test 4:");
        Console.WriteLine("Output: " + program.LengthOfLongestSubstring(s4));
        Console.WriteLine("Expected: 1\n");

        Console.WriteLine("Test 5:");
        Console.WriteLine("Output: " + program.LengthOfLongestSubstring(s5));
        Console.WriteLine("Expected: 0\n");

        Console.WriteLine("Test 6:");
        Console.WriteLine("Output: " + program.LengthOfLongestSubstring(s6));
        Console.WriteLine("Expected: 2\n");

        Console.WriteLine("Test 7:");
        Console.WriteLine("Output: " + program.LengthOfLongestSubstring(s7));
        Console.WriteLine("Expected: 3\n");

        Console.WriteLine("Test 8:");
        Console.WriteLine("Output: " + program.LengthOfLongestSubstring(s8));
        Console.WriteLine("Expected: 5\n");
    }

    public int LengthOfLongestSubstring(string s)
    { 
        //Create Dictionary to hold values
        Dictionary<char, int> letterCount = new Dictionary<char, int>();

        //Variables
        int noDuplicateCount = 0;
        int right = 0;
        int left = 0;

        //If the length is larger than 1
        if(s.Length > 1)
        {
            letterCount[s[right]] = 1;

            while (true)
            {
                //If right pointer has hit the end
                if(right == s.Length)
                {
                    break;
                }

                if (right == s.Length - 1)
                {
                    return noDuplicateCount;
                }

                //Move pointer
                right++;

                //Increase letter value
                if (letterCount.ContainsKey(s[right]))
                    letterCount[s[right]]++;
                else
                    letterCount[s[right]] = 1;

                //Get count of current pointer letter
                int count = letterCount[s[right]];

                //If larger than 1
                if (count > 1)
                {
                    //Loops until there are no more duplicates
                    do
                    {
                        //Remove letter going out of sliding window
                        letterCount[s[left]]--;
                        
                        //Move left poineter
                        left++;

                        //Get count of current pointer letter
                        count = letterCount[s[right]];

                    }
                    while (count >= 2);

                    if (noDuplicateCount < (right - left) + 1)
                    {
                        noDuplicateCount = (right - left) + 1;
                    }

                }
                else
                {
                    if(noDuplicateCount < (right - left) + 1)
                    {
                        noDuplicateCount = (right - left) + 1;
                    }
                }
            }
        }
        
        return s.Length;
    }
}