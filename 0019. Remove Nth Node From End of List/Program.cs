class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test Cases
        ListNode test1List = new ListNode(1,
            new ListNode(2,
                new ListNode(3,
                    new ListNode(4,
                        new ListNode(5
                        )
                    )
                )
            )
        );
        int test1int = 2;

        ListNode test2List = new ListNode(1);
        int test2int = 1;

        ListNode test3List = new ListNode(1,
            new ListNode(2
            )
        );
        int test3int = 1;

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine("Input: ");
        Console.Write("List: ");
        program.printListNode(test1List);
        Console.WriteLine("Num: " + test1int);
        Console.Write("Output: ");
        program.printListNode(program.RemoveNthFromEnd(test1List, test1int));
        Console.WriteLine("Expected: 1, 2, 3, 5\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Input: ");
        Console.Write("List: ");
        program.printListNode(test2List);
        Console.WriteLine("Num: " + test2int);
        Console.Write("Output: ");
        program.printListNode(program.RemoveNthFromEnd(test2List, test2int));
        Console.WriteLine("Expected: \n");

        Console.WriteLine("Test 3:");
        Console.WriteLine("Input: ");
        Console.Write("List: ");
        program.printListNode(test3List);
        Console.WriteLine("Num: " + test3int);
        Console.Write("Output: ");
        program.printListNode(program.RemoveNthFromEnd(test3List, test3int));
        Console.WriteLine("Expected: 1\n");
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

    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        //Variables
        ListNode nodeRight = head;
        ListNode nodeLeft = head;
        ListNode dummy = new ListNode();
        ListNode current = dummy;
        int length = 0;
        int loopCount = 0;

        //Counts nums in NodeList
        while(nodeRight != null)
        {
            nodeRight = nodeRight.next;

            length++;
        }

        int nthNode = length - n;

        //Loop to remove nth node
        while (true)
        {
            if(loopCount == nthNode)
            {
                current.next = nodeLeft.next;
                nodeLeft = nodeLeft.next;
                current = current.next;
                break;
            }

            current.next = nodeLeft;
            nodeLeft = nodeLeft.next;
            current = current.next;

            loopCount++;
        }

        return dummy.next;
    }
}