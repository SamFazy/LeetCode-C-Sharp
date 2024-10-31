class Program
{
    static void Main(string[] args)
    {
        //Make instance of Program
        Program program = new Program();

        //Create input strings
        string s1 = "babad";
        string s2 = "cbbd";

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine(program.LongestPalindrome(s1));

        Console.WriteLine("Test 2:");
        Console.WriteLine(program.LongestPalindrome(s2));
    }

    public string LongestPalindrome(string s)
    {
        //Check if string is empty
        if (string.IsNullOrEmpty(s))
            return string.Empty;

        //Create string variable
        string longestPalindrome = string.Empty;

        //Go through elements
        for (int i = 0; i < s.Length; i++)
        {
            //Odd length
            string palindrome = ExpandAroundCenter(s, i, i);
            if (palindrome.Length > longestPalindrome.Length)
                longestPalindrome = palindrome;

            //Even length
            palindrome = ExpandAroundCenter(s, i, i + 1); // Even length palindrome
            if (palindrome.Length > longestPalindrome.Length)
                longestPalindrome = palindrome;
        }

        return longestPalindrome;
    }

    private string ExpandAroundCenter(string s, int left, int right)
    {
        //Checks in both directions of given string
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }

        return s.Substring(left + 1, right - left - 1);
    }
}