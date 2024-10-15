class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Create test cases

        //Case 1
        ListNode list1num1 = new ListNode(1);
        ListNode list1num2 = new ListNode(2);
        ListNode list1num3 = new ListNode(3);
        ListNode list1num4 = new ListNode(4);
        ListNode list1num5 = new ListNode(5);
        list1num1.next = list1num2;
        list1num2.next = list1num3;
        list1num3.next = list1num4;
        list1num4.next = list1num5;
        int n1 = 2;

        //Case 2
        ListNode list2num1 = new ListNode(1);
        int n2 = 1;

        //Case 3
        ListNode list3num1 = new ListNode(1);
        ListNode list3num2 = new ListNode(2);
        list3num1.next = list3num2;
        int n3 = 1;

        //Case 4
        ListNode list4num1 = new ListNode(1);
        ListNode list4num2 = new ListNode(2);
        list4num1.next = list4num2;
        int n4 = 2;

        //Get results and print
        Console.WriteLine("Test 1:");
        Console.Write("Input: ");
        program.printNodesResults(list1num1);
        Console.WriteLine("\nN: " + n1);
        Console.Write("Output: ");
        program.printNodesResults(program.RemoveNthFromEnd(list1num1, n1));
        Console.WriteLine("\nExpected: 1, 2, 3, 5\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: ");
        program.printNodesResults(list2num1);
        Console.WriteLine("\nN: " + n2);
        Console.Write("Output: ");
        program.printNodesResults(program.RemoveNthFromEnd(list2num1, n2));
        Console.WriteLine("\nExpected: \n");

        Console.WriteLine("Test 3:");
        Console.Write("Input: ");
        program.printNodesResults(list3num1);
        Console.WriteLine("\nN: " + n3);
        Console.Write("Output: ");
        program.printNodesResults(program.RemoveNthFromEnd(list3num1, n3));
        Console.WriteLine("\nExpected: 1\n");

        Console.WriteLine("Test 4:");
        Console.Write("Input: ");
        program.printNodesResults(list4num1);
        Console.WriteLine("\nN: " + n4);
        Console.Write("Output: ");
        program.printNodesResults(program.RemoveNthFromEnd(list4num1, n4));
        Console.WriteLine("\nExpected: 2\n");

    }

    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        //Count the number of nodes
        ListNode currentNode = head;
        int length = 0;

        while (currentNode != null) 
        {
            length++;

            if (currentNode.val < 0 || currentNode.val > 100)
            {
                return null;
            }

            currentNode = currentNode.next;
        }

        //Constraints
        if (n > length)
        {
            return null;
        }
        else if(n < 1)
        {
            return null;
        }
        else if (length > 30)
        {
            return null;
        }
        else if (length == 1)
        {
            return null;
        }

        //Calculate the element needed to be removed
        int remove = length - n + 1;

        //Go through all the ListNodes and remove the element at n
        currentNode = head;
        int currentElement = 1;

        for(int i = 1; i < length; i++)
        {
            if (i + 1 == remove && i + 2 <= length)
            {
                currentNode.next = currentNode.next.next;
                break;
            }
            else if (i + 1 == remove && !(i + 2 <= length))
            {
                currentNode.next = null;
                break;
            }
            else if(i == 1 && i == remove)
            {
                head = currentNode.next;
                break;
            }

            currentNode = currentNode.next;
        }
        
        return head;
    }

    public void printNodesResults(ListNode head)
    {
        ListNode currentNode = head;

        while(currentNode != null)
        {
            if (currentNode.next != null)
            {
                Console.Write(currentNode.val + ", ");
            }
            else 
            {
                Console.Write(currentNode.val);
            }

            currentNode = currentNode.next;
        }
    }

    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}