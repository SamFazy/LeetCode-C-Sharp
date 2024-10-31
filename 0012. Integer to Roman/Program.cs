class Program
{
    static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Get test results
        Console.WriteLine("Test 1:");
        Console.WriteLine("Result - " + program.IntToRoman(3749));
        Console.WriteLine("Expected - MMMDCCXXLIX\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Result - " + program.IntToRoman(58));
        Console.WriteLine("Expected - LVIII\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine("Result - " + program.IntToRoman(1994));
        Console.WriteLine("Expected - MCMXCIV\n");

        Console.WriteLine("Test 4:");
        Console.WriteLine("Result - " + program.IntToRoman(473));
        Console.WriteLine("Expected - CDLXXIII\n");

        Console.WriteLine("Test 5:");
        Console.WriteLine("Result - " + program.IntToRoman(934));
        Console.WriteLine("Expected - CMXXXIV\n");

        Console.WriteLine("Test 6:");
        Console.WriteLine("Result - " + program.IntToRoman(632));
        Console.WriteLine("Expected - DCXXXII\n");
    }

    public string IntToRoman(int num)
    {
        //Variables
        string result = "";

        //Loop until num is 0
        while(num > 0)
        {
            //Check if the remaining number is larger than 1000 and subtrack
            if(num >= 1000)
            {
                
                result += "M";
                num -= 1000;
                
            }
            //Check if the remaining number is larger than 500 and subtrack
            else if (num >= 500)
            {
                if (findFirstDigit(num) == 9)
                {
                    result += "CM";
                    num -= 900;
                }
                else
                {
                    result += "D";
                    num -= 500;
                }
            }
            //Check if the remaining number is larger than 100 and subtrack
            else if (num >= 100)
            {
                if (findFirstDigit(num) == 4)
                {
                    result += "CD";
                    num -= 400;
                }
                else
                {
                    result += "C";
                    num -= 100;
                }
            }
            //Check if the remaining number is larger than 50 and subtrack
            else if (num >= 50)
            {
                if(findFirstDigit(num) == 9)
                {
                    result += "XC";
                    num -= 90;
                }
                else
                {
                    result += "L";
                    num -= 50;
                }
            }
            //Check if the remaining number is larger than 10 and subtrack
            else if (num >= 10)
            {
                if(findFirstDigit(num) == 4)
                {
                    result += "XL";
                    num -= 40;
                }
                else
                {
                    result += "X";
                    num -= 10;
                }
            }
            //Check if the remaining number is larger than 5 and subtrack
            else if (num >= 5)
            {
                if(num == 9)
                {
                    result += "IX";
                    num -= 9;
                }
                else
                {
                    result += "V";
                    num -= 5;
                }
            }
            //Check if the remaining number is larger than 1 and subtrack
            else if (num >= 1)
            {
                if(num == 4)
                {
                    result += "IV";
                    num -= 4;
                }
                else
                {
                    result += "I";
                    num -= 1;
                }
            }
        }

        return result;
    }

    private int findFirstDigit(int num)
    {
        //Finding first digit
        while(num >= 10)
        {
            num /= 10;
        }

        //Return result
        return num;
    }
}