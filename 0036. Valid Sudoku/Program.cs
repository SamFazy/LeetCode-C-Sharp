using System.Collections;
using System.Data;

class Program
{
    public static void Main(String[] args)
    {
        //Create instance of program
        Program program = new Program();

        // Create test cases
        char[][] test1 = new char[][]
        {
            new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
            new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
            new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
            new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
            new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
            new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
            new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
            new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
            new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
        };

        char[][] test2 = new char[][]
        {
            new char[] {'8', '3', '.', '.', '7', '.', '.', '.', '.'},
            new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
            new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
            new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
            new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
            new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
            new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
            new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
            new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
        };

        char[][] test3 = new char[][]
        {
            new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
            new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
            new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
            new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
            new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
            new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
            new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
            new char[] {'.', '2', '.', '4', '1', '9', '.', '.', '5'},
            new char[] {'2', '.', '.', '.', '8', '.', '.', '7', '9'}
        };

        char[][] test4 = new char[][]
        {
            new char[] {'1', '3', '5', '.', '7', '.', '9', '2', '4'},
            new char[] {'6', '2', '4', '1', '9', '5', '8', '7', '3'},
            new char[] {'8', '9', '7', '3', '2', '4', '5', '6', '1'},
            new char[] {'4', '6', '9', '5', '3', '8', '1', '2', '7'},
            new char[] {'3', '7', '8', '4', '1', '2', '6', '5', '9'},
            new char[] {'2', '1', '5', '9', '8', '7', '4', '3', '6'},
            new char[] {'5', '4', '6', '2', '3', '9', '7', '1', '8'},
            new char[] {'7', '8', '2', '6', '5', '1', '3', '4', '9'},
            new char[] {'9', '5', '3', '7', '4', '6', '2', '8', '1'}
        };

        char[][] test5 = new char[][]
        {
            new char[] {'8', '1', '9', '4', '6', '.', '3', '7', '2'},
            new char[] {'2', '6', '4', '3', '9', '7', '5', '1', '8'},
            new char[] {'5', '3', '7', '1', '8', '2', '9', '6', '4'},
            new char[] {'4', '7', '2', '9', '5', '8', '6', '3', '1'},
            new char[] {'1', '9', '3', '6', '2', '4', '8', '5', '7'},
            new char[] {'6', '5', '8', '7', '1', '3', '4', '2', '9'},
            new char[] {'9', '4', '5', '8', '7', '1', '2', '9', '3'},
            new char[] {'7', '2', '6', '5', '4', '9', '1', '8', '3'},
            new char[] {'3', '8', '1', '2', '3', '6', '7', '4', '5'}
        };

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Output: ");
        Console.WriteLine(program.IsValidSudoku(test1));
        Console.WriteLine("Expected: True\n");

        Console.WriteLine("Test 2:");
        Console.Write("Output: ");
        Console.WriteLine(program.IsValidSudoku(test2));
        Console.WriteLine("Expected: False\n");

        Console.WriteLine("Test 3:");
        Console.Write("Output: ");
        Console.WriteLine(program.IsValidSudoku(test3));
        Console.WriteLine("Expected: False\n");

        Console.WriteLine("Test 4:");
        Console.Write("Output: ");
        Console.WriteLine(program.IsValidSudoku(test4));
        Console.WriteLine("Expected: False\n");

        Console.WriteLine("Test 5:");
        Console.Write("Output: ");
        Console.WriteLine(program.IsValidSudoku(test5));
        Console.WriteLine("Expected: False\n");

    }

    public bool IsValidSudoku(char[][] board)
    {
        //Create a 2D 27x9 array for full grid check
        int[,] validator = new int[27, 9];

        //Go through board

        //X Axis
        for (int i = 0; i < board.Length; i++)
        {
            //Y Axis
            for(int j = 0; j < board.Length; j++)
            {
                //Increases element in validator if number is present
                if (board[i][j] >= '1' && board[i][j] <= '9')
                {
                    //Whole grid validation
                    validator[i, board[i][j] - '1'] += 1;
                    validator[j + 9, board[i][j] - '1'] += 1;
                    

                    if (validator[i, board[i][j] - '1'] >= 2 || validator[j + 9, board[i][j] - '1'] >= 2)
                    {
                        return false;
                    }

                    //Sub grid validation
                    validator[(i/3 * 3 + j/3) + 18, board[i][j] - '1'] += 1;

                    if (validator[(i / 3 * 3 + j / 3) + 18, board[i][j] - '1'] >= 2)
                    {
                        return false;
                    }

                }
            }
        }

        return true;
    }
}