class Program
{
    static void Main(string[] args)
    {
        //Make instance of program
        Program program = new Program();

        //Create input
        int i1 = 121;
        int i2 = -121;
        int i3 = 10;
        int i4 = 1234567899;

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine(program.IsPalindrome(i1) + "\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine(program.IsPalindrome(i2) + "\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine(program.IsPalindrome(i3) + "\n");

        Console.WriteLine("Test 4:");
        Console.WriteLine(program.IsPalindrome(i4) + "\n");
    }

    public bool IsPalindrome(int x)
    {
        //Variables
        string reverse = null;

        //Put int x into string and reverse it
        for (int i = x.ToString().Length - 1; i >= 0; i--)
        {
            reverse += x.ToString()[i];
        }

        //Check if reversed int matches x
        if(x.ToString() == reverse)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}