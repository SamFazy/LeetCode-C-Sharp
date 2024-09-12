using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        //Create instamce of program
        Program program = new Program();

        //Create input
        int i1 = 123;
        int i2 = -123;
        int i3 = 120;
        int i4 = 1534236469;

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine(program.Reverse(i1) + "\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine(program.Reverse(i2) + "\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine(program.Reverse(i3) + "\n");

        Console.WriteLine("Test 4:");
        Console.WriteLine(program.Reverse(i4));
    }

    public int Reverse(int x)
    {
        //Variables
        int result = 0;

        //Create string to hold int to reverse
        string strInt = x.ToString();

        //Reverse string
        string reversedString = new string(strInt.Reverse().ToArray());

        //If given number is larger that -1
        if (x > -1)
        {
            //Try catch to catch if the flipped string is larger than an int
            try
            {
                //Turn string into int
                result = int.Parse(reversedString);
            }
            catch 
            {
                return 0;
            }

        }
        else
        {
            //Remove negative from back and put it on front
            string fixedString = "-" + reversedString.Substring(0, reversedString.Length - 1);

            //Try catch to catch if the flipped string is larger than an int
            try
            {
                //Turn string into int
                result = int.Parse(fixedString);
            }
            catch
            {
                return 0;
            }

            
        }

        return result;
    }
}