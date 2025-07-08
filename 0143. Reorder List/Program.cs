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
                    new ListNode(4
                    )
                )
            )
        );

        ListNode test2List = new ListNode(1,
            new ListNode(2,
                new ListNode(3,
                    new ListNode(4,
                        new ListNode(5
                        )
                    )
                )
            )
        );

        ListNode test3List = new ListNode(1);

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: ");
        program.printListNode(test1List);
        program.ReorderList(test1List);
        Console.Write("Output: ");
        program.printListNode(test1List);
        Console.WriteLine("Expected: 1, 4, 2, 3\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: ");
        program.printListNode(test2List);
        program.ReorderList(test2List);
        Console.Write("Output: ");
        program.printListNode(test2List);
        Console.WriteLine("Expected: 1, 5, 2, 4, 3\n");

        Console.WriteLine("Test 3:");
        Console.Write("Input: ");
        program.printListNode(test3List);
        program.ReorderList(test3List);
        Console.Write("Output: ");
        program.printListNode(test3List);
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

    public void ReorderList(ListNode head)
    {
        //Checks to make sure there is more than 1 node
        if (head == null || head.next == null)
            return;

        //Variables
        ListNode prev = null;
        ListNode pointer1 = head;
        ListNode pointer2 = head;

        //Fast and slow pointer to split in half
        while(pointer2 != null && pointer2.next != null)
        {
            prev = pointer1;
            pointer1 = pointer1.next;
            pointer2 = pointer2.next.next;
        }

        //Break the list in two
        if (prev != null)
        {
            prev.next = null;
        }

        //Reverse second half
        ListNode prev2 = null;
        ListNode curr = pointer1;

        //Loops through curr until curr == null
        while (curr != null)
        {
            //Temporary next pointer
            ListNode next = curr.next;

            //Reverse
            curr.next = prev2;

            //Move porinters forward
            prev2 = curr;
            curr = next;
        }


        //Variables
        ListNode list1 = head;
        ListNode list2 = prev2;
        ListNode dummy = new ListNode();
        ListNode current = dummy;

        //Merge ListNodes
        while (list1 != null || list2 != null)
        {
            //Add list1
            if(list1 != null)
            {
                current.next = list1;
                list1 = list1.next;

                current = current.next;
            }

            //Add list2
            if (list2 != null)
            {
                current.next = list2;
                list2 = list2.next;

                current = current.next;
            }
        }

        //Set head as start of the merged lists
        head = dummy.next;
    }
}