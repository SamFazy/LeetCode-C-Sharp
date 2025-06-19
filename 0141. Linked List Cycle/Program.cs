/*
 * NOTE:
 * Testing doesnt work for this question because in Leetcode there was a hidden variable to tell the program where to make a hidden loop in the ListNodes. 
 * To match my submission on leetcode, I will leave the method to remain the same. Therefore it does not appear to function properly here.
 * 
 * Link to my submission (you might have to be signed into leetcode to view the submission): https://leetcode.com/problems/linked-list-cycle/submissions/1669889886/
*/

class Program
{
    public static void Main(string[] args)
    {
        //Create instance of program
        Program program = new Program();

        //Test cases
        ListNode test1List = new ListNode(3,
            new ListNode(2,
                new ListNode(0,
                    new ListNode(-4
                        )
                    )
                )
            );

        ListNode test2List = new ListNode(1,
            new ListNode(2
                )
            );

        ListNode test3List = new ListNode(-1);

        //Output
        Console.WriteLine("Test 1:");
        Console.Write("Input: ");
        program.printListNode(test1List);
        Console.WriteLine("Output: " + program.HasCycle(test1List));
        Console.WriteLine("Expected: True\n");

        Console.WriteLine("Test 2:");
        Console.Write("Input: ");
        program.printListNode(test2List);
        Console.WriteLine("Output: " + program.HasCycle(test2List));
        Console.WriteLine("Expected: True\n");

        Console.WriteLine("Test 3:");
        Console.Write("Input: ");
        program.printListNode(test3List);
        Console.WriteLine("Output: " + program.HasCycle(test3List));
        Console.WriteLine("Expected: False\n");
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

    public bool HasCycle(ListNode head)
    {
        //Create pointers
        ListNode pointer1 = head;
        ListNode pointer2 = head;

        //Loops until pointer 2 is null
        while (pointer1 != null && pointer2 != null) 
        {
            //Move pointers and check for null
            //Pointer 1 checks
            if(pointer1.next == null)
            {
                break;
            }
            else
            {
                pointer1 = pointer1.next;
            }

            //Pointer 2 checks
            if (pointer2.next == null)
            {
                break;
            }
            else 
            {
                pointer2 = pointer2.next;

                if (pointer2.next == null)
                {
                    break;
                }
                else
                {
                    pointer2 = pointer2.next;
                }
            }


            //Check if they are equal
            if (pointer1 == pointer2)
            {
                return true;
            }
        }

        return false;
    }
}