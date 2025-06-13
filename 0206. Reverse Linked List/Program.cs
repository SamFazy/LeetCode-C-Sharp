class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test cases
        ListNode test1 = new ListNode(1,
            new ListNode(2,
                new ListNode(3,
                    new ListNode(4,
                        new ListNode(5)
                        )
                    )
                )
            );

        ListNode test2 = new ListNode(1,
                new ListNode(2
                )
            );

        ListNode test3 = new ListNode();

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: ");
        program.printListNode(test1);
        Console.Write("Output: ");
        program.printListNode(program.ReverseList(test1));
        Console.WriteLine("Expected: 5, 4, 3, 2, 1\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: ");
        program.printListNode(test2);
        Console.Write("Output: ");
        program.printListNode(program.ReverseList(test2));
        Console.WriteLine("Expected: 2, 1\n");

        Console.WriteLine("Test 3:");
        Console.Write("Input: ");
        program.printListNode(test3);
        Console.Write("Output: ");
        program.printListNode(program.ReverseList(test3));
        Console.WriteLine("Expected: \n");

    }

    public void printListNode(ListNode listNode)
    {
        while (listNode != null)
        {
            Console.Write(listNode.val);

            if (listNode.next != null)
            {
                Console.Write(", ");
            }

            listNode = listNode.next;
        }

        Console.WriteLine();
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

    public ListNode ReverseList(ListNode head)
    {
        //Get previous and current node
        ListNode prev = null;
        ListNode curr = head;

        //Loops through curr until curr == null
        while (curr != null)
        {
            //Temporary next pointer
            ListNode next = curr.next;

            //Reverse
            curr.next = prev;

            //Move porinters forward
            prev = curr;
            curr = next;
        }

        return prev;
    }
}