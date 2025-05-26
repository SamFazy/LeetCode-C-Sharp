class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test cases
        int target1 = 12;
        int[] position1 = { 10, 8, 0, 5, 3 };
        int[] speed1 = { 2, 4, 1, 1, 3 };

        int target2 = 10;
        int[] position2 = { 3 };
        int[] speed2 = { 3 };

        int target3 = 100;
        int[] position3 = { 0, 2, 4 };
        int[] speed3 = { 4, 2, 1 };

        int target4 = 10;
        int[] position4 = { 6, 8 };
        int[] speed4 = { 3, 2 };

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine("Input:");
        Console.WriteLine("Target: " + target1);
        Console.Write("Position: ");
        program.printIntArray(position1);
        Console.Write("Speed: ");
        program.printIntArray(speed1);
        Console.WriteLine("Output: " + program.CarFleet(target1, position1, speed1));
        Console.WriteLine("Expected: 3\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Input:");
        Console.WriteLine("Target: " + target2);
        Console.Write("Position: ");
        program.printIntArray(position2);
        Console.Write("Speed: ");
        program.printIntArray(speed2);
        Console.WriteLine("Output: " + program.CarFleet(target2, position2, speed2));
        Console.WriteLine("Expected: 1\n");

        Console.WriteLine("Test 3:");
        Console.WriteLine("Input:");
        Console.WriteLine("Target: " + target3);
        Console.Write("Position: ");
        program.printIntArray(position3);
        Console.Write("Speed: ");
        program.printIntArray(speed3);
        Console.WriteLine("Output: " + program.CarFleet(target3, position3, speed3));
        Console.WriteLine("Expected: 1\n");

        Console.WriteLine("Test 4:");
        Console.WriteLine("Input:");
        Console.WriteLine("Target: " + target4);
        Console.Write("Position: ");
        program.printIntArray(position4);
        Console.Write("Speed: ");
        program.printIntArray(speed4);
        Console.WriteLine("Output: " + program.CarFleet(target4, position4, speed4));
        Console.WriteLine("Expected: 2\n");
    }

    public void printIntArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (i + 1 == array.Length)
            {
                Console.WriteLine(array[i]);
            }
            else
            {
                Console.Write(array[i] + ", ");
            }
        }
    }

    public int CarFleet(int target, int[] position, int[] speed)
    {
        //Zip arrays together when sorting position array
        var combined = position
            .Select((position, Index) => new { Position = position, Speed = speed[Index]})
            .OrderByDescending(pair => pair.Position)
            .ToList();

        //Unzip the results
        position = combined.Select(pair => pair.Position).ToArray();
        speed = combined.Select(pair => pair.Speed).ToArray();

        //Create stack of times
        Stack<double> times = new Stack<double>();

        //Keep track of the number of fleets
        int fleetCount = 0;

        //Loop over all elements and identify the total fleet count
        for (int i = 0; i < position.Length; i++)
        {
            //Calculates current cars time
            double time = ((double)target - (double)position[i]) / (double)speed[i];

            //If its the first element
            if (i == 0)
            {
                times.Push(time);
                fleetCount++;
                continue;
            }

            //If the current car is faster than the previous
            if(!(time <= times.Peek()))
            {
                times.Push(time);
                fleetCount++;
            }
        }

        return fleetCount;
    }
}