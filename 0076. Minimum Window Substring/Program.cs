using System.Collections;

class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test cases
        string test1s = "ADOBECODEBANC";
        string test1t = "ABC";

        string test2s = "a";
        string test2t = "a";

        string test3s = "a";
        string test3t = "aa";

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine($"Input: | s = {test1s} | t = {test1t} |");
        Console.WriteLine("Output: " + program.MinWindow(test1s, test1t));
        Console.WriteLine("Expected: BANC\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine($"Input: | s = {test2s} | t = {test2t} |");
        Console.WriteLine("Output: " + program.MinWindow(test2s, test2t));
        Console.WriteLine("Expected: a\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine($"Input: | s = {test3s} | t = {test3t} |");
        Console.WriteLine("Output: " + program.MinWindow(test3s, test3t));
        Console.WriteLine("Expected: \n");
    }

    public string MinWindow(string s, string t)
    {
        //Frequency Table to track needed chars
        Hashtable tLetters = new Hashtable();

        //Populate tLetters
        foreach (char c in t)
        {
            //Checks if letter is already in tLetters
            if (tLetters.ContainsKey(c))
            {
                //Increment frequency of that letter
                tLetters[c] = (int)tLetters[c] + 1;
            }
            else
            {
                //Add new letter with frequency of 1
                tLetters[c] = 1;
            }
        }

        //Current window character counts
        Hashtable currentLetterCounts = new Hashtable();
        int required = tLetters.Count;
        int formed = 0;

        //Result string
        string result = "";

        //Pointers
        int left = 0;
        int right = 0;
        int minLen = int.MaxValue;
        int minStart = 0;

        //Loops until j hits the end
        while (right < s.Length)
        {
            //Expand window by adding s[right]
            char rightChar = s[right];
            if (currentLetterCounts.ContainsKey(rightChar))
            {
                currentLetterCounts[rightChar] = (int)currentLetterCounts[rightChar] + 1;
            }
            else
            {
                currentLetterCounts[rightChar] = 1;
            }

            //If the character is in t and its count matches the required count
            if (tLetters.ContainsKey(rightChar) && (int)currentLetterCounts[rightChar] == (int)tLetters[rightChar])
            {
                formed++;
            }
               
            //Try to shrink window
            while (formed == required)
            {
                //Update result
                if ((right - left + 1) < minLen)
                {
                    minLen = right - left + 1;
                    minStart = left;
                }

                char leftChar = s[left];
                currentLetterCounts[leftChar] = (int)currentLetterCounts[leftChar] - 1;

                if (tLetters.ContainsKey(leftChar) && (int)currentLetterCounts[leftChar] < (int)tLetters[leftChar])
                {
                    formed--;
                }

                left++;
            }

            right++;
        }

        return minLen == int.MaxValue ? "" : s.Substring(minStart, minLen);
    }
}