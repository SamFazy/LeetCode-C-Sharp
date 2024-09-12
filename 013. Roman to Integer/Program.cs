class Program
{
    static void Main(string[] args)
    {
        //Make instance of program
        Program program = new Program();

        //Get test results
        Console.WriteLine("Test 1:");
        Console.WriteLine("Result - " + program.RomanToInt("III"));
        Console.WriteLine("Expected - 3\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Result - " + program.RomanToInt("LVIII"));
        Console.WriteLine("Expected - 58\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine("Result - " + program.RomanToInt("MCMXCIV"));
        Console.WriteLine("Expected - 1994\n");

    }

    public int RomanToInt(string s)
    {
        //Variables
        int result = 0;

        //Go through each roman numeral value in string, check the character, add appropriate value to the result.
        for(int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'M')
            {
                result += 1000;
            }
            else if (s[i] == 'C')
            {
                if((i + 1) < s.Length && s[i + 1] == 'M')
                {
                    result += 900;
                    i++;
                }
                else if((i + 1) < s.Length && s[i + 1] == 'D')
                {
                    result += 400;
                    i++;
                }
                else
                {
                    result += 100;
                }
                
            }
            else if(s[i] == 'D')
            {
                result += 500;
            }
            else if(s[i] == 'X')
            {
                if ((i + 1) < s.Length && s[i + 1] == 'C')
                {
                    result += 90;
                    i++;
                }
                else if ((i + 1) < s.Length && s[i + 1] == 'L')
                {
                    result += 40;
                    i++;
                }
                else
                {
                    result += 10;
                }
            }
            else if(s[i] == 'L')
            {
                result += 50;
            }
            else if(s[i] == 'I')
            {
                if ((i + 1) < s.Length && s[i + 1] == 'X')
                {
                    result += 9;
                    i++;
                }
                else if ((i + 1) < s.Length && s[i + 1] == 'V')
                {
                    result += 4;
                    i++;
                }
                else
                {
                    result += 1;
                }
            }
            else if(s[i] == 'V')
            {
                result += 5;
            }
        }

        return result;
    }
}