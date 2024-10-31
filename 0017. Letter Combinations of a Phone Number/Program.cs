class Program
{
    public static void Main(string[] args)
    {
        //Crate instance of program
        Program program = new Program();

        //Create test cases
        string test1 = "23";
        string test2 = "";
        string test3 = "2";
        string test4 = "234";
        string test5 = "32";

        //Get results and print
        Console.WriteLine("Test 1:");
        Console.WriteLine("Input - " + test1);
        Console.Write("Result - ");
        foreach (string result in program.LetterCombinations(test1))
        {
            Console.Write(result + " ");   
        }
        Console.WriteLine();
        Console.WriteLine("Expected - ad ae af bd be bf cd ce cf\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Input - " + test2);
        Console.Write("Result - ");
        foreach (string result in program.LetterCombinations(test2))
        {
            Console.Write(result + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Expected - \n");

        Console.WriteLine("Test 3:");
        Console.WriteLine("Input - " + test3);
        Console.Write("Result - ");
        foreach (string result in program.LetterCombinations(test3))
        {
            Console.Write(result + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Expected - a b c\n");

        Console.WriteLine("Test 4:");
        Console.WriteLine("Input - " + test4);
        Console.Write("Result - ");
        foreach (string result in program.LetterCombinations(test4))
        {
            Console.Write(result + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Expected - adg adh adi aeg aeh aei afg afh afi bdg bdh bdi beg beh bei bfg bfh bfi cdg cdh cdi ceg ceh cei cfg cfh cfi");

        Console.WriteLine("Test 5:");
        Console.WriteLine("Input - " + test5);
        Console.Write("Result - ");
        foreach (string result in program.LetterCombinations(test5))
        {
            Console.Write(result + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Expected - da db dc ea eb ec fa fb fc");
    }

    public IList<string> LetterCombinations(string digits)
    {
        //Creating list to populate
        IList<string> resultList = new List<string>();

        //Check to see if digits is null
        if (digits == null || digits == "")
        {
            return resultList;
        }

        //Create list to hold possible letters
        IList<IList<char>> letters = new List<IList<char>>();

        //Go over each digit and add letters
        foreach (char digit in digits)
        {
            IList<char> letter = new List<char>();

            if (digit == '2')
            {
                letter.Add('a');
                letter.Add('b');
                letter.Add('c');
            }
            else if (digit == '3')
            {
                letter.Add('d');
                letter.Add('e');
                letter.Add('f');
            }
            else if (digit == '4')
            {
                letter.Add('g');
                letter.Add('h');
                letter.Add('i');
            }
            else if (digit == '5')
            {
                letter.Add('j');
                letter.Add('k');
                letter.Add('l');
            }
            else if (digit == '6')
            {
                letter.Add('m');
                letter.Add('n');
                letter.Add('o');
            }
            else if (digit == '7')
            {
                letter.Add('p');
                letter.Add('q');
                letter.Add('r');
                letter.Add('s');
            }
            else if (digit == '8')
            {
                letter.Add('t');
                letter.Add('u');
                letter.Add('v');
            }
            else if (digit == '9')
            {
                letter.Add('w');
                letter.Add('x');
                letter.Add('y');
                letter.Add('z');
            }

            letters.Add(letter);
        }

        //If there is only 1 number
        if(letters.Count == 1)
        {
            foreach(char number in letters[0])
            {
                resultList.Add(number.ToString());
            }
        }
        //If there are 2 or more letters
        else
        {
            //Create string that can be used inside of recursive function
            string currentLetters = "";

            //Call recursive function to find all possible combinations
            findLetters(resultList, letters, digits, 0, currentLetters);

        }
        
        //Return final list
        return resultList;

        void findLetters(IList<string> resultList, IList<IList<char>> characters, string digits, int index, string currentLetters)
        {
            //When index equals length of digits, add the results to the list
            if(index == digits.Length) 
            {
                resultList.Add(currentLetters);
                return;
            }
            
            //Get the current letters associated to the current digit
            char digit = digits[index];
            string letters = "";
            foreach(char letter in characters[index])
            {
                letters += letter.ToString();
            }

            //Iterate though each letter recursively
            foreach(char letter in letters)
            {
                currentLetters += letter;
                findLetters(resultList, characters, digits, index + 1, currentLetters);
                currentLetters = currentLetters.Remove(currentLetters.Length - 1);
            }
        }
    }
}