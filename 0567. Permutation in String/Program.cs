class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test cases
        string test1S1 = "ab";
        string test1S2 = "eidbaooo";

        string test2S1 = "ab";
        string test2S2 = "eidboaoo";

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine($"Input: | s1 = {test1S1} | s2 = {test1S2} |");
        Console.WriteLine("Output: " + program.CheckInclusion(test1S1, test1S2));
        Console.WriteLine("Expected: true\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine($"Input: | s1 = {test2S1} | s2 = {test2S2} |");
        Console.WriteLine("Output: " + program.CheckInclusion(test2S1, test2S2));
        Console.WriteLine("Expected: false\n");
    }

    public bool CheckInclusion(string s1, string s2)
    {
        //Frequency Tables
        int[] currentCharFreq = new int[26];
        int[] s1CharFreq = new int[26];

        //Populate s1CharFreq
        for(int i = 0; i < s1.Length; i++)
        {
            //Increase count for charcter
            s1CharFreq[s1[i] - 'a']++;
        }

        //Window size
        int windowSize = s1.Length;

        int matches = 0;

        //Count how many distinct characters in s1
        int distinctCount = CountDistinctChars(s1CharFreq);

        //Loop through s2
        for (int right = 0; right < s2.Length; right++)
        {
            //Increase count for current charcter
            currentCharFreq[s2[right] - 'a']++;

            //Check if freq matches s1 freq
            int rightCharIndex = s2[right] - 'a';
            if (currentCharFreq[rightCharIndex] == s1CharFreq[rightCharIndex])
            {
                matches++;
            }
            else if (currentCharFreq[rightCharIndex] == s1CharFreq[rightCharIndex] + 1)
            {
                matches--;
            }

            //Move left pointer
            if (right >= windowSize)
            {
                //Check if current freq matched s1 freq
                int leftCharIndex = s2[right - windowSize] - 'a';

                if (currentCharFreq[leftCharIndex] == s1CharFreq[leftCharIndex])
                {
                    matches--;
                }
                else if (currentCharFreq[leftCharIndex] == s1CharFreq[leftCharIndex] + 1)
                {
                    matches++;
                }

                //Reduce freq count of element that will be outside of window
                currentCharFreq[leftCharIndex]--;
            }

            //If arrays match
            if (matches == distinctCount)
            {
                return true;
            }
        }

        return false;
    }

    //Helper method to count how many distinct characters are in s1
    private int CountDistinctChars(int[] freq)
    {
        int count = 0;
        foreach (var f in freq)
        {
            if (f > 0)
            {
                count++;
            }
        }
        return count;
    }
}