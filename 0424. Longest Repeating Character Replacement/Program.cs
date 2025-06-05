class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Create test cases
        string string1 = "ABAB";
        int k1 = 2;

        string string2 = "AABABBA";
        int k2 = 1;

        string string3 = "ABBB";
        int k3 = 2;

        string string4 = "AEFSSAA";
        int k4 = 2;

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine($"Input: | string = {string1} | k = {k1} |");
        Console.WriteLine("Output: " + program.CharacterReplacement(string1, k1));
        Console.WriteLine("Expected: 4\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine($"Input: | string = {string2} | k = {k2} |");
        Console.WriteLine("Output: " + program.CharacterReplacement(string2, k2));
        Console.WriteLine("Expected: 4\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine($"Input: | string = {string3} | k = {k3} |");
        Console.WriteLine("Output: " + program.CharacterReplacement(string3, k3));
        Console.WriteLine("Expected: 4\n");

        Console.WriteLine("Test 4:");
        Console.WriteLine($"Input: | string = {string4} | k = {k4} |");
        Console.WriteLine("Output: " + program.CharacterReplacement(string4, k4));
        Console.WriteLine("Expected: 5\n");
    }

    public int CharacterReplacement(string s, int k)
    {
        //Frequency Table
        int[] charFreq = new int[26];

        //Variables
        int left = 0;
        int maxLength = 0;
        int maxFreq = 0;

        //Loop through array
        for (int right = 0; right < s.Length; right++)
        {
            //Increase count for current charcter
            charFreq[s[right] - 'A']++;

            //Updates if current char becomes most frequest
            maxFreq = Math.Max(maxFreq, charFreq[s[right] - 'A']);

            //Get size of window
            int windowSize = right - left + 1;

            //Shrink window if k is smaller than chars to change
            if(windowSize - maxFreq > k)
            {
                //Reduce freq count of element that will be outside of window
                charFreq[s[left] - 'A']--;

                //Move pointer
                left++;
            }

            //Update max length
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}