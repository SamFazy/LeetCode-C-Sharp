using System.Text;

class Program
{
    static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Create input
        string s1 = "PAYPALISHIRING";
        int i1 = 3;

        string s2 = "PAYPALISHIRING";
        int i2 = 4;

        string s3 = "A";
        int i3 = 1;

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine(program.Convert(s1, i1) + "\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine(program.Convert(s2, i2) + "\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine(program.Convert(s3, i3));
    }

    public string Convert(string s, int numRows)
    {
        //Return original string if only one row
        if (numRows == 1)
        {
            return s;
        }

        //Adjust numRows if it exceeds string length
        if (numRows > s.Length)
        {
            numRows = s.Length;
        }

        //Create array of lists for each row
        var rows = new List<char>[numRows];

        //Counter for characters and rows
        var i = 0;
        var j = 0;

        //Direction of traversal
        var down = true; 

        //Iterate through each character
        while (i < s.Length)
        {
            //Create row list if non-existent
            if (rows[j] == null)
            {
                rows[j] = new List<char>();
            }

            //Add character to row
            rows[j].Add(s[i]);

            //Update row index based on direction
            j = j + (down ? 1 : -1);

            //Change direction and adjust row index if boundary reached
            if (j == numRows || j < 0)
            {
                down = !down;
                j = j + (down ? 2 : -2);
            }

            //Increase i
            i++;
        }

        //Concatenate characters from each row and return string
        return new string(rows.SelectMany(row => row).ToArray());


    }

}

//This passed in leet code.
//Output here in visual studio is not correct.
//This problem in leet code isnt very detailed and output cases seem weird...