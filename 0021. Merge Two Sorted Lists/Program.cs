class Program
{
    public static void Main(string[] args)
    {
        //Create instance on program
        Program program = new Program();

        //Test cases
        ListNode test1List1 = new ListNode(1,
            new ListNode(2,
                new ListNode(4
                    )
                )
            );
        ListNode test1List2 = new ListNode(1,
            new ListNode(3,
                new ListNode(4)
                )
            );


        ListNode test2List1 = new ListNode();
        ListNode test2List2 = new ListNode();

        ListNode test3List1 = new ListNode();
        ListNode test3List2 = new ListNode(0);

        //Output
        Console.WriteLine("Test 1:");
        Console.WriteLine("Input: ");
        Console.Write("List 1: ");
        program.printListNode(test1List1);
        Console.Write("List 2: ");
        program.printListNode(test1List2);
        Console.Write("Output: ");
        program.printListNode(program.MergeTwoLists(test1List1, test1List2));
        Console.WriteLine("Expected: 1, 1, 2, 3, 4, 4\n");

        Console.WriteLine("Test 2:");
        Console.WriteLine("Input: ");
        Console.Write("List 1: ");
        program.printListNode(test2List1);
        Console.Write("List 2: ");
        program.printListNode(test2List2);
        Console.Write("Output: ");
        program.printListNode(program.MergeTwoLists(test2List1, test2List2));
        Console.WriteLine("Expected: \n");

        Console.WriteLine("Test 3:");
        Console.WriteLine("Input: ");
        Console.Write("List 1: ");
        program.printListNode(test3List1);
        Console.Write("List 2: ");
        program.printListNode(test3List2);
        Console.Write("Output: ");
        program.printListNode(program.MergeTwoLists(test3List1, test3List2));
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

    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        //Make list nodes to hold list 1 and 2
        ListNode listNode1 = list1;
        ListNode listNode2 = list2;

        //Dummy head node to start the merged list
        ListNode dummy = new ListNode();

        //Pointer we will use to build the list
        ListNode current = dummy;

        while (listNode1 != null && listNode2 != null)
        {
            //If list1Node value is larger than listNode2 value
            if(listNode1.val < listNode2.val)
            {
                current.next = listNode1;
                listNode1 = listNode1.next;
            }
            else
            {
                current.next = listNode2;
                listNode2 = listNode2.next;
            }
            current = current.next;
        }

        //Fill in rest of list if some still remain
        if(listNode1 != null)
        {
            current.next = listNode1;
        }
        else if(listNode2 != null)
        {
            current.next = listNode2;
        }

        return dummy.next;
    }
}