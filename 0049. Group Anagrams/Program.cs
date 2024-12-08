using System.Collections;
using System.Linq;
using System.Windows.Markup;

class Program
{
    public static void Main(string[] args)
    {
        //Create an instance of program
        Program program = new Program();

        //Create test cases
        string[] test1 = { "eat", "tea", "tan", "ate", "nat", "bat" };
        string[] test2 = { "" };
        string[] test3 = { "a" };

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: ");
        program.PrintArray(test1);
        Console.Write("Output: ");
        program.PrintLists(program.GroupAnagrams(test1));
        Console.WriteLine("Expected: [\"bat\"],[\"nat\",\"tan\"],[\"ate\",\"eat\",\"tea\"]\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: ");
        program.PrintArray(test2);
        Console.Write("Output: ");
        program.PrintLists(program.GroupAnagrams(test2));
        Console.WriteLine("Expected: [\"\"]\n");

        Console.WriteLine("Test 3:");
        Console.Write("Input: ");
        program.PrintArray(test3);
        Console.Write("Output: ");
        program.PrintLists(program.GroupAnagrams(test3));
        Console.WriteLine("Expected: [\"a\"]\n");
    }

    //Prints array
    public void PrintArray(string[] array)
    {
        foreach (string word in array)
        {
            Console.Write(word + " ");
        }

        Console.WriteLine();
    }

    //Prints lists
    public void PrintLists(IList<IList<string>> lists)
    {
        foreach (IList<string> list in lists)
        {
            Console.Write("[");
            foreach (string word in list)
            {
                Console.Write("\"" + word + "\"");
            }
            Console.Write("] ");
        }
        Console.WriteLine();
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        //Create dictionary
        var dictionary = new Dictionary<string, IList<string>>();

        //Loop through each word in strs
        foreach(string word in strs)
        {
            //Used to count the number of occurances of a letter (a - z)
            int[] count = new int[26];

            //Loop through each letter in the current word
            foreach(char character in word)
            {
                count[character - 'a']++;
            }

            //Convert array into string with each letter separated by a ','
            string key = string.Join(",", count);

            //If key does not exist, creates a new list for it
            if(!dictionary.ContainsKey(key))
            {
                dictionary[key] = new List<string>();
            }

            //Add current word to list
            dictionary[key].Add(word);
        }

        //Returns result
        return dictionary.Values.ToList<IList<string>>();
    }
}