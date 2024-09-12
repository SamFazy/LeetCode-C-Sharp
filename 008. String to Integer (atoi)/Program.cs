class Program
{
    static void Main(string[] args)
    {
        //Make instance of program
        Program program = new Program();

        //Create input
        string s1 = "42";
        string s2 = "   -42";
        string s3 = "4193 with words";
        string s4 = "hello";
        string s5 = "    hello";
        string s6 = "hello 42";
        string s7 = "";
        string s8 = "999999999999999999999999";
        string s9 = "00000-42a1234";
        string s10 = "   +0 123";
        string s11 = "  +  413";

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine(program.MyAtoi(s1) + "\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine(program.MyAtoi(s2) + "\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine(program.MyAtoi(s3) + "\n");

        Console.WriteLine("Test 4:");
        Console.WriteLine(program.MyAtoi(s4) + "\n");

        Console.WriteLine("Test 5:");
        Console.WriteLine(program.MyAtoi(s5) + "\n");

        Console.WriteLine("Test 6:");
        Console.WriteLine(program.MyAtoi(s6) + "\n");

        Console.WriteLine("Test 7:");
        Console.WriteLine(program.MyAtoi(s7) + "\n");

        Console.WriteLine("Test 8:");
        Console.WriteLine(program.MyAtoi(s8) + "\n");

        Console.WriteLine("Test 9:");
        Console.WriteLine(program.MyAtoi(s9) + "\n");

        Console.WriteLine("Test 10:");
        Console.WriteLine(program.MyAtoi(s10) + "\n");

        Console.WriteLine("Test 11:");
        Console.WriteLine(program.MyAtoi(s11) + "\n");

    }

    public int MyAtoi(string s)
    {
        //Variables
        string strResult = "";
        bool seenNum = false;
        bool seenLetter = false;

        //If string does not contain a number, return 0
        if(!(s.Any(char.IsDigit)))
        {
            return 0;
        }

        //Go over each char inside of string s
        foreach(char c in s)
        {
            //Updates seenLetter flag
            if(Char.IsLetter(c) || c == '.')
            {
                seenLetter = true;
            }
            //Updates seenNum flag and adds it to strResult
            else if(Char.IsDigit(c))
            { 
                seenNum = true;
                strResult += c;
            }
            
            //Checks conditions to return 0
            if ((seenLetter && !seenNum) || (strResult.Length > 0 && (strResult[strResult.Length - 1] == '+' || strResult[strResult.Length - 1] == '-')))
            {
                return 0;
            }
            //Return result
            else if((seenNum && seenLetter) || (seenNum && Char.IsWhiteSpace(c)) || (seenNum && c == '-') || (seenNum && c == '+'))
            {
                //Calls GetParsedInt and returns result
                return GetParsedInt(strResult);
            }

            //Add operator to strResult
            if (c == '-' || c == '+')
            {
                strResult += c;
            }
        }

        //Checks if has seen just num
        if (seenNum)
        {
            //Calls GetParsedInt and returns result
            return GetParsedInt(strResult);
        }

        return 0;
    }

    static int GetParsedInt(string strResult)
    {
        //Checks if both operators are present
        if (strResult.Contains('-') && strResult.Contains("+"))
        {
            return 0;
        }

        //If statement to check if strResult number is in overflow state
        if (int.TryParse(strResult, out int parsedResult))
        {
            return parsedResult;
        }
        else
        {
            if (strResult[0] == '-')
            {
                return int.MinValue;
            }
            else if (strResult[0] == '+' || char.IsDigit(strResult[0]))
            {
                return int.MaxValue;
            }
        }

        //Default return value if none of the conditions match
        return 0;
    }
}