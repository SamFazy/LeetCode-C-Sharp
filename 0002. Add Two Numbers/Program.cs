class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test Cases
        ListNode test1L1 = new ListNode(2,
            new ListNode(4,
                new ListNode(3
                )
            )
        );
        ListNode test1L2 = new ListNode(5,
            new ListNode(6,
                new ListNode(4
                )
            )
        );

        ListNode test2L1 = new ListNode(0);
        ListNode test2L2 = new ListNode(0);

        ListNode test3L1 = new ListNode(9,
            new ListNode(9,
                new ListNode(9,
                    new ListNode(9,
                        new ListNode(9,
                            new ListNode(9,
                                new ListNode(9)
                            )
                        )
                    )
                )
            )
        );

        ListNode test3L2 = new ListNode(9,
            new ListNode(9,
                new ListNode(9,
                    new ListNode(9)
                )
            )
        );

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("List 1: ");
        program.printListNode(test1L1);
        Console.Write("List 2: ");
        program.printListNode(test1L2);
        Console.Write("Output: ");
        program.printListNode(program.AddTwoNumbers(test1L1, test1L2));
        Console.WriteLine("Expected: 7, 0, 8\n");

        Console.WriteLine("Test 2:");
        Console.Write("List 1: ");
        program.printListNode(test2L1);
        Console.Write("List 2: ");
        program.printListNode(test2L2);
        Console.Write("Output: ");
        program.printListNode(program.AddTwoNumbers(test2L1, test2L2));
        Console.WriteLine("Expected: 0\n");

        Console.WriteLine("Test 3:");
        Console.Write("List 1: ");
        program.printListNode(test3L1);
        Console.Write("List 2: ");
        program.printListNode(test3L2);
        Console.Write("Output: ");
        program.printListNode(program.AddTwoNumbers(test3L1, test3L2));
        Console.WriteLine("Expected: 8, 9, 9, 9, 0, 0, 0, 1\n");

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
    public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int val=0, ListNode next=null) {
             this.val = val;
             this.next = next;
         }
     }


    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        //Create list nodes to hold result
        ListNode head = new ListNode();
        ListNode current = head;

        int overflow = 0;

        //Loops until hits end of both l1 and l2
        while (l1 != null || l2 != null) 
        {
            //If l1 is null
            if(l1 == null)
            {
                //Add l2 and overflow together
                int total = l2.val + overflow;

                //Reset overflow
                overflow = 0;

                //Account for overflow
                if (total > 9)
                {
                    overflow = total / 10;
                    total = total % 10;
                }

                //Add to current
                current.next = new ListNode(total);
                current = current.next;

                //Move nodes forward
                l2 = l2.next;
            }
            //If l2 is null
            else if(l2 == null)
            {
                //Add l1 and overflow together
                int total = l1.val + overflow;

                //Reset overflow
                overflow = 0;

                //Account for overflow
                if (total > 9)
                {
                    overflow = total / 10;
                    total = total % 10;
                }

                //Add to current
                current.next = new ListNode(total);
                current = current.next;

                //Move nodes forward
                l1 = l1.next;
            }
            //If both are not null
            else
            {
                //Add l1, l2 and overflow together
                int total = l1.val + l2.val + overflow;

                //Reset overflow
                overflow = 0;

                //Account for overflow
                if(total > 9)
                {
                    overflow = total / 10;
                    total = total % 10;
                }

                //Add to current
                current.next = new ListNode(total);
                current = current.next;

                //Move nodes forward
                l1 = l1.next;
                l2 = l2.next;
            }
        }

        //Add if there is any overflow left
        if(overflow > 0)
        {
            current.next = new ListNode(overflow);
        }

        return head.next;
    }
}